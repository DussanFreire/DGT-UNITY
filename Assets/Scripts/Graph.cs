using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;

public class Graph : MonoBehaviour
{

	public GameObject nodePrefab;
	bool onInit =true; 
	public GameObject edgePrefab;
    public List<EdgeModel> allEdges { get; set; }
    public List<Node> allNodes { get; set; }
    public List<string> filters { get; set; }
	public int currentVersion { get; set; }
	public float size { get; set; }
    
    private const string URL_INIT = "https://dependency-graph-z42n.vercel.app/file/restart";
    private const string URL_UPDATE = "https://dependency-graph-z42n.vercel.app/file/brain";
	void Start()
	{
		currentVersion=-1;
		allEdges = new List<EdgeModel>();
        allNodes = new List<Node>();
		Metrics.verticalRotationUsed = 0;
		Metrics.horizontalRotationUsed = 0;
		Metrics.hoverUsed = 0;
		Metrics.touchUsed = 0;
		Metrics.pointerUsed = 0;
		Metrics.srcFilterUsed=0;
		Metrics.controllerFilterUsed=0;
		Metrics.serviceFilterUsed=0;
		Metrics.transpFilterUsed=0;
		Metrics.decoratorFilterUsed=0;
		Metrics.dtoFilterUsed=0;
		Metrics.enumFilterUsed=0;
		Metrics.guardFilterUsed=0;
		Metrics.persistenceFilterUsed=0;
        Metrics.currentTest = 1;
		// GenerateRequest();
		InvokeRepeating("GenerateRequest", 0.0f, 3.0f);
		
	}

	void Update(){
		if(Menu.buttonPressed){
			transform.Rotate(0,0.75f, 0, Space.Self);
		}
		if(MenuVertical.buttonPressed){
			transform.Rotate(0.75f,0, 0, Space.Self);
		}
	}


	public void GenerateRequest()
	{
		if(onInit){
			StartCoroutine(ProcessRequestGet(URL_INIT, ResponseCallback));
			onInit=false;
		}else{
			StartCoroutine(ProcessRequestPost(URL_UPDATE, ResponseCallback));
		}
	}

