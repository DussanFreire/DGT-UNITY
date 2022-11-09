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
    public  void setFirstOption(){
        
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/src"));
    }
    public void setSecondOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/controller"));

    }

    public void setThirdOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/service"));

    }

    public void setForthOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/decorator"));
    }

    public void setFifthOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/dto"));
    }

    public void setSixthOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/enum"));
    }

    public void setSeventhOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/guard"));
    }

    public void setEigthOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/brain/toggle/persistence"));
    }

    public void setTranspOption(){
        StartCoroutine(ProcessRequest("https://test-dependencies.herokuapp.com/file/transparent"));
    }
}
