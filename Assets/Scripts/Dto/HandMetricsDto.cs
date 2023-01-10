using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HandMetricsDto 
{
    public List<string> RightHand;
    public List<string> LeftHand;
    public void setHandData(List<string> RightHandAux,List<string> LeftHandAux){
        RightHand =RightHandAux;
        LeftHand =LeftHandAux;
    }
}
