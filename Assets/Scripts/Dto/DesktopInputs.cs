using System;
using System.Collections.Generic;

[Serializable]
public class DesktopInputs 
{
    public int w_pressed=0;
    public int a_pressed=0;
    public int s_pressed=0;
    public int d_pressed=0;
    public int leftClickPressed=0;
    public int rightClickPressed=0;

    public void setData( int w_pressed, int a_pressed, int s_pressed, int d_pressed, int leftClickPressed, int rightClickPressed ){
        this.w_pressed=w_pressed;
        this.a_pressed=a_pressed;
        this.s_pressed=s_pressed;
        this.d_pressed=d_pressed;
        this.leftClickPressed=leftClickPressed;
        this.rightClickPressed=rightClickPressed;
    }
}

