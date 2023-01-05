using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class RequestsManager 
{
 
   	public static  IEnumerator ProcessRequestGet(string uri, Action<RequestDto> callback = null)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(uri))
		{
			yield return request.SendWebRequest();

			if (request.result!= UnityWebRequest.Result.Success)
			{
				Debug.Log(request.error);
			}
			else
			{
				var data = request.downloadHandler.text;
				RequestDto RequestModel = JsonUtility.FromJson<RequestDto>(data);
				if (callback != null)
					callback(RequestModel);
			}
		}
	}	
	public static IEnumerator ProcessRequestPost(string uri, Action<RequestDto> callback = null)
	{
		Vector3 pos = Camera.main.transform.position;

		WWWForm form = new WWWForm();
		form.AddField("posX", pos.x.ToString());
		form.AddField("posY", pos.y.ToString());
		form.AddField("posZ", pos.z.ToString());
		form.AddField("verticalRotationUsed", MetricsManager.verticalRotationUsed);
		form.AddField("horizontalRotationUsed", MetricsManager.horizontalRotationUsed);
		form.AddField("hoverUsed", MetricsManager.hoverUsed);
		form.AddField("touchUsed", MetricsManager.touchUsed);
		form.AddField("pointerUsed", MetricsManager.pointerUsed);
		form.AddField("srcFilterUsed", MetricsManager.srcFilterUsed);
		form.AddField("controllerFilterUsed", MetricsManager.controllerFilterUsed);
		form.AddField("serviceFilterUsed", MetricsManager.serviceFilterUsed);
		form.AddField("decoratorFilterUsed", MetricsManager.decoratorFilterUsed);
		form.AddField("dtoFilterUsed", MetricsManager.dtoFilterUsed);
		form.AddField("enumFilterUsed", MetricsManager.enumFilterUsed);
		form.AddField("guardFilterUsed", MetricsManager.guardFilterUsed);
		form.AddField("persistenceFilterUsed", MetricsManager.persistenceFilterUsed);
		form.AddField("transpFilterUsed", MetricsManager.transpFilterUsed);
		form.AddField("currentTime", DateTime.Now.ToString());
		form.AddField("id", MetricsManager.currentTest);

		using (UnityWebRequest request = UnityWebRequest.Post(uri,form))
		{
			yield return request.SendWebRequest();

			if (request.result!= UnityWebRequest.Result.Success)
			{
				Debug.Log(request.error);
			}
			else
			{
				var data = request.downloadHandler.text;
				RequestDto RequestModel = JsonUtility.FromJson<RequestDto>(data);
				if (callback != null)
					callback(RequestModel);
			}
		}
		MetricsManager.staticInitMetric();
	}
}
