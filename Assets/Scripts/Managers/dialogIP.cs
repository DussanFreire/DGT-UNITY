using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dialogIP : MonoBehaviour
{
    void Start()
	{
	    if(Enviroment.DESKTOP_SETUP){
            Debug.Log("llega aca");
            ObjectManager.FindInActiveObjectByName("TitleText123").SetActive(false);
            ObjectManager.FindInActiveObjectByName("Canvas123").SetActive(false);
            ObjectManager.FindInActiveObjectByName("DescriptionText123").SetActive(false);
        }
	}
    public GameObject targetObject;
    
    public static string RemoveZeroWidthSpace(string input)
    {
        return input.Replace("\u200B", "");
    }
    public void clickButton(){
        GameObject location = ObjectManager.FindInActiveObjectByName("PlaceLocation");
        GameObject idDialog = ObjectManager.FindInActiveObjectByName("idDialog");
        string text = Enviroment.BASE_URL;
        if (targetObject != null)
        {
            if(!Enviroment.DESKTOP_SETUP){
                TextMeshProUGUI textMeshPro = targetObject.GetComponent<TextMeshProUGUI>();
                text = "http://"+RemoveZeroWidthSpace(textMeshPro.text)+":3000";
            }

            if (text != "")
            {
                Enviroment.setBaseURL(text); 
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
