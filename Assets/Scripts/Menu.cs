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
                MetricsManager.horizontalRotationUsed++;

    }

    public static void myActionFromHttp(bool update)
    {   
            if(update==buttonPressed)
                return;
            buttonPressed=!buttonPressed;
            if(buttonPressed)
                MetricsManager.horizontalRotationUsed++;

    }
}