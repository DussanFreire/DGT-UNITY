using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

public class Graph : MonoBehaviour
{
	public GameObject nodePrefab;
	GameObject arrowObject;
	bool onInit =true;
	public GameObject edgePrefab;
	public List<Arrow> arrows;
    public List<EdgeModel> allEdges { get; set; }
    public List<Node> allNodes { get; set; }
    public List<string> filters { get; set; }

    private const string URL_INIT = "https://test-dependencies.herokuapp.com/file/restart";
    private const string URL_UPDATE = "https://test-dependencies.herokuapp.com/file/brain";

	// Start is called before the first frame update
	void Start()
	{
		allEdges = new List<EdgeModel>();
        allNodes = new List<Node>();
		GenerateRequest();
		// InvokeRepeating("GenerateRequest", 0.0f, 10.0f);
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
		if(requestModel.version == 0){
			createNodesFromData(requestModel);
		}
		else
		{
			updateNodesFromData(requestModel);
		}
	}

    private void updateNodesFromData(RequestModel requestModel)
    {
		foreach (NodeRequestModel nodeRequest in requestModel.nodes)
		{
			Node nodeToUpdate = allNodes.Find(n=>n.id == nodeRequest.id);
			Color color;
            if (ColorUtility.TryParseHtmlString(nodeRequest.color, out color))
			{
				nodeToUpdate.node.GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b);
			}
			nodeToUpdate.visible = nodeRequest.visible;
			if(nodeToUpdate.visible){
				nodeToUpdate.setColor(color);
			}else{
				nodeToUpdate.node.GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b,0.25f);
			}
		}

		foreach (Node node in allNodes)
		{
			List<Link> links = getEdges(node.id, requestModel);
			if (links.Count > 0)
			{
				foreach (Link link in links)
				{
					EdgeModel edgeToUpdate=  allEdges.Find(e=>e.target==link.target&& e.origin ==link.source);
					edgeToUpdate.visible = link.visible;
				}
			}
        }
		for (int i = 0; i < this.allEdges.Count; i++)
        {
			if (!this.allEdges[i].visible)
			{
				Color edgeColor = getColor(EdgeColorModel.regularEdge);
            	this.allEdges[i].edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b,0.25f);
            	this.allEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b, 0.25f);
			}
			else
			{
				Color edgeColor = getColor(EdgeColorModel.regularEdge);
            	this.allEdges[i].edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b);
            	this.allEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b);
			}
           
        }
    }

    private float getNumber(float source, float target, float magnitud)
	{
		float x = target - source;
		x = (Math.Abs(x) - (Math.Abs(x) * (100 * 0.0003f) / magnitud)) * (target < source ? -1.0f : 1.0f);
		return target - x;
	}

	private float getNumberArrow(float source, float target, float magnitud)
	{
		float x = target - source;
		x = (Math.Abs(x) - (Math.Abs(x) * (100 * 0.0009f) / magnitud)) * (target < source ? -1.0f : 1.0f);
		return target - x;
	}
	private double getVectorMagnitud(NodeRequestModel target, NodeRequestModel source)
	{
		return Math.Sqrt(Math.Pow((target.x - source.x), 2) + Math.Pow((target.y - source.y), 2) + Math.Pow((target.z - source.z), 2));
	}

	private void createNodesFromData(RequestModel RequestModel)
	{
		List<NodeGameObjModel> nodeGameObjList = new List<NodeGameObjModel>();
		allNodes = new List<Node>();

		foreach (NodeRequestModel nodeRequest in RequestModel.nodes)
		{
			NodeGameObjModel nodeGameObj = new NodeGameObjModel();
			Node node = new Node();
			Color color;
			nodeGameObj.node = Instantiate(nodePrefab, new Vector3(nodeRequest.x, nodeRequest.y, nodeRequest.z), Quaternion.identity);
			nodeGameObj.id = nodeRequest.id;
			nodeGameObj.node.transform.parent = transform;
			nodeGameObj.node.name = nodeRequest.name;
			filters = nodeRequest.filters;

            if (ColorUtility.TryParseHtmlString(nodeRequest.color, out color))
			{
				nodeGameObj.node.GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b);
			}
			nodeGameObjList.Add(nodeGameObj);
			node.visible = nodeRequest.visible;
			node = nodeGameObj.node.GetComponent<Node>();
			node.setNode(nodeGameObj.node);
			if(nodeRequest.visible){
				node.setColor(color);
			}else{
				nodeGameObj.node.GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b,0.25f);
			}
			node.id = nodeGameObj.id;
			node.setChildIds(nodeRequest.childIds);
            node.setColors(RequestModel.edgeColors, RequestModel.nodeColors);
			allNodes.Add(node);
			List<Arrow> arrs = new List<Arrow>();
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
			if (!this.allEdges[i].visible)
			{
				Color edgeColor = getColor(EdgeColorModel.regularEdge);
            	this.allEdges[i].edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b,0.25f);
            	this.allEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b, 0.25f);
			}
			else
			{
				Color edgeColor = getColor(EdgeColorModel.regularEdge);
            	this.allEdges[i].edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b);
            	this.allEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b);
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
