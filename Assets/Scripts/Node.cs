using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using System;

public class Node : MonoBehaviour
{

    public List<EdgeModel> allEdges { get; set; }
    public List<Node> allNodes { get; set; }
    public int id;
    public bool visible { get; set; }
    public GameObject edgePrefab;
    public GameObject node;
    public Color nodeColor;
    public EdgeColorModel edgeColors;
    public NodeColorModel nodeColors;
    public List<int> childIds;
    public List<EdgeModel> edges = new List<EdgeModel>();
    public List<EdgeModel> edgesParent = new List<EdgeModel>();
    public List<SpringJoint> joints = new List<SpringJoint>();
    public List<Node> nodeParent = new List<Node>();

    public List<Node> nodeChildren = new List<Node>();
    
    bool clicked = false;
    GameObject textBackground;
    // Start is called before the first frame update
    void Start()
    {
        //Assigns the transform of the first child of the Game Object and Set the text
        textBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
        textBackground.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        textBackground.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        textBackground.transform.rotation = Camera.main.transform.rotation;
        textBackground.GetComponent<MeshRenderer>().material.color = Color.black;
        transform.GetChild(0).GetComponent<TextMesh>().text = "";
        startConfiguration();
        MakeChangeColorOnTouch(node);

    }

    // Update is called once per frame
    void Update()
    {
        if (clicked) {
            Vector3 pos = Camera.main.transform.position;
            transform.GetChild(0).LookAt(pos);
            Vector3 rotation = transform.GetChild(0).rotation.eulerAngles;
            transform.GetChild(0).Rotate(0, 180, 0);
            textBackground.transform.LookAt(pos);
        }
    }


    public void startConfiguration()
    {
        int i = 0;
        foreach (EdgeModel edge in edges)
        {
            edge.edge.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            SpringJoint sj = joints[i];
            GameObject target = sj.connectedBody.gameObject;
            edge.edge.transform.LookAt(target.transform);
            Vector3 ls = edge.edge.transform.localScale;
            ls.z = Vector3.Distance(transform.position, target.transform.position);
            edge.edge.transform.localScale = ls;
            edge.edge.transform.position = new Vector3((transform.position.x + target.transform.position.x) / 2,
                            (transform.position.y + target.transform.position.y) / 2,
                            (transform.position.z + target.transform.position.z) / 2);
            i++;
        }
    }

    public void SetEdgePrefab(GameObject edgePrefab)
    {
        this.edgePrefab = edgePrefab;
    }

    public void setNode(GameObject node)
    {
        this.node = node;
    }

    public void setColor(Color color)
    {

        this.nodeColor = new Color(color.r,color.g,color.b,0.25f);
    }

    public void turnToSolidColor(){
        this.node.GetComponent<Renderer>().material.color =  this.nodeColor;
    }
    public void turnToTranspColor(){
        this.node.GetComponent<Renderer>().material.color = new Color(nodeColor.r,nodeColor.g,nodeColor.b,0.25f);
    }
    public void turnEdgeToSolidColor(GameObject edgeToUpdate, Color edgeColor){
        edgeToUpdate.GetComponent<Renderer>().material.color = edgeColor;
        edgeToUpdate.transform.GetChild(0).GetComponent<Renderer>().material.color = edgeColor;
    }

