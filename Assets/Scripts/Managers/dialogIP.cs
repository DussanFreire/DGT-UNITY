using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dialogIP : MonoBehaviour
{
    public GameObject targetObject;
    
    public static string RemoveZeroWidthSpace(string input)
    {
        return input.Replace("\u200B", "");
    }
    public void clickButton(){
        GameObject location = ObjectManager.FindInActiveObjectByName("PlaceLocation");
        GameObject idDialog = ObjectManager.FindInActiveObjectByName("idDialog");
        if (targetObject != null)
        {
            TextMeshProUGUI textMeshPro = targetObject.GetComponent<TextMeshProUGUI>();

            if (textMeshPro != null)
            {
                string text = textMeshPro.text;
                string server= "http://"+RemoveZeroWidthSpace(text)+":3000";
                Enviroment.setBaseURL(server); 
                Debug.Log(Enviroment.URL_SET_DATASET);
                StartCoroutine(RequestsManager.SelectDatasetData(Enviroment.URL_SET_DATASET));
                
                location.SetActive(true);
                idDialog.SetActive(false);
            }
        }
    }
    public void clickButtonMario(){
        Enviroment.dataset = "mario";
        Debug.Log("clickButtonMario");
        Debug.Log(Enviroment.dataset);
    }

    public void clickButtonAngular(){
        Enviroment.dataset = "angular";
        Debug.Log("clickButtonAngular");
        Debug.Log(Enviroment.dataset);
    }

    public void clickButtonToy1(){
        Enviroment.dataset = "toy1";
        Debug.Log("clickButtonToy1");
        Debug.Log(Enviroment.dataset);
    }
     public void clickButtonToy2(){
        Enviroment.dataset = "toy2";
        Debug.Log("clickButtonToy2");
        Debug.Log(Enviroment.dataset);
    }

}
