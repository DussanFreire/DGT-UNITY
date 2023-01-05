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
    public List<string> filters { get; set; }
	public int currentVersion { get; set; }
	public float size { get; set; }

	void Start()
	{
		currentVersion=-1;
        NodesManager.AllNodes = new List<Node>();
        EdgesManager.AllEdges = new List<Edge>();
		InvokeRepeating("GenerateRequest", 0.0f, 3.0f);
	}

	void Update(){
		RorationManager.setRotationListeners(transform);
		PositionManager.setMovementListeners(transform);
	}


	public void GenerateRequest()
	{
		if(!graphBuilded){
			StartCoroutine(RequestsManager.ProcessRequestGet(Enviroment.URL_INIT, ResponseCallback));
			graphBuilded=true;
		}else{
			StartCoroutine(RequestsManager.ProcessRequestPost(Enviroment.URL_UPDATE, ResponseCallback));
		}
	}

	private void ResponseCallback(RequestDto requestModel)
	{
		if(currentVersion==-1){
			currentVersion=0;
			createNodesFromData(requestModel);
		}
		else if(requestModel.version > currentVersion)
		{
			currentVersion =requestModel.version;
			if(size!=requestModel.size){
				deleteGraph();
				createNodesFromData(requestModel);
			}
			else
			updateNodesFromData(requestModel);
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
			if (nodeRequest.visible){
				nodeToUpdate.showTextLabel();
				nodeToUpdate.turnToSolidColor();
			} else {
				nodeToUpdate.hideTextLabel();
				nodeToUpdate.turnToTranspColor();
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
			if (nodeRequest.visible){
				node.turnToSolidColor();
			} else {
				node.turnToTranspColor();
			}
			return node;
	}

	private void createNodesFromData(RequestDto RequestModel)
	{
		size =RequestModel.size;
		foreach (NodeRequestDto nodeRequest in RequestModel.nodes)
		{
			Node node = generateNode(nodeRequest);
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
	void deleteGraph(){
	
		
		NodesManager.AllNodes.ForEach(n=>{
			Destroy(n.nodeGameObject);
		});
		NodesManager.AllNodes = new List<Node>();
		EdgesManager.AllEdges = new List<Edge>();

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