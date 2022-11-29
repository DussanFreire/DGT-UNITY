using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tests : MonoBehaviour
{
    TextMeshPro textMeshPro;
    public static int currentTest= 0;
    static bool updated =true;
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        
    }

    void Update()
    {
        if(updated){
            textMeshPro.text = getCurrentTest();

            updated=false;
        }
        
        
    }
    

    public static void setCurrentValue(int i){
        updated=true;
        currentTest=i;
    }
    //Output the new state of the Toggle into Text
    public static string getCurrentTest()
    {
        switch (currentTest)
        {
            case 0:
                return "¿Cuáles son los archivos que podrían ser afectados de forma directa si se realiza algún cambio en el archivo 'company.controller.ts'?";
                // company.controller.spec.ts | employee.service.spec.ts | controller.module.ts
            case 1:
                return "¿Cuáles son los archivos dentro la categoría de archivos 'dto' que tienen alguna relación con archivos dentro la categoría 'service'?";
                // company.dto.ts | dependencies.dto | employee.dto.ts
            case 2:
                return "¿Cuáles son los 3 nodos que ha simple vista tienen mayor numero de dependencias'?";
                // employee.service.scpec.ts | user.services.spec.ts | company.controllet.spec.ts
            case 3:
                return "¿Cuál es la categoría de archivos que se encuentra en menor cantidad dentro del proyecto?";
                // enum
            case 4:
                return "¿Cuáles son los nodos que no dependen de ningún otro en la categoría de archivos 'src'?";
                // app.service.ts | app.controller.ts | main.ts
            default:
                return "Seleccione un test para continuar ...";
        }
    }
}