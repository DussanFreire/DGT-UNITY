using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment 
{
    // HTTP ENV
    public const string BASE_URL = "https://dependency-graph-z42n.vercel.app";
    // public const string BASE_URL= "http://localhost:3000";
    public const string URL_INIT = BASE_URL+"/file/restart";
    public const string URL_UPDATE = BASE_URL+"/file/brain";

    // MOVEMENT ENV
    public static float MOVEMENT_SPEED = 0.5f;
    public static int MOVEMENT_TIME = 7000;
	public static  float MOVEMENT_STEP = 0.1f * Time.deltaTime;

    public static float ROTATION_SPEED = 0.55f;

   // EDGE COLORS ENV
    public static string REGULAR_EDGE_COLOR  = "#000000";
    public static float TRANSP_DENSITY  = 0.25f;
    // TEXT ENV
    static public float TEXT_SIZE =0.7f;
    static public float TEXT_BG_HEIGHT =0.03f ;
    static public Vector3 NODE_LOCAL_SCALE = new Vector3(0.0500000007f,0.0500000007f,0.0500000007f);
    static public Vector3 EDGE_LOCAL_SCALE = new Vector3(0.00300000003f,0.00300000003f,0.200000003f);
}