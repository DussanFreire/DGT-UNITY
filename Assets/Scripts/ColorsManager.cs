using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ColorsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ResponseCallback(){}

    // Update is called once per frame
    public  void setFirstOption(){
        
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/src"));
    }
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

    public void setSecondOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/controller"));

    }

    public void setThirdOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/service"));

    }

    public void setForthOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/decorator"));
    }

    public void setFifthOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/dto"));
    }

    public void setSixthOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/enum"));
    }

    public void setSeventhOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/guard"));
    }

    public void setEigthOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/persistence"));
    }
}
