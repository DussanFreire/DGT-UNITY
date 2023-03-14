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
    static public DesktopInputs desktopInputs = new DesktopInputs();
    static public List<Vector3> headCoords = new List<Vector3>();
    static public List<Vector3> headRotation = new List<Vector3>();
    static public List<string> rightHandDateTime = new List<string>();
    static public List<string> leftHandDateTime = new List<string>();
    static public List<NodeActionDto> actionsDone = new List<NodeActionDto>();

    static public void staticInitMetric(){
        desktopInputs= new DesktopInputs();

        verticalRotationUsed = 0;
		horizontalRotationUsed = 0;
		hoverUsed = 0;
		touchUsed = 0;
		pointerUsed = 0;

        rightHandDateTime= new List<string>();
        leftHandDateTime= new List<string>();
        actionsDone= new List<NodeActionDto>();
    }

    static public void staticInitHeadMetric(){
        headCoords= new List<Vector3>();
        headRotation= new List<Vector3>();
    }
}
