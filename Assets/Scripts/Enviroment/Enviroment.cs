using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment 
{
    public const string BASE_URL = "https://dependency-graph-z42n.vercel.app";
    public const string URL_INIT = BASE_URL+"/file/restart";
    public const string URL_UPDATE = BASE_URL+"/file/brain";

    // MOVEMENT ENV
    public static float MOVEMENT_SPEED = 0.5f;
    public static int MOVEMENT_TIME = 7000;
	public static  float MOVEMENT_STEP = 0.1f * Time.deltaTime;

}