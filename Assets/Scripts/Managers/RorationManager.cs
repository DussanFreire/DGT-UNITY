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

    public static bool changeVerticalRotation(bool rotationUpdate)
    {   
            if(rotationUpdate==verticalRotationActivated)
                return false;
            verticalRotationActivated=!verticalRotationActivated;
            if(verticalRotationActivated)
                MetricsManager.verticalRotationUsed++;
            return true;
    }

    public static bool changeHorizontalRotation(bool rotationUpdate)
    {   
            if(rotationUpdate==horizontalRotationActivated)
                return false;
            horizontalRotationActivated=!horizontalRotationActivated;
            if(horizontalRotationActivated)
                MetricsManager.horizontalRotationUsed++;
            return true;
    }
}
