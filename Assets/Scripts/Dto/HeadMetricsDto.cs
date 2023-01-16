using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeadMetricsDto 
{
    public List<Vector3> HeadCoords;
    public List<Vector3> HeadRotation;
    public void setCoords(List<Vector3> coordAux, List<Vector3>  headRotationAux){
        HeadCoords =coordAux;
        HeadRotation =headRotationAux;
    }   
}
