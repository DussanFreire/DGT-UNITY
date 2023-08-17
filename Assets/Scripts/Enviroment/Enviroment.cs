using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment 
{


    // public static bool DESKTOP_SETUP = Application.isPlaying? false : true;
    public static bool DESKTOP_SETUP = false;


    // HTTP ENV

    public static string BASE_URL= "http://localhost:3000" ;

    public static void setBaseURL(string url){
        BASE_URL= url ;
        URL_INIT_GRAPH = url+"/graph/restart";
        URL_GET_GRAPH = url+"/graph";
        URL_SEND_METRICS = url+"/metrics";
        URL_SEND_METRICS_HEAD = url+"/graph-data-flow";
    }
    public static string getInitGraphURL(){
        return URL_INIT_GRAPH;
    }

    public static string getGraphURL(){
        return URL_GET_GRAPH;
    }

    public static string getBaseURL(){
        return BASE_URL;
    }

    public static string getSendMetricsURL(){
        return URL_SEND_METRICS;
    }

    public static string getSendMetricsHeadURL(){
        return URL_SEND_METRICS_HEAD;
    }
    public static string URL_INIT_GRAPH = BASE_URL+"/graph/restart";
    public static string URL_GET_GRAPH = BASE_URL+"/graph";
    public static string URL_SEND_METRICS = BASE_URL+"/metrics";
    public static string URL_SEND_METRICS_HEAD = BASE_URL+"/graph-data-flow";

    // MOVEMENT ENV
    public static float MOVEMENT_SPEED = 0.5f;
    public static int MOVEMENT_TIME = 7000;
	public static  float MOVEMENT_STEP = 0.1f * Time.deltaTime;

    public static float ROTATION_SPEED = 0.55f;

   // EDGE COLORS ENV
    public static string REGULAR_EDGE_COLOR  = "#000000";
    public static string REGULAR_CONN  = "#349536";
    public static float TRANSP_EDGE_DENSITY  = 0.000f;
    public static float TRANSP_NODE_DENSITY  = 0.25f;
    // TEXT ENV
    static public float TEXT_SIZE =1.4f;
    static public float TEXT_BG_HEIGHT =0.06f ;
    // static public float TEXT_BG_HEIGHT =0.03f ;
    static public Vector3 NODE_LOCAL_SCALE = new Vector3(0.0500000007f,0.0500000007f,0.0500000007f);
    static public Vector3 EDGE_LOCAL_SCALE = new Vector3(0.00300000003f,0.00300000003f,0.200000003f);
}