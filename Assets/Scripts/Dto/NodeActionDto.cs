using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NodeActionDto 
{
    public string fileName;
    public string action;
    public int qty;

    public void setData( string fileName, string action, int qty){
        this.fileName=fileName;
        this.action=action;
        this.qty=qty;
    }

}
