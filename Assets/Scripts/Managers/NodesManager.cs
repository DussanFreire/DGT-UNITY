using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodesManager
{
    static public List<Node> AllNodes { get; set; }

    static public void resetAllLabels()
    {
        for (int i = 0; i < AllNodes.Count; i++)
        {
            AllNodes[i].hideTextLabel();
        }
    }
    static public void turnTranspAllNodes()
    {
        for (int i = 0; i < AllNodes.Count; i++)
        {
            AllNodes[i].colorChangedByHover =false;
            AllNodes[i].turnToTranspColor();
        }
    }

}
