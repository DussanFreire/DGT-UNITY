using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;

public class Graph : MonoBehaviour 
{
	public GameObject nodePrefab;
	bool graphBuilded =false; 
	public GameObject edgePrefab;
	public DateTime RightHandTime;
	public DateTime LeftHandtime;
    public List<string> filters { get; set; }
	public int currentVersion { get; set; }
	public int currentTask { get; set; }
	bool rightHandUsed { get; set; }
	bool leftHandUsed { get; set; }

	MixedRealityPose pose;
    AudioSource audioData;

	private GameObject graph;

    void Start()
	{
		graph = ObjectManager.FindInActiveObjectByName("HandleGraph");
		currentTask=0;
		currentVersion=-1;
        NodesManager.AllNodes = new List<Node>();
        EdgesManager.AllEdges = new List<Edge>();
		if(!Enviroment.DESKTOP_SETUP){
			InvokeRepeating("getHeadCoords", 0.0f, 1.0f);
		}
		InvokeRepeating("GenerateRequest", 0.0f, 1.0f);
		leftHandUsed =false;
		rightHandUsed =false;
        audioData = GetComponent<AudioSource>();
		ColorsManager.audioData = audioData;
	}

	void Update(){
		SizeManager.setSizeListener(graph.transform);
		RorationManager.setRotationListeners(transform);
		PositionManager.setMovementListeners(graph.transform);
		KeyboardManager.setKeyboardAndMouseListeners(transform);
		if (!rightHandUsed && HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
			RightHandTime = DateTime.Now;
            rightHandUsed =true;
        }
		if(rightHandUsed && !HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose)){
			DateTime aux=DateTime.Now ;
			TimeSpan span = aux- RightHandTime;
			MetricsManager.rightHandDateTime.Add(span.Seconds.ToString());
			rightHandUsed =false;
		}

