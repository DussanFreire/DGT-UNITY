using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;

public class Node : MonoBehaviour,IMixedRealityFocusHandler
{
    public Transform graphtransf { get; set; }
    public int id;
    public bool visible { get; set; }
    public GameObject edgePrefab;
    public GameObject nodeGameObject;
    public Color nodeColor;
    public List<int> childIds;
    public List<Edge> edges = new List<Edge>();
    public List<Edge> parentEdges = new List<Edge>();
    public List<SpringJoint> joints = new List<SpringJoint>();
    public List<Node> nodeParent = new List<Node>();
    public bool colorChangedByHover =false;
    public List<Node> nodeChildren = new List<Node>();

    public bool clicked = false;
    void Start()
    {
        transform.GetChild(0).GetChild(0).localScale = new Vector3(0.0f, 0.0f, 0.0f);
        transform.GetChild(0).GetComponent<TextMesh>().text = "";
        startConfiguration();

        ColorsManager.SetColorsListener(this, nodeGameObject);
    }
    void Update()
    {
        if (clicked || colorChangedByHover) {
            Vector3 pos = Camera.main.transform.position;
            transform.LookAt(pos);
        }
    }
    public void OnFocusEnter(FocusEventData eventData)
    {
        
        if(eventData.Pointer.PointerName!="Gaze Pointer" && !colorChangedByHover && !clicked){
            MetricsManager.hoverUsed++;
            this.showTextLabel();

            addAction("Hover");
            clicked = false;
            colorChangedByHover=true;
        }
    }

    public void addAction(string action){
        if(!MetricsManager.actionsDone.Exists(a=> {return a.fileName==this.name && a.action==action;})){
            NodeActionDto aux = new NodeActionDto();
            aux.setData(this.name,action,1);
            MetricsManager.actionsDone.Add(aux);
        }else{
            if(MetricsManager.actionsDone.Exists(a=> {return a.fileName==this.name && a.action==action;})){
                NodeActionDto aux = MetricsManager.actionsDone.Find(a=> {return a.fileName==this.name && a.action==action;});
                aux.qty++;
            }
        };
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        if(colorChangedByHover && !clicked){
            colorChangedByHover=false;
            this.hideTextLabel();
        }
    }
    public void startConfiguration()
    {
        for (int i = 0; i < edges.Count; i++)
        {
            GameObject target = joints[i].connectedBody.gameObject;
            edges[i].edge.transform.LookAt(target.transform);
            Vector3 ls = edges[i].edge.transform.localScale;
            ls.z = Vector3.Distance(transform.position, target.transform.position);
            edges[i].edge.transform.localScale = ls;
            edges[i].edge.transform.position = calcDimPos(transform.position,target.transform.position);
            edges[i].edge.transform.parent =graphtransf;
            
        }
    }
    private Vector3 calcDimPos(Vector3 source, Vector3 target){
        return new Vector3((source.x + target.x) / 2,
                            (source.y + target.y) / 2,
                            (source.z + target.z) / 2);
    }

    public void SetEdgePrefab(GameObject edgePrefab)
    {
        this.edgePrefab = edgePrefab;
    }
    public void setNode(GameObject node)
    {
        this.nodeGameObject = node;
    }
    public void setColor(Color color)
    {

        this.nodeColor = new Color(color.r,color.g,color.b);
    }
    public void turnToSolidColor(){
        this.nodeGameObject.GetComponent<Renderer>().material.color =  this.nodeColor;
    }
    public void turnToTranspColor(){
        this.nodeGameObject.GetComponent<Renderer>().material.color = new Color(nodeColor.r,nodeColor.g,nodeColor.b,Enviroment.TRANSP_DENSITY);
    }
    public void setChildIds(List<int> childIds)
    {
        this.childIds = childIds;
    }
    public void addNodeParents(List<Node> node)
    {
        this.nodeParent = node;
    }
    public void setNodeChildren(List<Node> node)
    {
        this.nodeChildren = node;
    }
    public void setEdgestoParents(List<Edge> edges)
    {
        this.parentEdges = edges;
    }
    public Edge AddEdge(Node node, int sourceId)
    {
        SpringJoint springJoint = gameObject.AddComponent<SpringJoint>();
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.anchor = new Vector3(0, 0.0005f, 0);
        springJoint.connectedAnchor = new Vector3(0, 0, 0);
        springJoint.enableCollision = true;
        springJoint.connectedBody = node.GetComponent<Rigidbody>();
        GameObject edge = Instantiate(this.edgePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Edge currentEdge = new Edge();
        currentEdge.origin = sourceId;
        currentEdge.target = node.id;
        currentEdge.edge = edge;
        edges.Add(currentEdge);
        joints.Add(springJoint);
        return currentEdge;
    }
    public  float getWidth(string nodoName, float characterSize)
    {
        TextMesh mesh = transform.GetChild(0).GetComponent<TextMesh>();
        float width = 0;
        foreach (char symbol in nodoName)
        {
            CharacterInfo info;
            if (mesh.font.GetCharacterInfo(symbol, out info))
            {
                width += info.width;
            }
        }
        return (width * characterSize * 0.1f * mesh.transform.lossyScale.x) + 0.01f;
    }
    public void showTextLabel()
    {
        this.transform.GetChild(0).GetComponent<TextMesh>().text = this.name;
        this.transform.GetChild(0).GetComponent<TextMesh>().characterSize = Enviroment.TEXT_SIZE;
        this.transform.GetChild(0).GetComponent<TextMesh>().color = this.nodeColor;

        float width = getWidth(this.name, Enviroment.TEXT_SIZE);
        this.transform.GetChild(0).GetChild(0).transform.localScale = new Vector3(width*80*(2-NodesManager.NodeSize), Enviroment.TEXT_BG_HEIGHT*30, 0.01f);
        Color bl = Color.black;
        this.transform.GetChild(0).GetChild(0).transform.GetComponent<Renderer>().material.color = new Color(bl.r,bl.g,bl.b,0.80f);

        this.clicked = true;
    }
    public void hideTextLabel()
    {
        this.clicked = false;
        this.transform.GetChild(0).GetComponent<TextMesh>().text = "";
        this.transform.GetChild(0).GetChild(0).transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }
}

