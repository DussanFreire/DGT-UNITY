using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RorationManager 
{
    private static bool verticalRotationActivated=false;
    private static bool horizontalRotationActivated=false;
	public static void setRotationListeners(Transform graphTransform){
        if(horizontalRotationActivated){
			graphTransform.Rotate(0,Enviroment.ROTATION_SPEED, 0, Space.World);
		}
		if(verticalRotationActivated){
			graphTransform.Rotate(Enviroment.ROTATION_SPEED,0, 0, Space.World);
		}
    }

    public static void changeVerticalRotation(bool rotationUpdate)
    {   
            if(rotationUpdate==verticalRotationActivated)
                return;
            verticalRotationActivated=!verticalRotationActivated;
            if(verticalRotationActivated)
                MetricsManager.verticalRotationUsed++;
    }

    public static void changeHorizontalRotation(bool rotationUpdate)
    {   
            if(rotationUpdate==horizontalRotationActivated)
                return;
            horizontalRotationActivated=!horizontalRotationActivated;
            if(horizontalRotationActivated)
                MetricsManager.horizontalRotationUsed++;
    }
}
