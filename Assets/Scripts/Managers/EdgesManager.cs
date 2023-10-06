using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgesManager  {
    
    static public List<Edge> AllEdges { get; set; }

    static public void turnTranspAllEdges()
    {
        for (int i = 0; i < AllEdges.Count; i++)
        {
            AllEdges[i].intensityOfColor = 0;
            Color edgeColor = ColorsManager.getColor(Enviroment.REGULAR_EDGE_COLOR);
            AllEdges[i].edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b,Enviroment.TRANSP_EDGE_DENSITY);
            AllEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b, Enviroment.TRANSP_EDGE_DENSITY);
        }
    }

    static public void turnSolidAllEdges()
    {
        for (int i = 0; i < AllEdges.Count; i++)
        {
            AllEdges[i].intensityOfColor = 0;
            Color edgeColor = ColorsManager.getColor(Enviroment.REGULAR_EDGE_COLOR);
            AllEdges[i].edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b,1);
            AllEdges[i].edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b, 1);
        }
    }


}