	private IEnumerator ProcessRequestGet(string uri, Action<RequestModel> callback = null)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(uri))
		{
			yield return request.SendWebRequest();

			if (request.isNetworkError)
			{
				Debug.Log(request.error);
			}
			else
			{
				var data = request.downloadHandler.text;
				RequestModel RequestModel = JsonUtility.FromJson<RequestModel>(data);
				if (callback != null)
					callback(RequestModel);
			}
		}
	}	
	private IEnumerator ProcessRequestPost(string uri, Action<RequestModel> callback = null)
	{
		WWWForm form = new WWWForm();
		form.AddField("verticalRotationUsed", Metrics.verticalRotationUsed);
		form.AddField("horizontalRotationUsed", Metrics.horizontalRotationUsed);
		form.AddField("hoverUsed", Metrics.hoverUsed);
		form.AddField("touchUsed", Metrics.touchUsed);
		form.AddField("pointerUsed", Metrics.pointerUsed);
		form.AddField("srcFilterUsed", Metrics.srcFilterUsed);
		form.AddField("controllerFilterUsed", Metrics.controllerFilterUsed);
		form.AddField("serviceFilterUsed", Metrics.serviceFilterUsed);
		form.AddField("decoratorFilterUsed", Metrics.decoratorFilterUsed);
		form.AddField("dtoFilterUsed", Metrics.dtoFilterUsed);
		form.AddField("enumFilterUsed", Metrics.enumFilterUsed);
		form.AddField("guardFilterUsed", Metrics.guardFilterUsed);
		form.AddField("persistenceFilterUsed", Metrics.persistenceFilterUsed);
		form.AddField("transpFilterUsed", Metrics.transpFilterUsed);
		form.AddField("currentTime", DateTime.Now.ToString());
		form.AddField("currentTest", Metrics.currentTest);

		using (UnityWebRequest request = UnityWebRequest.Post(uri,form))
		{
			yield return request.SendWebRequest();

			if (request.isNetworkError)
			{
				Debug.Log(request.error);
			}
			else
			{
				var data = request.downloadHandler.text;
				RequestModel RequestModel = JsonUtility.FromJson<RequestModel>(data);
				if (callback != null)
					callback(RequestModel);
			}
		}
	}

	private void ResponseCallback(RequestModel requestModel)
	{
		if(currentVersion==-1){
			currentVersion=0;
			createNodesFromData(requestModel);
		}
		else if(requestModel.version > currentVersion)
		{
			currentVersion =requestModel.version;
			if(size!=requestModel.size){
				deleteObj();
				createNodesFromData(requestModel);
			}
			else
			updateNodesFromData(requestModel);
		}
	}

    private void updateNodesFromData(RequestModel requestModel)
    {
		foreach (NodeRequestModel nodeRequest in requestModel.nodes)
		{

			Node nodeToUpdate = allNodes.Find(n=>n.id == nodeRequest.id);
			List<Link> links = getEdges(nodeToUpdate.id, requestModel);
			Color nodeColor = getColor(nodeRequest.color);
			nodeToUpdate.visible = nodeRequest.visible;
			nodeToUpdate.setColor(nodeColor);
			if(requestModel.actions.rotateV) Debug.Log("requestModel.actions.rotateV");
			if(requestModel.actions.rotateH) Debug.Log("requestModel.actions.rotateH");
			MenuVertical.myActionFromHttp(requestModel.actions.rotateV);
			Menu.myActionFromHttp(requestModel.actions.rotateH);
			if (nodeRequest.visible){
				nodeToUpdate.showTextLabel(nodeToUpdate,nodeColor);
				nodeToUpdate.turnToSolidColor();
			} else {
				nodeToUpdate.hideTextLabel(nodeToUpdate);
				nodeToUpdate.turnToTranspColor();
			}
			foreach (Link link in links)
			{
				EdgeModel edgeToUpdate=  allEdges.Find(e=>e.target==link.target&& e.origin ==link.source);
				edgeToUpdate.visible = link.visible;
				Color edgeColor = getColor(EdgeColorModel.regularEdge);

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
		
		moveXPosition(requestModel.actions.xBackward,requestModel.actions.xForward);
		moveYPosition(requestModel.actions.yBackward,requestModel.actions.yForward);
		moveZPosition(requestModel.actions.zBackward,requestModel.actions.zForward);
    }

	private Node generateNode(NodeRequestModel nodeRequest){
			NodeGameObjModel nodeGameObj = new NodeGameObjModel();
			Color nodeColor = getColor(nodeRequest.color);
			nodeGameObj.node = Instantiate(nodePrefab, new Vector3(nodeRequest.x, nodeRequest.y, nodeRequest.z), Quaternion.identity);
			nodeGameObj.id = nodeRequest.id;
			nodeGameObj.node.transform.parent = transform;
			nodeGameObj.node.name = nodeRequest.name;
			filters = nodeRequest.filters;
			Node node = nodeGameObj.node.GetComponent<Node>();
			node.visible = nodeRequest.visible;
			node.id = nodeGameObj.id;
			node.setChildIds(nodeRequest.childIds);
			node.setNode(nodeGameObj.node);
			node.setColor(nodeColor);
			if (nodeRequest.visible){
				node.turnToSolidColor();
			} else {
				node.turnToTranspColor();
			}
			return node;
	}

	private void createNodesFromData(RequestModel RequestModel)
	{
		allNodes = new List<Node>();
		size =RequestModel.size;
		foreach (NodeRequestModel nodeRequest in RequestModel.nodes)
		{
			Node node = generateNode(nodeRequest);
			allNodes.Add(node);
		}

		foreach (Node node in allNodes)
		{
			List<Link> links = getEdges(node.id, RequestModel);
			if (links.Count > 0)
			{
				node.SetEdgePrefab(edgePrefab);
				Vector3 scale = node.edgePrefab.transform.GetChild(0).localScale;
				scale.z =0.0015f;
				node.edgePrefab.transform.GetChild(0).localScale = scale;
				setEdges(node, links, allNodes);
			}
        }
        foreach (Node node in allNodes)
        {

            setNodeParents(node, allNodes);
            setNodeChildren(node, allNodes);
			node.allEdges = allEdges;
			node.allNodes = allNodes;
        }
		for (int i = 0; i < this.allEdges.Count; i++)
        {
			Color edgeColor = getColor(EdgeColorModel.regularEdge);

			if (allEdges[i].visible)
			{
				allEdges[i].turnEdgeToSolidColor(edgeColor);
			}
			else
			{
				allEdges[i].turnEdgeToTranspColor(edgeColor);
			}
        }
    }
	void deleteObj(){
	
		
		allNodes.ForEach(n=>{
			Destroy(n.node);
			n.allEdges = new List<EdgeModel>();
			n.allNodes =new List<Node>();
		});
		allNodes = new List<Node>();
		allEdges = new List<EdgeModel>();

	}
	

	private void setEdges(Node node, List<Link> links, List<Node> nodeList)
	{
		foreach (Link link in links)
		{
			Node targetNode = getNodeById(link.target, nodeList);
            EdgeModel edgeAdded =  node.AddEdge(targetNode, link.source);
			edgeAdded.visible = link.visible;
			allEdges.Add(edgeAdded);
		}
	}
	

	
	private Color getColor(string colorHex)
	{
		Color color;
		ColorUtility.TryParseHtmlString(colorHex, out color);
		return color;
	}

	private Node getNodeById(int id, List<Node> nodeList)
	{
		Node result = nodeList.Find(n=>n.id==id);
		return result;
	}

	private List<Link> getEdges(int source, RequestModel RequestModel)
	{
		List<Link> linkResult = RequestModel.nodes.Find(l => l.id == source).links;
		return linkResult;
	}

    private void setNodeParents(Node node, List<Node> nodeList)
    {
		List<Node> nodeParentsList = nodeList.Where(x => x.childIds.Contains(node.id)).ToList();
        List<EdgeModel> nodeEdgesToParents = nodeParentsList.Select(n => n.edges.Where(edge => edge.target == node.id).FirstOrDefault()).ToList();
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


	private void moveXPosition(bool backward, bool forward){
		if(!backward && !forward)
			return;
		float movement = 0.5f;
		if(backward) movement*=-1;
		Vector3 pos = transform.localPosition;
		pos += new Vector3(movement,0,0);
		transform.localPosition =pos;
	}
	private void moveYPosition(bool backward, bool forward){
		if(!backward && !forward)
			return;
		float movement = 0.5f;
		if(backward) movement*=-1;
		Vector3 pos = transform.localPosition;
		pos += new Vector3(0,movement,0);
		transform.localPosition =pos;
	}
	private void moveZPosition(bool backward, bool forward){
		if(!backward && !forward)
			return;
		float movement = 0.5f;
		if(backward) movement*=-1;
		Vector3 pos = transform.localPosition;
		pos += new Vector3(0,0,movement);
		transform.localPosition =pos;
	}


}