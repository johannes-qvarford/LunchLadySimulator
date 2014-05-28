using UnityEngine;
using System.Collections;

public class CamFollowArms : MonoBehaviour {

	public GameObject playerArmLeft;
	public GameObject playerArmRight;
	public float adjustX = 0.0f;
	public float adjustY = 0.0f;
	public float adjustZ = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float targetX, targetY, targetZ;

		targetX = adjustX + (playerArmLeft.transform.position.x + playerArmRight.transform.position.x) / 2;
		targetY = adjustY + (playerArmLeft.transform.position.y + playerArmRight.transform.position.y) / 2;
		targetZ = adjustZ + (playerArmLeft.transform.position.z + playerArmRight.transform.position.z) / 2;

		Vector3 targetPos = transform.position; //the hell..? Needs to be assigned somehow, I don't know coding D:
		targetPos.Set(transform.position.x,targetY,targetZ); //the look (camera rotation) target. Does not include hands' average X position

		Vector3 relativePos = targetPos - transform.position;

		Quaternion newRotation = Quaternion.LookRotation (relativePos);
		transform.rotation = newRotation;
		//not ugly enough before? I got you covered! Let's reuse variables, for something completely else! :D
		targetPos.Set (targetX, transform.position.y, transform.position.z); //Now this is exiting! Look at us use the "targetPos" as a position target!
		transform.position = targetPos; //the camera now moves to the hands' average X position.
	}
}
