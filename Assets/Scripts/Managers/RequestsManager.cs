using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Networking;
public class RequestsManager 
{
	
	public static  IEnumerator GetGraphData(string uri, Action<RequestDto> callback = null)
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
	public static IEnumerator SendMetricsDataPost(string uri)
	{
		HeadMetricsDto headMets = new HeadMetricsDto();
		headMets.setCoords(MetricsManager.headCoords, MetricsManager.headRotation);

		HandMetricsDto handMets = new HandMetricsDto();
		handMets.setHandData(MetricsManager.rightHandDateTime,MetricsManager.leftHandDateTime);

		NodesActionsDto actionsMets = new NodesActionsDto();
		actionsMets.setActionsDone(MetricsManager.actionsDone,MetricsManager.hoverUsed,MetricsManager.touchUsed,MetricsManager.pointerUsed);

		Vector3 pos = Camera.main.transform.position;
		WWWForm form = new WWWForm();
		form.AddField("desktopInputs",JsonUtility.ToJson(MetricsManager.desktopInputs,false));
		form.AddField("headMetrics",JsonUtility.ToJson(headMets,false));
		form.AddField("handMetricsInSeconds",JsonUtility.ToJson(handMets,false));
		form.AddField("actionsDone",JsonUtility.ToJson(actionsMets,false));
		form.AddField("experimentId", MetricsManager.currentTest);
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
			}
		}
		MetricsManager.staticInitMetric();
	}



}
