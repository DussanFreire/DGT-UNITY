using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class Node : MonoBehaviour,IMixedRealityFocusHandler
{

    public List<EdgeModel> allEdges { get; set; }
    public List<Node> allNodes { get; set; }
    public int id;
    public bool visible { get; set; }
    public GameObject edgePrefab;
    public GameObject node;
    public Color nodeColor;
    public List<int> childIds;
    public List<EdgeModel> edges = new List<EdgeModel>();
    public List<EdgeModel> edgesParent = new List<EdgeModel>();
    public List<SpringJoint> joints = new List<SpringJoint>();
    public List<Node> nodeParent = new List<Node>();
    public bool colorChangedByTest =false;
    public bool colorChangedByHover =false;
    public List<Node> nodeChildren = new List<Node>();
    
    bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetChild(0).localScale = new Vector3(0.0f, 0.0f, 0.0f);
        transform.GetChild(0).GetComponent<TextMesh>().text = "";
        startConfiguration();
        MakeChangeColorOnTouch(node);
        
        PointerUtils.SetGazePointerBehavior(PointerBehavior.AlwaysOn);

    }

    // Update is called once per frame
    void Update()
    {
        if (clicked || colorChangedByHover||colorChangedByHover) {
            Vector3 pos = Camera.main.transform.position;
            transform.GetChild(0).LookAt(pos);
            Vector3 rotation = transform.GetChild(0).rotation.eulerAngles;
            transform.GetChild(0).Rotate(0, 180, 0);
            transform.GetChild(0).GetChild(0).transform.LookAt(pos);
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
            edges[i].edge.transform.parent =transform;
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
        this.node = node;
    }

    public void setColor(Color color)
    {

        this.nodeColor = new Color(color.r,color.g,color.b);
    }

    public void turnToSolidColor(){
        this.node.GetComponent<Renderer>().material.color =  this.nodeColor;
    }
    public void turnToTranspColor(){
        this.node.GetComponent<Renderer>().material.color = new Color(nodeColor.r,nodeColor.g,nodeColor.b,0.25f);
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
        currentNode.turnToSolidColor();
        showTextLabel(currentNode, currentNode.nodeColor);
        List<Node> childrenNode = new List<Node>();
        for (int i = 0; i < this.allEdges.Count; i++)
        {
            if(allEdges[i].origin ==currentNode.id){
                this.allEdges[i].edge.GetComponent<Renderer>().material.color = currentNode.nodeColor;
                this.allEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color =currentNode.nodeColor;
                Node node = this.allNodes.Find(n=>n.id==allEdges[i].target);
                node.turnToSolidColor();
                node.showTextLabel(node,node.nodeColor);
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
        var touchHandler = targetNode.AddComponent<TouchHandler>();
        var focusHandler = targetNode.AddComponent<FocusHandler>();
        pointerHandler.OnPointerDown.AddListener((e) => {
            resetAllLabels();
            turnTranspAllNodes();
            turnTranspAllEdges();
            changeColor(this,material); 
            foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
            {
                if(gameObj.name == "Cylinder")
                {
                    Material thisObj = gameObj.GetComponent<Renderer>().material;
                    Color objColor =thisObj.color;
                    float tranpsDensity= 0.25f;
                    thisObj.color = new Color(objColor.r,objColor.g,objColor.b, tranpsDensity);
                }
            }
        });
        touchHandler.OnTouchCompleted.AddListener((e) => {
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
            allNodes[i].colorChangedByTest =false;
            allNodes[i].colorChangedByHover =false;
            allNodes[i].turnToTranspColor();
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


        nodo.transform.GetChild(0).GetComponent<TextMesh>().text = nodo.name;
        nodo.transform.GetChild(0).GetComponent<TextMesh>().characterSize = textSize;
        nodo.transform.GetChild(0).GetComponent<TextMesh>().color = textColor;



        float width = getWidth(nodo.name, textSize);
        nodo.transform.GetChild(0).GetChild(0).transform.localScale = new Vector3(width*50, height*30, 0.001f);
        nodo.transform.GetChild(0).GetChild(0).transform.LookAt(Camera.main.transform.position);
        Color bl = Color.black;
        nodo.transform.GetChild(0).GetChild(0).transform.GetComponent<Renderer>().material.color = new Color(bl.r,bl.g,bl.b,0.45f);
        nodo.clicked = true;
    }
    public void hideTextLabel(Node nodo)
    {
        nodo.clicked = false;
        nodo.transform.GetChild(0).GetComponent<TextMesh>().text = "";
        nodo.transform.GetChild(0).GetChild(0).transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        if(!colorChangedByHover && !clicked && !colorChangedByTest){
            showTextLabel(this, this.nodeColor);
            clicked = false;
            colorChangedByHover=true;
        }
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        if(colorChangedByHover && !clicked && !colorChangedByTest){
            colorChangedByHover=false;
            hideTextLabel(this);
        }
    }
}

