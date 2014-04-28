using UnityEngine;
using System.Collections;

public sealed class ArmsState : MonoBehaviour 
{
	public bool debug = true;
	public float movementSpeed = 0.05f;
	public float rotationSpeed = 2;
	public float maxToolGrabDistance = 0.1f;
	public float maxSpawnStackGrabDistance = 0.3f;
	public float grabSweepDistance = 0.02f;
	public float lowestArmHandleDegrees = 30;
	public float epsilon = 0.01f;
	public float minZRotFreeze = 0.01f;
	public float minMovementWithoutFreeze = 0.0025f;
	public float maxVelocity = 0.25f;
	public float framesUntilGiveUpSolidSolve = 60;
	public float solidRecoilMul = 1;
	public float maxRotRestrictionAngles = 30;
	public float minDistanceBetweenArms = 0.2f;
	public GameObject debugSphere;
	public bool checkIfAtonamyCorrect = false;

	public string handleName = "Handle";
	public string boundsName = "Bounds";
}
