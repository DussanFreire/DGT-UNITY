using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public  void setNormal(){
        Tests.setCurrentValue(-1);
    }

    public  void setFirstOption(){
        MetricsManager.currentTest = 1;
        Tests.setCurrentValue(0);
    }

    public void setSecondOption(){
        MetricsManager.currentTest = 2;
        Tests.setCurrentValue(1);
    }

    public void setThirdOption(){
        MetricsManager.currentTest = 3;
        Tests.setCurrentValue(2);
    }

    public void setForthOption(){
        MetricsManager.currentTest = 4;
        Tests.setCurrentValue(3);
    }

    public void setFifthOption(){
        MetricsManager.currentTest = 5;
        Tests.setCurrentValue(4);
    }
}
