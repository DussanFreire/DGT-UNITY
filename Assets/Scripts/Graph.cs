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

	public GameObject edgePrefab;
	public List<Arrow> arrows;
    public List<EdgeModel> allEdges { get; set; }
    public List<Node> allNodes { get; set; }
    public List<string> filters { get; set; }

    private const string URL = "https://test-dependencies.herokuapp.com/file/brain";

	// Start is called before the first frame update
	void Start()
	{
		allEdges = new List<EdgeModel>();
        allNodes = new List<Node>();
        GenerateRequest();
	}



	public void GenerateRequest()
	{
		StartCoroutine(ProcessRequest(URL, ResponseCallback));
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

	private void ResponseCallback(RequestModel RequestModel)
	{
		createNodesFromData(RequestModel);
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
			node = nodeGameObj.node.GetComponent<Node>();
			node.setNode(nodeGameObj.node);
			node.setColor(color);
			node.id = nodeGameObj.id;
			node.setChildIds(nodeRequest.childIds);
            node.setColors(RequestModel.edgeColors, RequestModel.nodeColors);
			allNodes.Add(node);
			List<Arrow> arrs = new List<Arrow>();
			foreach (Link link in nodeRequest.links)
			{
				NodeRequestModel nodeTarget = RequestModel.nodes.Find(n => n.id == link.target);
				float magnitud = (float)getVectorMagnitud(nodeTarget, nodeRequest);
				arrs = node.generateCube(new Vector3(getNumber(nodeRequest.x, nodeTarget.x, magnitud), getNumber(nodeRequest.y, nodeTarget.y, magnitud), getNumber(nodeRequest.z, nodeTarget.z, magnitud)), link.source, link.target);
			}
			foreach (Arrow aux in arrs)
			{
				arrows.Add(aux);
			}
		}

		foreach (Node node in allNodes)
		{
			List<Link> links = getEdges(node.id, RequestModel);
			if (links.Count > 0)
			{
				node.SetEdgePrefab(edgePrefab);
				// Vector3 scale = node.edgePrefab.transform.GetChild(0).localScale;
				// scale.z =0.0025f;
				// node.edgePrefab.transform.GetChild(0).localScale = scale;
				setEdges(node, links, allNodes);
			}
			node.allArrows = arrows;
        }
		// foreach (NodeRequestModel nodeRequest in RequestModel.nodes)
		// {
		// 	foreach (Link link in nodeRequest.links)
		// 	{
		// 		Node node  = getNodeById(nodeRequest.id, allNodes);
		// 		NodeRequestModel nodeTarget = RequestModel.nodes.Find(n => n.id == link.target);
		// 			Vector3 scale = node.edgePrefab.transform.GetChild(0).localScale;
		// 		float magnitud = (float)getVectorMagnitud(nodeTarget, nodeRequest);
		// 		scale.z =0.0025f;
		// 		node.edgePrefab.transform.GetChild(0).localPosition=new Vector3(getNumberArrow(nodeRequest.x, nodeTarget.x, magnitud), getNumberArrow(nodeRequest.y, nodeTarget.y, magnitud), getNumberArrow(nodeRequest.z, nodeTarget.z, magnitud));
		// 	}
		// }
        foreach (Node node in allNodes)
        {

            setNodeParents(node, allNodes);
            setNodeChildren(node, allNodes);
			node.allEdges = allEdges;
			node.allNodes = allNodes;
        }
    }

	private void setEdges(Node node, List<Link> links, List<Node> nodeList)
	{
		foreach (Link link in links)
		{
			Node targetNode = getNodeById(link.target, nodeList);

            EdgeModel edgeAdded =  node.AddEdge(targetNode, link.source);
			allEdges.Add(edgeAdded);
		}
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
