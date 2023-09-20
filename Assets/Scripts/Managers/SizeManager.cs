using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager 
{

    public static bool sizeChanged { get; set; }
    public static float speed = 7.0f;
    public static Vector3 newSize { get; set; }
    public static void changeSize(Vector3 auxSize){
        newSize=auxSize;
        sizeChanged=true;
    }
    public static void setSizeListener(Transform transform){
        if(sizeChanged){
            transform.localScale = Vector3.Lerp (transform.localScale, newSize, speed * Time.deltaTime);
            if((Vector3.Distance(transform.localScale, newSize) < 0.01f)){
                sizeChanged=false;
            }
        }

    }

}
