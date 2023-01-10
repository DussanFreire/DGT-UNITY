using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeadMetricsDto 
{
    public List<Vector3> coords;
    public void setCoords(List<Vector3> coordAux){
        coords =coordAux;

    }
}
