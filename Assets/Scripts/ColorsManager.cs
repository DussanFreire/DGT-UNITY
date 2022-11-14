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

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void onAwake(){}
    void ResponseCallback(){}

    // Update is called once per frame
  
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

    public void tranpColor(Material thisObj){
        Color objColor =thisObj.color;
        float tranpsDensity = 0.25f;
        thisObj.color = new Color(objColor.r,objColor.g,objColor.b, tranpsDensity);
    }
    public  void setFirstOption(GameObject thisObj){
        toggleColor(thisObj.GetComponent<Renderer>().material);
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/src"));
    }
    public void setSecondOption(GameObject thisObj){
        toggleColor(thisObj.GetComponent<Renderer>().material);
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/controller"));

    }

    public void setThirdOption(GameObject thisObj){
        toggleColor(thisObj.GetComponent<Renderer>().material);

        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/service"));

    }

    public void setForthOption(GameObject thisObj){
        toggleColor(thisObj.GetComponent<Renderer>().material);

        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/decorator"));
    }

    public void setFifthOption(GameObject thisObj){
        toggleColor(thisObj.GetComponent<Renderer>().material);

        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/dto"));
    }

    public void setSixthOption(GameObject thisObj){
        toggleColor(thisObj.GetComponent<Renderer>().material);

        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/enum"));
    }

    public void setSeventhOption(GameObject thisObj){
        toggleColor(thisObj.GetComponent<Renderer>().material);

        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/guard"));
    }

    public void setEigthOption(GameObject thisObj){
        toggleColor(thisObj.GetComponent<Renderer>().material);

        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/persistence"));
    }

    public void setTranspOption(){
        tranpColor(firstColor.GetComponent<Renderer>().material);
        tranpColor(secondColor.GetComponent<Renderer>().material);
        tranpColor(thirdColor.GetComponent<Renderer>().material);
        tranpColor(forthColor.GetComponent<Renderer>().material);
        tranpColor(fifthColor.GetComponent<Renderer>().material);
        tranpColor(sixthColor.GetComponent<Renderer>().material);
        tranpColor(seventhColor.GetComponent<Renderer>().material);
        tranpColor(eigthColor.GetComponent<Renderer>().material);
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/transparent"));
    }
}
