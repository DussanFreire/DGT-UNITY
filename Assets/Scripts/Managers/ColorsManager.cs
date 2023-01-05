using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
public class ColorsManager 
{
    public static Color getColor(string colorHex)
    {
        Color color;
        ColorUtility.TryParseHtmlString(colorHex, out color);
        return color;
    }
    static public void changeChildrenColors(Node currentNode,Material material){
        currentNode.turnToSolidColor();
        currentNode.showTextLabel();
        List<Node> childrenNode = new List<Node>();
        for (int i = 0; i < EdgesManager.AllEdges.Count; i++)
        {
            if(EdgesManager.AllEdges[i].origin ==currentNode.id){
                EdgesManager.AllEdges[i].edge.GetComponent<Renderer>().material.color = currentNode.nodeColor;
                EdgesManager.AllEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color =currentNode.nodeColor;
                Node node = NodesManager.AllNodes.Find(n=>n.id==EdgesManager.AllEdges[i].target);
                node.turnToSolidColor();
            }
        }
    }
    
    static public void SetColorsListener(Node node, GameObject targetNode)
    {
        var touchable = targetNode.AddComponent<NearInteractionTouchableVolume>();
        touchable.EventsToReceive = TouchableEventType.Pointer;
        Material material = targetNode.GetComponent<Renderer>().material;
        var pointerHandler = targetNode.AddComponent<PointerHandler>();
        var touchHandler = targetNode.AddComponent<TouchHandler>();
        var focusHandler = targetNode.AddComponent<FocusHandler>();
        pointerHandler.OnPointerDown.AddListener((e) => {
            NodesManager.resetAllLabels();
            NodesManager.turnTranspAllNodes();
            EdgesManager.turnTranspAllEdges();   
            MetricsManager.pointerUsed++;
            changeChildrenColors(node, material); 
        });
        touchHandler.OnTouchCompleted.AddListener((e) => {
            MetricsManager.touchUsed++;
            NodesManager.resetAllLabels();
            NodesManager.turnTranspAllNodes();
            EdgesManager.turnTranspAllEdges();
            changeChildrenColors(node, material);
        });
    }
    
}
