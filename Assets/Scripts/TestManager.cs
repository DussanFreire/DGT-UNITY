using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void setFirstOption(){
        Tests.setCurrentValue(0);
    }

    public void setSecondOption(){
        Tests.setCurrentValue(1);
    }

    public void setThirdOption(){
        Tests.setCurrentValue(2);
    }

    public void setForthOption(){
        Tests.setCurrentValue(3);
    }

    public void setFifthOption(){
        Tests.setCurrentValue(4);
    }
}
