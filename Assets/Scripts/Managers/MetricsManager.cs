using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [Serializable]

public class MetricsManager
{

    static public int currentTest = 1;
    static public int verticalRotationUsed = 0;
    static public int horizontalRotationUsed = 0;
    static public int hoverUsed = 0;
    static public int touchUsed = 0;
    static public int pointerUsed = 0;  
    static public int persistenceFilterUsed=0;
    static public DesktopInputs desktopInputs;
    static public List<Vector3> headCoords;
    static public List<Vector3> headRotation;
    static public List<string> rightHandDateTime;
    static public List<string> leftHandDateTime;
    static public List<NodeActionDto> actionsDone;

    static public void staticInitMetric(){
        desktopInputs= new DesktopInputs();
        verticalRotationUsed = 0;
		horizontalRotationUsed = 0;
		hoverUsed = 0;
		touchUsed = 0;
		pointerUsed = 0;
    }
}
