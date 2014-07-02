using UnityEngine;
using System.Collections;

/**
 * Class for a camera to follow the player's arms.
 * It only moves horizontally and always focuses on the center of the two arms.
 **/
public class CamFollowArms : MonoBehaviour
{
	public GameObject playerArmLeft;
	public GameObject playerArmRight;
	public float adjustX = 0.0f;
	public float adjustY = 0.0f;
	public float adjustZ = 0.0f;

	void Update ()
	{
		float targetX = adjustX + (playerArmLeft.transform.position.x + playerArmRight.transform.position.x) / 2;
		float targetY = adjustY + (playerArmLeft.transform.position.y + playerArmRight.transform.position.y) / 2;
		float targetZ = adjustZ + (playerArmLeft.transform.position.z + playerArmRight.transform.position.z) / 2;

		{
			/*
			 * TargetRotPos is where the camera will be in y and z.
			 * RelativePos will therefor be a vector of where the camera should look in y and z.
			 * LookRotation will therefor rotate the camera according to a (0, y, z) forward vector.
			 */
			Vector3 targetRotPos = new Vector3(transform.position.x, targetY, targetZ);
			Vector3 relativePos = targetRotPos - transform.position;
			transform.rotation = Quaternion.LookRotation (relativePos);
		}

		{
			/*
			 * Only move the camera horizontally.
			 */
			Vector3 targetPos = new Vector3(targetX, transform.position.y, transform.position.z);
			transform.position = targetPos;
		}
	}
}
