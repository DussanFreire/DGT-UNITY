using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RorationManager 
{
    private static bool verticalRotationActivated=false;
    private static bool horizontalRotationActivated=false;
	public static void setRotationListeners(Transform graphTransform){
        float rotationSpeed = Enviroment.DESKTOP_SETUP? Enviroment.ROTATION_SPEED_DESKTOP :Enviroment.ROTATION_SPEED_MR;
        if(horizontalRotationActivated){
			graphTransform.Rotate(0,rotationSpeed, 0, Space.World);
		}
		if(verticalRotationActivated){
			graphTransform.Rotate(rotationSpeed,0, 0, Space.World);
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
