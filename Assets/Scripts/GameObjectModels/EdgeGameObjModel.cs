using UnityEngine;

public class EdgeGameObjModel
{
    public GameObject edge;
    public int origin;
    public int target;
    public int intensityOfColor { get; set; }
    public bool visible { get; set; }

    public EdgeGameObjModel()
    {
        this.intensityOfColor = 0;

    }

    public void turnEdgeToSolidColor(Color edgeColor){
        this.edge.GetComponent<Renderer>().material.color = edgeColor;
        this.edge.transform.GetChild(0).GetComponent<Renderer>().material.color = edgeColor;
    }

    public void turnEdgeToTranspColor(Color edgeColor){
        this.edge.GetComponent<Renderer>().material.color = new Color(edgeColor.r,edgeColor.g,edgeColor.b,0.25f);
        this.edge.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(edgeColor.r, edgeColor.g, edgeColor.b, 0.10f);
    }
}