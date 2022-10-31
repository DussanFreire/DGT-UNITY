using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class Menu : MonoBehaviour, IMixedRealityTouchHandler
{
    public static bool buttonPressed = false;
    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        buttonPressed=!buttonPressed;
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {

    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
