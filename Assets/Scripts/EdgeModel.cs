using UnityEngine;

public class EdgeModel
{
    public GameObject edge;
    public int origin;
    public int target;
    public int intensityOfColor { get; set; }

    public EdgeModel()
    {
        this.intensityOfColor = 0;

    }
}