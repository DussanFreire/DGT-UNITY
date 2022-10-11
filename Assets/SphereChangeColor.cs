using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class SphereChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sphere;

    void Start()
    {
        MakeChangeColorOnTouch(sphere);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void MakeChangeColorOnTouch(GameObject target)
    {
        var touchable = target.AddComponent<NearInteractionTouchableVolume>();
        touchable.EventsToReceive = TouchableEventType.Pointer;
        var material = target.GetComponent<Renderer>().material;
        var pointerHandler = target.AddComponent<PointerHandler>();
        pointerHandler.OnPointerDown.AddListener((e) => material.color = Color.green);
        pointerHandler.OnPointerUp.AddListener((e) => material.color = Color.magenta);
    }
}
