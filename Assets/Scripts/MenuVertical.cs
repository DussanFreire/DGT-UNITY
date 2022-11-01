using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class MenuVertical : MonoBehaviour
{
    // Start is called before the first frame update
   public static bool buttonPressed = false;

    void Start()
    {
        
    }

    //Output the new state of the Toggle into Text
    public void myAction()
    {
            buttonPressed=!buttonPressed;

    }
}