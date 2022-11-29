using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool buttonPressed = false;

    void Start()
    {
        
    }
    public void myAction()
    {
            buttonPressed=!buttonPressed;
            if(buttonPressed)
                Metrics.horizontalRotationUsed++;

    }
}