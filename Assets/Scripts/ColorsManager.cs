using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ColorsManager : MonoBehaviour
{
    public GameObject firstColor;
    public GameObject secondColor;
    public GameObject thirdColor;
    public GameObject forthColor;
    public GameObject fifthColor;
    public GameObject sixthColor;
    public GameObject seventhColor;
    public GameObject eigthColor;

    void Start()
    {
        
    }
    void ResponseCallback(){}

    private IEnumerator ProcessRequest(string uri)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(uri))
		{
			yield return request.SendWebRequest();

			if (request.isNetworkError)
			{
				Debug.Log(request.error);
			}
			else
			{
				var data = request.downloadHandler.text;
				RequestModel RequestModel = JsonUtility.FromJson<RequestModel>(data);
			}
		}
	}

    public void toggleColor(Material thisObj){
        Color objColor =thisObj.color;
        float tranpsDensity = 1f;
        if(objColor.a==1){
            tranpsDensity= 0.25f;
        }
        thisObj.color = new Color(objColor.r,objColor.g,objColor.b, tranpsDensity);
    }

    public bool allTransparent(){
        Color first = firstColor.GetComponent<Renderer>().material.color;
        Color second = secondColor.GetComponent<Renderer>().material.color;
        Color third = thirdColor.GetComponent<Renderer>().material.color;
        Color forth = forthColor.GetComponent<Renderer>().material.color;
        Color fifth = fifthColor.GetComponent<Renderer>().material.color;
        Color sixth = sixthColor.GetComponent<Renderer>().material.color;
        Color seventh = seventhColor.GetComponent<Renderer>().material.color;
        Color eicht = seventhColor.GetComponent<Renderer>().material.color;
        return first.a !=1 && second.a !=1 && third.a !=1 && forth.a !=1 && fifth.a !=1 && sixth.a !=1 && seventh.a !=1 && eicht.a !=1;
    }

    public void tranpColor(Material thisObj){
        Color objColor =thisObj.color;
        float tranpsDensity = 0.25f;
        thisObj.color = new Color(objColor.r,objColor.g,objColor.b, tranpsDensity);
    }
    public  void setFirstOption(GameObject thisObj){
        Metrics.srcFilterUsed++;
        if(allTransparent()){
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/src"));
        }else{
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/toggle/src"));
        }
        toggleColor(thisObj.GetComponent<Renderer>().material);
    }
    public void setSecondOption(GameObject thisObj){
        Metrics.controllerFilterUsed++;
        if(allTransparent()){
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/controller"));
        }else{
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/toggle/controller"));
        }
        toggleColor(thisObj.GetComponent<Renderer>().material);
    }

    public void setThirdOption(GameObject thisObj){
        Metrics.serviceFilterUsed++;
        if(allTransparent()){
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/service"));
        }else{
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/toggle/service"));
        }
        toggleColor(thisObj.GetComponent<Renderer>().material);
    }

    public void setForthOption(GameObject thisObj){
        Metrics.decoratorFilterUsed++;
        if(allTransparent()){
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/decorator"));
        }else{
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/toggle/decorator"));
        }
        toggleColor(thisObj.GetComponent<Renderer>().material);
    }

    public void setFifthOption(GameObject thisObj){
        Metrics.dtoFilterUsed++;
        if(allTransparent()){
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/dto"));
        }else{
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/toggle/dto"));
        }
        toggleColor(thisObj.GetComponent<Renderer>().material);
    }

    public void setSixthOption(GameObject thisObj){
        Metrics.enumFilterUsed++;
        if(allTransparent()){
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/enum"));
        }else{
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/toggle/enum"));
        }
        toggleColor(thisObj.GetComponent<Renderer>().material);
    }

    public void setSeventhOption(GameObject thisObj){
        Metrics.guardFilterUsed++;
        if(allTransparent()){
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/guard"));
        }else{
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/toggle/guard"));
        }
        toggleColor(thisObj.GetComponent<Renderer>().material);
    }

    public void setEigthOption(GameObject thisObj){
        Metrics.persistenceFilterUsed++;
        if(allTransparent()){
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/persistence"));
        }else{
            StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/brain/toggle/persistence"));
        }
        toggleColor(thisObj.GetComponent<Renderer>().material);
    }

    public void setTranspOption()
    {
        Metrics.transpFilterUsed++;
        transpAll();
        StartCoroutine(ProcessRequest("https://dependency-graph-z42n.vercel.app/file/transparent"));
    }

    public void transpAll()
    {
        tranpColor(firstColor.GetComponent<Renderer>().material);
        tranpColor(secondColor.GetComponent<Renderer>().material);
        tranpColor(thirdColor.GetComponent<Renderer>().material);
        tranpColor(forthColor.GetComponent<Renderer>().material);
        tranpColor(fifthColor.GetComponent<Renderer>().material);
        tranpColor(sixthColor.GetComponent<Renderer>().material);
        tranpColor(seventhColor.GetComponent<Renderer>().material);
        tranpColor(eigthColor.GetComponent<Renderer>().material);
    }
}
