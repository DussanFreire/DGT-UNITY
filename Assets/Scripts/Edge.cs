using UnityEngine;

public class Edge
{
    public GameObject edge;
    public int origin;
    public int target;
    public int intensityOfColor { get; set; }
    public bool visible { get; set; }

    public Edge()
    {
        this.intensityOfColor = 0;

    }

    public void turnEdgeToSolidColor(Color edgeColor){
        this.edge.GetComponent<Renderer>().material.color = edgeColor;
        this.edge.transform.GetChild(0).GetComponent<Renderer>().material.color = edgeColor;
    }

    public void turnEdgeToTranspColor(Color edgeColor){
        this.edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b, Enviroment.TRANSP_DENSITY);
        this.edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b, Enviroment.TRANSP_DENSITY);
    }
}