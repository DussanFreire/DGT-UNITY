using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class NodesActionsDto
{
    
    public int hoverUsed = 0;
    public int touchUsed = 0;
    public int pointerUsed = 0;  
    public List<NodeActionDto> details;

    public void setActionsDone(List<NodeActionDto> actionsDone, int hoverUsed,int touchUsed,int pointerUsed){
        this.hoverUsed=hoverUsed;
        this.touchUsed=touchUsed;
        this.pointerUsed=pointerUsed;
        this.details = actionsDone;

    }
}
