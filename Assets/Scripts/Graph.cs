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
	public GameObject rotationButtonPrefab;
	public GameObject HandMenuPrefab;
	public GameObject nodePrefab;
	bool onInit =true; 
	public GameObject edgePrefab;
    public List<EdgeModel> allEdges { get; set; }
    public List<Node> allNodes { get; set; }
    public List<string> filters { get; set; }
	public int currentVersion { get; set; }
    public bool Enabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public TrackingState TrackingState => throw new NotImplementedException();

    public Handedness ControllerHandedness => throw new NotImplementedException();

    public IMixedRealityInputSource InputSource => throw new NotImplementedException();

    public IMixedRealityControllerVisualizer Visualizer => throw new NotImplementedException();

    public bool IsPositionAvailable => throw new NotImplementedException();

    public bool IsPositionApproximate => throw new NotImplementedException();

    public bool IsRotationAvailable => throw new NotImplementedException();

    public MixedRealityInteractionMapping[] Interactions => throw new NotImplementedException();

    public Vector3 AngularVelocity => throw new NotImplementedException();

    public Vector3 Velocity => throw new NotImplementedException();

    public bool IsInPointingPose => throw new NotImplementedException();

    public List<EdgeModel> edges = new List<EdgeModel>();

    private const string URL_INIT = "https://test-dependencies.herokuapp.com/file/restart";
    private const string URL_UPDATE = "https://test-dependencies.herokuapp.com/file/brain";
	GameObject button;
	bool buttonPressed =false;
	void Start()
	{
		currentVersion=-1;
		allEdges = new List<EdgeModel>();
        allNodes = new List<Node>();
		// GenerateRequest();
		InvokeRepeating("GenerateRequest", 0.0f, 10.0f);
		button = Instantiate(rotationButtonPrefab, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(270,0,0)));
		MakeChangeColorOnTouch(button);
	}

	void Update(){
		if(buttonPressed){
			transform.Rotate(0,0.75f, 0, Space.World);
		}
		Vector3 pos = Camera.main.transform.position;
		button.transform.LookAt(pos);
		button.transform.position = pos + (Camera.main.transform.forward * 0.7f)+( new Vector3(0,0,0));

	}
	public void OnSourceDetected(SourceStateEventData eventData)
	{
	var hand = eventData.Controller as IMixedRealityHand;
	if (hand != null)
	{
		if (hand.TryGetJoint(TrackedHandJoint.IndexTip, out MixedRealityPose jointPose))
		{
		// ...
		}
	}
	}
	private void setButton(bool pressed){
		Color buttonColor;
		string btnText="";
		if(pressed){
			buttonColor = Color.blue;
			btnText= "Stop";
		}
		else{
			buttonColor = Color.red;
			btnText= "Rotate";
		}
		button.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(buttonColor.r,buttonColor.g,buttonColor.b,0.90f);
		button.transform.GetChild(2).GetComponent<TextMesh>().text = btnText;
	}
	public void MakeChangeColorOnTouch(GameObject targetNode)
    {
        var touchable = targetNode.AddComponent<NearInteractionTouchableVolume>();
        touchable.EventsToReceive = TouchableEventType.Pointer;
        Material material = targetNode.GetComponent<Renderer>().material;
        var pointerHandler = targetNode.AddComponent<PointerHandler>();
        pointerHandler.OnPointerDown.AddListener((e) => {
            buttonPressed=!buttonPressed;
			setButton(buttonPressed);
        });
	
    }

	public void MakeAccionOnPress(GameObject targetNode)
    {

	
    }

	public void GenerateRequest()
	{
		if(onInit){
			StartCoroutine(ProcessRequest(URL_INIT, ResponseCallback));
			onInit=false;
		}else{
			StartCoroutine(ProcessRequest(URL_UPDATE, ResponseCallback));
		}
	}

	private IEnumerator ProcessRequest(string uri, Action<RequestModel> callback = null)
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

	private void ResponseCallback(RequestModel requestModel)
	{
		if(currentVersion==-1){
			currentVersion=0;
			createNodesFromData(requestModel);
		}
		else if(requestModel.version > currentVersion)
		{
			currentVersion =requestModel.version;
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

				if (!link .visible)
				{
					edgeToUpdate.turnEdgeToSolidColor(edgeColor);
				}
				else
				{
					edgeToUpdate.turnEdgeToTranspColor(edgeColor);
				}
			}
			
		}
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

   
}

//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