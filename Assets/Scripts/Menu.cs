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

    //Output the new state of the Toggle into Text
    public void myAction()
    {
            buttonPressed=!buttonPressed;

    }
}