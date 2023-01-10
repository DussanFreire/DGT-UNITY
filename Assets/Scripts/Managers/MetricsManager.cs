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
    static public int srcFilterUsed=0;
    static public int controllerFilterUsed=0;
    static public int serviceFilterUsed=0;
    static public int transpFilterUsed=0;
    static public int decoratorFilterUsed=0;
    static public int dtoFilterUsed=0;
    static public int enumFilterUsed=0;
    static public int guardFilterUsed=0;
    static public int persistenceFilterUsed=0;
    static public List<Vector3> headCoords;
    static public List<string> rightHandDateTime;
    static public List<string> leftHandDateTime;

    static public void staticInitMetric(){
        verticalRotationUsed = 0;
		horizontalRotationUsed = 0;
		hoverUsed = 0;
		touchUsed = 0;
		pointerUsed = 0;
		srcFilterUsed = 0;
		controllerFilterUsed = 0;
		serviceFilterUsed = 0;
		transpFilterUsed = 0;
		decoratorFilterUsed = 0;
		dtoFilterUsed = 0;
		enumFilterUsed = 0;
		guardFilterUsed = 0;
		persistenceFilterUsed = 0;
    }
}
