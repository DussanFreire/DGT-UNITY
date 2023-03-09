using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    static public void setKeyboardAndMouseListeners(Transform graphTransform)
    {
        if (Input.GetMouseButtonDown(0))
        {
            MetricsManager.desktopInputs.leftClickPressed++;
        }
        if (Input.GetMouseButtonDown(1))
        {
            MetricsManager.desktopInputs.rightClickPressed++;
            Debug.Log("Pressed sec button.");
        }
        if (Input.GetKeyDown("w"))
        {
            MetricsManager.desktopInputs.w_pressed++;
            Debug.Log("Pressed sec w.");
        }
        if (Input.GetKeyDown("a"))
        {
            MetricsManager.desktopInputs.a_pressed++;
            Debug.Log("Pressed sec a.");
        }
        if (Input.GetKeyDown("s"))
        {
            MetricsManager.desktopInputs.s_pressed++;
            Debug.Log("Pressed sec s.");
        }
        if (Input.GetKeyDown("d"))
        {
            MetricsManager.desktopInputs.d_pressed++;
            Debug.Log("Pressed sec d.");
        }
    }
}