    public void turnEdgeToTranspColor(GameObject edgeToUpdate, Color edgeColor){
        edgeToUpdate.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b,0.25f);
        edgeToUpdate.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b, 0.25f);
    }
    
    
    public void setColors(EdgeColorModel edgeColor, NodeColorModel nodeColor)
    {
        this.edgeColors = edgeColor;
        this.nodeColors = nodeColor;
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

    public void setEdgestoParents(List<EdgeModel> edges)
    {
        this.edgesParent = edges;
    }

    public void resetColor()
    {
        this.node.GetComponent<Renderer>().material.color = getColor(NodeColorModel.pasiveNode);
    }

    public EdgeModel AddEdge(Node node, int sourceId)
    {
        //Adds fixed joint to the game object 
        SpringJoint SpringJoint = gameObject.AddComponent<SpringJoint>();
        //Should the connectedAnchor be calculated automatically
        SpringJoint.autoConfigureConnectedAnchor = false;
        //The Position of the anchor around which the joints motion is constrained.
        SpringJoint.anchor = new Vector3(0, 0.0005f, 0);
        //Position of the anchor relative to the connected Rigidbody.
        SpringJoint.connectedAnchor = new Vector3(0, 0, 0);
        //Enable collision between bodies connected with the joint.
        SpringJoint.enableCollision = true;
        //A reference to another rigidbody this joint connects to.
        SpringJoint.connectedBody = node.GetComponent<Rigidbody>();
        //Clones the object original and returns the clone.object, posotion for the new object,quaternion corresponds to "no rotation" the object is perfectly aligned with parent axes.
        GameObject edge = Instantiate(this.edgePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        EdgeModel edgeModel = new EdgeModel();
        edgeModel.origin = sourceId;
        edgeModel.target = node.id;
        edgeModel.edge = edge;
        edges.Add(edgeModel);
        joints.Add(SpringJoint);
        return edgeModel;
    }

    private Color getColor(string colorHex)
    {
        Color color;
        ColorUtility.TryParseHtmlString(colorHex, out color);
        return color;
    }


    public Color getColorByIntensity(int intensity)
    {
        switch (intensity)
        {
            case 1:
                return getColor(EdgeColorModel.nearEdge);
            case 2:
                return getColor(EdgeColorModel.farEdge);
            default:
                return getColor(EdgeColorModel.farAwayEdge);
        }
    }

    public bool isValidColor(int intensityOfColor)
    {
        Color currentColor = node.GetComponent<Renderer>().material.color;
        Color possibleColor = getColorByIntensity(intensityOfColor+1);
        int currentColorValue = getColorValue(currentColor);
        int possibleColorValue = getColorValue(possibleColor);
        return possibleColorValue <= currentColorValue;

    }
    public int  getColorValue(Color possibleColor)
    {
        Color firstColor = getColorByIntensity(1);
        Color secondColor = getColorByIntensity(2);
        Color thirdColor = getColorByIntensity(3);
        if (firstColor == possibleColor)
            return 1;
        if (secondColor == possibleColor)
            return 2;
        if (thirdColor == possibleColor)
            return 3;

        return 0;

    }


    void changeColor(Node currentNode,Material material){
        material.color = getColor(NodeColorModel.activeNode);
        showTextLabel(currentNode, Color.white);
        List<Node> childrenNode = new List<Node>();
        for (int i = 0; i < this.allEdges.Count; i++)
        {
            if(allEdges[i].origin ==currentNode.id || allEdges[i].target ==currentNode.id){
                Color edgeColor = getColor(NodeColorModel.activeNode);
                this.allEdges[i].edge.GetComponent<Renderer>().material.color = edgeColor;
                this.allEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color =edgeColor;
            }
            if(allEdges[i].origin ==currentNode.id ){
                Color nodeColor = getColor(EdgeColorModel.nearEdge);
                Node node = this.allNodes.Find(n=>n.id==allEdges[i].target);
                node.node.GetComponent<Renderer>().material.color =nodeColor;
                node.showTextLabel(node,nodeColor);
                childrenNode.Add(node);
            }
            if(allEdges[i].target ==currentNode.id ){
                Color nodeColor = getColor(EdgeColorModel.nearEdge);
                Node node = this.allNodes.Find(n=>n.id==allEdges[i].origin);
                node.node.GetComponent<Renderer>().material.color =nodeColor;
                node.showTextLabel(node,nodeColor);
                childrenNode.Add(node);
            }
        }

        for (int i = 0; i < childrenNode.Count; i++)
        {
            List<EdgeModel> childEdges = this.allEdges.FindAll(e=> (childrenNode[i].id ==e.origin|| e.target ==childrenNode[i].id)&&(e.origin != currentNode.id &&e.target != currentNode.id));
            for (int j = 0; j < childEdges.Count; j++)
            {
                Color edgeColor = getColor(EdgeColorModel.nearEdge);
                childEdges[j].edge.GetComponent<Renderer>().material.color = edgeColor;
                childEdges[j].edge.transform.GetChild(0).GetComponent<Renderer>().material.color =edgeColor;

                if(childEdges[j].origin == childrenNode[i].id ){
                    Color nodeColor = getColor(EdgeColorModel.farEdge);
                    Node node = this.allNodes.Find(n=>n.id==childEdges[j].target);
                    node.node.GetComponent<Renderer>().material.color = nodeColor;
                    node.showTextLabel(node,nodeColor);
                }
                if(childEdges[j].target ==childrenNode[i].id ){
                    Color nodeColor = getColor(EdgeColorModel.farEdge);
                    Node node = this.allNodes.Find(n=>n.id==childEdges[j].origin);
                    node.node.GetComponent<Renderer>().material.color =nodeColor;
                    node.showTextLabel(node,nodeColor);
                }
            }
        }
    }
    void resetAllLabels()
    {
        for (int i = 0; i < this.allNodes.Count; i++)
        {
            hideTextLabel(this.allNodes[i]);
        }
    }
    

    public void MakeChangeColorOnTouch(GameObject targetNode)
    {
        var touchable = targetNode.AddComponent<NearInteractionTouchableVolume>();
        touchable.EventsToReceive = TouchableEventType.Pointer;
        Material material = targetNode.GetComponent<Renderer>().material;
        var pointerHandler = targetNode.AddComponent<PointerHandler>();
        pointerHandler.OnPointerDown.AddListener((e) => {
            resetAllLabels();
            turnTranspAllNodes();
            turnTranspAllEdges();

            changeColor(this,material);

        });
    }

    private void turnTranspAllEdges()
    {
        for (int i = 0; i < this.allEdges.Count; i++)
        {
            this.allEdges[i].intensityOfColor = 0;
            Color edgeColor = getColor(EdgeColorModel.regularEdge);
            this.allEdges[i].edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b,0.25f);
            this.allEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b, 0.25f);
        }
    }

    private void turnTranspAllNodes()
    {
        for (int i = 0; i < this.allNodes.Count; i++)
        {
            this.allNodes[i].node.GetComponent<Renderer>().material.color =  this.allNodes[i].nodeColor;
        }
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

    public void showTextLabel(Node nodo, Color textColor,bool normalSize=true)
    {
        float textSize = normalSize ? 0.7f: 0.5f;
        float height = normalSize ? 0.03f : 0.02f;
        float heightAddition = normalSize ? 0.015f : 0.009f;


        nodo.transform.GetChild(0).GetComponent<TextMesh>().text = nodo.name;
        nodo.transform.GetChild(0).GetComponent<TextMesh>().characterSize = textSize;
        nodo.transform.GetChild(0).GetComponent<TextMesh>().color = textColor;

        Vector3 backgroudPos = nodo.transform.GetChild(0).position;

        nodo.textBackground.transform.localPosition = new Vector3(backgroudPos.x,backgroudPos.y- heightAddition, backgroudPos.z);

        float width = getWidth(nodo.name, textSize);
        nodo.textBackground.transform.localScale = new Vector3(width, height, 0.001f);
        nodo.textBackground.transform.LookAt(Camera.main.transform.position);
        nodo.textBackground.GetComponent<MeshRenderer>().material.color = Color.black;
        nodo.clicked = true;
    }
    public void hideTextLabel(Node nodo)
    {
        nodo.clicked = false;
        nodo.transform.GetChild(0).GetComponent<TextMesh>().text = "";
        nodo.textBackground.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }
}

