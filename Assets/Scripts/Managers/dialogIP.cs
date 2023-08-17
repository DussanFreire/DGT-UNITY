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
                RequestsManager.SelectDatasetData(Enviroment.URL_SET_DATASET)

                string text = textMeshPro.text;
                string server= "http://"+RemoveZeroWidthSpace(text)+":3000";
                Enviroment.setBaseURL(server); 
                location.SetActive(true);
                idDialog.SetActive(false);
            }
        }
    }
    public void clickButtonMario(){
        Enviroment.dataset = "mario"
        Debug.Log("clickButtonMario",Enviroment.dataset);
    }

    public void clickButtonAngular(){
        Enviroment.dataset = "angular"
        Debug.Log("clickButtonAngular",Enviroment.dataset);
    }
}
