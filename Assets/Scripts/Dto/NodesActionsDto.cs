using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class NodesActionsDto
{
    public List<NodeActionDto> actionsDone;

    public void setActionsDone(List<NodeActionDto> actionsDone){
        this.actionsDone = actionsDone;

    }
}