		if (!leftHandUsed && HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out pose))
        {
			LeftHandtime = DateTime.Now;
            leftHandUsed =true;
        }
		if(leftHandUsed && !HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out pose)){
			DateTime aux=DateTime.Now ;
			TimeSpan span = aux- LeftHandtime;
			MetricsManager.leftHandDateTime.Add(span.Seconds.ToString());
			leftHandUsed =false;
		}
	}

	public void getHeadCoords(){
		Vector3 camPos = Camera.main.transform.position;
		Vector3 coord = new Vector3();
		Vector3 rotation = Camera.main.transform.eulerAngles;
		coord.x=camPos.x;
		coord.y=camPos.y;
		coord.z=camPos.z;

		MetricsManager.headCoords.Add(coord);
		MetricsManager.headRotation.Add(rotation);
		Debug.Log(MetricsManager.headCoords.Count);
		if(MetricsManager.headCoords.Count > 10){
			StartCoroutine(RequestsManager.SendHeadMetricsDataPost(Enviroment.URL_SEND_METRICS_HEAD));
		}
	}

	public void GenerateRequest()
	{
		if(!graphBuilded){
			StartCoroutine(RequestsManager.GetGraphData(Enviroment.URL_INIT_GRAPH, ResponseCallback));
			graphBuilded=true;
		}else{
			StartCoroutine(RequestsManager.GetGraphData(Enviroment.URL_GET_GRAPH, ResponseCallback));
		}
	}

	private void resetGraph(RequestDto requestModel){
		SizeManager.changeSize(new Vector3(1,1,1));
		PositionManager.moveInitPositionSlow();
		ColorsManager.labelShowed =false;
		Color edgeColor = ColorsManager.getColor(Enviroment.REGULAR_EDGE_COLOR);
		foreach (Node node in NodesManager.AllNodes)
		{
			node.hideTextLabel();
			node.turnToSolidColor();
		}	

		foreach (Edge edge in EdgesManager.AllEdges)
		{
			edge.turnEdgeToSolidColor(edgeColor);
		}	
	}

	private void updateToNewVersion(RequestDto requestModel){
		currentVersion =requestModel.version;
		if(NodesManager.NodeSize!=requestModel.size){
			NodesManager.NodeSize=requestModel.size;
			SizeManager.changeSize(new Vector3(requestModel.size,requestModel.size,requestModel.size));
		}
		else if(requestModel.actions.resetUsed){
			resetGraph(requestModel);
		}
		else{
			updateNodesFromData(requestModel);
		}
	}

	private void initGraphForirstTime(RequestDto requestModel){
		currentVersion=0;
		GameObject.Find("GraphPrefab(Clone)").SetActive(false);
		createNodesFromData(requestModel);
		PositionManager.moveInitPosition();
	}

	private void changeTask(RequestDto requestModel){
		if(!Enviroment.DESKTOP_SETUP){
			StartCoroutine(RequestsManager.SendHeadMetricsDataPost(Enviroment.URL_SEND_METRICS_HEAD));
		}
		StartCoroutine(RequestsManager.SendMetricsDataPost(Enviroment.URL_SEND_METRICS));
		MetricsManager.headCoords= new List<Vector3>();
		MetricsManager.headRotation= new List<Vector3>();
		MetricsManager.actionsDone= new List<NodeActionDto>();
		MetricsManager.leftHandDateTime= new List<string>();
		MetricsManager.rightHandDateTime= new List<string>();
		currentTask= requestModel.taskId;
	}

	private void ResponseCallback(RequestDto requestModel)
	{
		if(currentVersion==-1){
			initGraphForirstTime(requestModel);
		}
		else if(requestModel.version > currentVersion)
		{
			updateToNewVersion(requestModel);
		}
	
		if(currentTask != requestModel.taskId){
			changeTask(requestModel);
		}
	}

    private void updateNodesFromData(RequestDto requestModel)
    {
		foreach (NodeRequestDto nodeRequest in requestModel.nodes)
		{
			Node nodeToUpdate = NodesManager.AllNodes.Find(n=>n.id == nodeRequest.id);
			List<LinkDto> links = getEdges(nodeToUpdate.id, requestModel);
			Color nodeColor = ColorsManager.getColor(nodeRequest.color);
			nodeToUpdate.visible = nodeRequest.visible;
			nodeToUpdate.setColor(nodeColor);
			RorationManager.changeVerticalRotation(requestModel.actions.rotateV);
			RorationManager.changeHorizontalRotation(requestModel.actions.rotateH);
			if(requestModel.actions.filterUsed){
				ColorsManager.labelShowed =true;
				if (nodeRequest.visible ){
					nodeToUpdate.showTextLabel();
					nodeToUpdate.turnToSolidColor();
				} else {
					nodeToUpdate.hideTextLabel();
					nodeToUpdate.turnToTranspColor();
				}
			}

			foreach (LinkDto link in links)
			{
				Edge edgeToUpdate=  EdgesManager.AllEdges.Find(e=>e.target==link.target&& e.origin ==link.source);
				edgeToUpdate.visible = link.visible;
				Color edgeColor = ColorsManager.getColor(Enviroment.REGULAR_EDGE_COLOR);

				if (link .visible)
				{
					edgeToUpdate.turnEdgeToSolidColor(edgeColor);
				}
				else
				{
					edgeToUpdate.turnEdgeToTranspColor(edgeColor);
				}
			}
			
		}
		
		PositionManager.moveXPosition(requestModel.actions.xBackward,requestModel.actions.xForward, transform);
		PositionManager.moveYPosition(requestModel.actions.yBackward,requestModel.actions.yForward, transform);
		PositionManager.moveZPosition(requestModel.actions.zBackward,requestModel.actions.zForward, transform);
    }

	private Node generateNode(NodeRequestDto nodeRequest){
			Color nodeColor = ColorsManager.getColor(nodeRequest.color);
			GameObject nodeGameObj = Instantiate(nodePrefab, new Vector3(nodeRequest.x, nodeRequest.y, nodeRequest.z), Quaternion.identity);
			nodeGameObj.transform.parent = transform;
			nodeGameObj.name = nodeRequest.name;
			filters = nodeRequest.filters;
			Node node = nodeGameObj.GetComponent<Node>();
			node.visible = nodeRequest.visible;
			node.id = nodeRequest.id;
			node.setChildIds(nodeRequest.childIds);
			node.setNode(nodeGameObj);
			node.setColor(nodeColor);
			node.graphtransf = transform;
			if (nodeRequest.visible){
				node.turnToSolidColor();
			} else {
				node.turnToTranspColor();
			}
			return node;
	}

	private void createNodesFromData(RequestDto RequestModel)
	{
		Vector3 sizeGraph =  new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z); 

		NodesManager.NodeSize =RequestModel.size;
		foreach (NodeRequestDto nodeRequest in RequestModel.nodes)
		{
			Node node = generateNode(nodeRequest);
			node.nodeGameObject.transform.localScale=Enviroment.NODE_LOCAL_SCALE* NodesManager.NodeSize*3;
			NodesManager.AllNodes.Add(node);
		}

		foreach (Node node in NodesManager.AllNodes)
		{
			List<LinkDto> links = getEdges(node.id, RequestModel);
			if (links.Count > 0)
			{
				node.SetEdgePrefab(edgePrefab);
				Vector3 scale = node.edgePrefab.transform.GetChild(0).localScale;
				scale.z =0.0015f;
				node.edgePrefab.transform.GetChild(0).localScale = scale;
				setEdges(node, links, NodesManager.AllNodes);
			}
        }
        foreach (Node node in NodesManager.AllNodes)
        {
            setNodeParents(node, NodesManager.AllNodes);
            setNodeChildren(node, NodesManager.AllNodes);
        }
		for (int i = 0; i < EdgesManager.AllEdges.Count; i++)
        {
			Color edgeColor = ColorsManager.getColor(Enviroment.REGULAR_EDGE_COLOR);
			Vector3 localScaleEdge = EdgesManager.AllEdges[i].edge.transform.localScale;
			Vector3 auxScaleEdge = Enviroment.EDGE_LOCAL_SCALE* NodesManager.NodeSize*0.3f;
			EdgesManager.AllEdges[i].edge.transform.localScale= new Vector3(auxScaleEdge.x,auxScaleEdge.y,localScaleEdge.z); 
			if (EdgesManager.AllEdges[i].visible)
			{
				EdgesManager.AllEdges[i].turnEdgeToSolidColor(edgeColor);
			}
			else
			{
				EdgesManager.AllEdges[i].turnEdgeToTranspColor(edgeColor);
			}
        }
    }
	
	private void setEdges(Node node, List<LinkDto> links, List<Node> nodeList)
	{
		foreach (LinkDto link in links)
		{
			Node targetNode = getNodeById(link.target, nodeList);
            Edge edgeAdded =  node.AddEdge(targetNode, link.source);
			edgeAdded.visible = link.visible;
			EdgesManager.AllEdges.Add(edgeAdded);
		}
	}

	private Node getNodeById(int id, List<Node> nodeList)
	{
		Node result = nodeList.Find(n=>n.id==id);
		return result;
	}

	private List<LinkDto> getEdges(int source, RequestDto RequestModel)
	{
		List<LinkDto> linkResult = RequestModel.nodes.Find(l => l.id == source).links;
		return linkResult;
	}

    private void setNodeParents(Node node, List<Node> nodeList)
    {
		List<Node> nodeParentsList = nodeList.Where(x => x.childIds.Contains(node.id)).ToList();
        List<Edge> nodeEdgesToParents = nodeParentsList.Select(n => n.edges.Where(edge => edge.target == node.id).FirstOrDefault()).ToList();
        node.setEdgestoParents(nodeEdgesToParents);
        node.addNodeParents(nodeParentsList);
    }

	private void setNodeChildren(Node node, List<Node> nodeList)
    {
		List<Node> childrenList = nodeList.Where(
				n => node.childIds.Any(x => x == n.id)
			).ToList();
        node.setNodeChildren(childrenList);
    }
}