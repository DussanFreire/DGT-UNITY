using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class Node : MonoBehaviour
{

    public List<Arrow> allArrows { get; set; }
    public List<EdgeModel> allEdges { get; set; }
    public List<Node> allNodes { get; set; }
    public List<Arrow> arrows;
    public int id;
    public GameObject edgePrefab;
    public GameObject node;
    public Color color;
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
        transform.GetChild(1).GetComponent<TextMesh>().text = ""; //nodo
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
    public List<Arrow> generateCube(Vector3 position, int idSource, int idTarget)
    {

        GameObject arrowObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        arrowObject.transform.rotation = Quaternion.LookRotation(position);
        arrowObject.transform.localPosition = position;
        arrowObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        arrowObject.GetComponent<MeshRenderer>().material.color = getColor(EdgeColorModel.regularEdge);
        Arrow arr = new Arrow();
        arr.arr = arrowObject;
        arr.source = idSource;
        arr.target = idTarget;
        arrows.Add(arr);
        return arrows;
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
        this.color = color;
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

    public void setColors(EdgeColorModel edgeColor, NodeColorModel nodeColor)
    {
        this.edgeColors = edgeColor;
        this.nodeColors = nodeColor;
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


    /*  public bool isPaintable(int intensityOfColor)
      {
          return (node.GetComponent<Renderer>().material.color == color) || isValidColor(intensityOfColor);
      } 

      public void addRecursiveColor(Node currentNode, int idOrigin,int baseIntensity )
      {
          if (baseIntensity <= 1)
              changeArrowColor(currentNode,getColor(EdgeColorModel.farEdge));
          if (currentNode.GetComponent<Renderer>().material.color == getColorByIntensity(childEdge.intensityOfColor))
              return;
          foreach (EdgeModel childEdge in currentNode.edges)
          {
              if (currentNode.nodeChildren.Exists(n => n.id == childEdge.target && n.id != idOrigin && n.isPaintable(baseIntensity)))
              {
                  Node childNode = currentNode.nodeChildren.Find(n => n.id == childEdge.target && n.id != idOrigin && n.isPaintable(baseIntensity));
                  childEdge.intensityOfColor = baseIntensity + 1;
                  Color colorRequired = getColorByIntensity(childEdge.intensityOfColor);
                  showTextLabel(childNode, colorRequired, false);
                  childNode.node.GetComponent<Renderer>().material.color = colorRequired;
                  childEdge.edge.GetComponent<Renderer>().material.color = colorRequired;
                  addRecursiveColor(childNode, idOrigin, childEdge.intensityOfColor);
              }
          }

          foreach (EdgeModel parentEdge in currentNode.edgesParent)
           {
              if (currentNode.nodeParent.Exists(n => n.id == parentEdge.origin && n.id != idOrigin && n.isPaintable(baseIntensity)))
              {
                  Node parentNode = currentNode.nodeParent.Find(n => n.id == parentEdge.origin && n.id != idOrigin && n.isPaintable(baseIntensity));
                  parentEdge.intensityOfColor = baseIntensity + 1;
                  Color colorRequired = getColorByIntensity(parentEdge.intensityOfColor);
                  showTextLabel(parentNode, colorRequired, false);
                  parentNode.node.GetComponent<Renderer>().material.color = colorRequired;
                  parentEdge.edge.GetComponent<Renderer>().material.color = colorRequired;
                  addRecursiveColor(parentNode, idOrigin, parentEdge.intensityOfColor);
              }
           }
      }*/
    public void addRecursiveColor(Node currentNode, int idOrigin, int baseIntensity)
    {
        if (baseIntensity >= 2)
            return;
        else
            changeArrowColor(currentNode, getColor(EdgeColorModel.farEdge));
        foreach (EdgeModel child in currentNode.edges)
       {
            if (currentNode.nodeChildren.Exists(n => n.id == child.target && n.id != idOrigin))
            {
                Node childNode = currentNode.nodeChildren.Find(n => n.id == child.target);
                child.intensityOfColor = baseIntensity + 1;
                Color colorRequired = getColorByIntensity(child.intensityOfColor);
                childNode.node.GetComponent<Renderer>().material.color = colorRequired;
                showTextLabel(childNode, colorRequired, false);
                child.edge.GetComponent<Renderer>().material.color = colorRequired;
                addRecursiveColor(childNode, idOrigin, child.intensityOfColor);
            }
        }

        foreach (EdgeModel parent in currentNode.edgesParent)
        {

            if (currentNode.nodeParent.Exists(n => n.id == parent.origin && n.id != idOrigin))
           {
                Node parentNode = currentNode.nodeParent.Find(n => n.id == parent.origin);
                parent.intensityOfColor = baseIntensity + 1;
                Color colorRequired = getColorByIntensity(parent.intensityOfColor);
                showTextLabel(parentNode, colorRequired, false);
                parentNode.node.GetComponent<Renderer>().material.color = colorRequired;
                parent.edge.GetComponent<Renderer>().material.color = colorRequired;
                addRecursiveColor(parentNode, idOrigin, parent.intensityOfColor);
           }
       }
    }

    public void resetActiveEdgesColors(Node currentNode)
    {
        currentNode.node.GetComponent<Renderer>().material.color = currentNode.color;
        foreach (EdgeModel child in currentNode.edges)
        {
            if (child.intensityOfColor != 0 )
            {

                if (currentNode.nodeChildren.Exists(n => n.id == child.target && n.node != null))
                {
                    Node childNode = currentNode.nodeChildren.Find(n => n.id == child.target);
                    child.intensityOfColor = 0;
                    child.edge.GetComponent<Renderer>().material.color = getColor(EdgeColorModel.regularEdge);
                    hideTextLabel(childNode);
                    resetActiveEdgesColors(childNode);

                }

            }
        }

        foreach (EdgeModel parent in currentNode.edgesParent)
        {
            if (parent.intensityOfColor != 0)
            {
                if(currentNode.nodeParent.Exists(n => n.id == parent.origin && n.node != null))
                {
                    Node parentNode = currentNode.nodeParent.Find(n => n.id == parent.origin);
                    parent.intensityOfColor = 0;
                    parent.edge.GetComponent<Renderer>().material.color = getColor(EdgeColorModel.regularEdge);
                    resetActiveEdgesColors(parentNode);
                    hideTextLabel(parentNode);

                }
             
            }
        }
    }


    void resetAllEdges(Node CuerrentNode)
    {
        for (int i = 0; i < CuerrentNode.allEdges.Count; i++)
        {
            if(CuerrentNode.allEdges[i].intensityOfColor != 0)
            {
                EdgeModel edgeActive = CuerrentNode.allEdges[i];
                Node nodeActive = CuerrentNode.allNodes.Find(n => n.id == edgeActive.origin);
                resetActiveEdgesColors(nodeActive);
            }
        }
        for (int i = 0; i < CuerrentNode.allNodes.Count; i++)
        {
            hideTextLabel(CuerrentNode.allNodes[i]);
        }
    }


    public void MakeChangeColorOnTouch(GameObject targetNode)
    {
        var touchable = targetNode.AddComponent<NearInteractionTouchableVolume>();
        touchable.EventsToReceive = TouchableEventType.Pointer;
        Material material = targetNode.GetComponent<Renderer>().material;
        var pointerHandler = targetNode.AddComponent<PointerHandler>();
        pointerHandler.OnPointerDown.AddListener((e) => {
            resetAllNodes(material);
            activateNodes(material);

        });
        //pointerHandler.OnPointerUp.AddListener((e) => {
        //    resetNodes(material);
        //});

    }

    private void activateNodes(Material material)
    {
        material.color = getColor(NodeColorModel.activeNode);
        addRecursiveColor(this, this.id, 0);
        changeArrowColor(this, getColor(EdgeColorModel.nearEdge));
        showTextLabel(this, Color.white);
    }


    private void resetNodes(Material material)
    {
        material.color = this.color;
        resetActiveEdgesColors(this);
        resetArrowColors();
        hideTextLabel(this);
    }

    private void resetAllNodes(Material material)
    {
        material.color = this.color;
        resetAllEdges(this);
        resetArrowColors();
        hideTextLabel(this);
    }

    private void changeArrowColor(Node node,Color color)
    {
        foreach (Arrow arrow in node.allArrows)
        {
            if (node.id == arrow.source)
            {
                arrow.arr.GetComponent<MeshRenderer>().material.color = color;
            }
            if (node.id == arrow.target)
            {
                arrow.arr.GetComponent<MeshRenderer>().material.color = color;

            }
        }
    }


    private void resetArrowColors()
    {
 
        foreach (Arrow arrow in allArrows)
        {
            arrow.arr.GetComponent<MeshRenderer>().material.color = getColor(EdgeColorModel.regularEdge);
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

    private void showTextLabel(Node nodo, Color textColor,bool normalSize=true)
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
    private void hideTextLabel(Node nodo)
    {
        nodo.clicked = false;
        nodo.transform.GetChild(0).GetComponent<TextMesh>().text = "";
        nodo.textBackground.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }
}


