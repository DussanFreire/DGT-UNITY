using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tests : MonoBehaviour
{
    TextMeshPro textMeshPro;
    public static int currentTest= -1;
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
                return "Encuentre cuantos y cuales archivos podrían ser afectados de forma  directa si se realiza algún cambio en el archivo “employee.entity.ts”";
            case 1:
                return "Encuentre el apartado de archivos '.enum' que tengan una relacion con algun archivo '.entity'";
            case 2:
                return "Definir qué nodo tiene el mayor número de dependencias";
            case 3:
                return "Encontrar el grupo de archivos que se encuentre en menor cantidad dentro del proyecto";
            case 4:
                return "Encontrar los nodos que no dependan de ningún otro";
            default:
                return "Seleccione un test para continuar ...";
        }

    }
}