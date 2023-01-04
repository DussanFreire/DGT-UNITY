using UnityEngine;
using System.Threading.Tasks;

public class PositionManager 
{

	private static bool movingX=false;
	private static bool movingY =false;
	private static bool movingZ =false;
	private static Vector3 posXTarget;
	private static Vector3 posYTarget;
	private static Vector3 posZTarget;

   

    public static void  setMovementListener(Transform graphTransform){
        if(movingX){
            graphTransform.position = Vector3.MoveTowards(graphTransform.position, posXTarget, Enviroment.MOVEMENT_STEP);
        }
        if(movingY){
            graphTransform.position = Vector3.MoveTowards(graphTransform.position, posYTarget, Enviroment.MOVEMENT_STEP);
        }
        if(movingZ){
            graphTransform.position = Vector3.MoveTowards(graphTransform.position, posZTarget, Enviroment.MOVEMENT_STEP);
        }
    }
    public static void moveXPosition(bool backward, bool forward, Transform graphTransform){
		if(!backward && !forward)
			return;
        float movement = Enviroment.MOVEMENT_SPEED;
        if(backward) movement*= -1;
		posXTarget = graphTransform.position;
		posXTarget += new Vector3(movement,0,0);
		movingX = true;
		Task.Run(async () =>
		{
			await Task.Delay(Enviroment.MOVEMENT_TIME);
			movingX=false;
		});
	}
	public static void moveYPosition(bool backward, bool forward, Transform graphTransform){
		if(!backward && !forward)
			return;
        float movement = Enviroment.MOVEMENT_SPEED;
        if(backward) movement*=-1;
		posYTarget = graphTransform.position;
		posYTarget += new Vector3(0,movement,0);
		movingY = true;
		Task.Run(async () =>
		{
			await Task.Delay(Enviroment.MOVEMENT_TIME);
			movingY=false;
		});
	}
	public static void moveZPosition(bool backward, bool forward, Transform graphTransform){
		if(!backward && !forward)
			return;
        float movement = Enviroment.MOVEMENT_SPEED;
        if(backward) movement*=-1;
		posZTarget = graphTransform.position;
		posZTarget += new Vector3(0,0,movement);
		movingZ = true;
		Task.Run(async () =>
		{
			await Task.Delay(Enviroment.MOVEMENT_TIME);
			movingZ=false;
		});
	}
}
