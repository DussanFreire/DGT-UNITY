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
        }
        if (Input.GetKeyDown("w"))
        {
            MetricsManager.desktopInputs.w_pressed++;
        }
        if (Input.GetKeyDown("a"))
        {
            MetricsManager.desktopInputs.a_pressed++;
        }
        if (Input.GetKeyDown("s"))
        {
            MetricsManager.desktopInputs.s_pressed++;
        }
        if (Input.GetKeyDown("d"))
        {
            MetricsManager.desktopInputs.d_pressed++;
        }
        if (Input.GetKeyDown("j"))
        {
            Debug.Log("image");
            ScreenCapture.CaptureScreenshot("Imagen.png", 20);
        }
    }
}
