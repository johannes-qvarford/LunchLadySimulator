using UnityEngine;
using System.Collections;

public sealed class ArmsState : MonoBehaviour 
{
	public bool debug = true;
	public float movementSpeed = 0.05f;
	public float rotationSpeed = 2;
	public float maxToolGrabDistance = 0.1f;
	public float maxPlateStackGrabDistance = 0.3f;
	public float grabSweepDistance = 0.02f;
	public float lowestArmHandleDegrees = 30;
	public float epsilon = 0.01f;
	public float minZRotFreeze = 0.01f;
	public float minMovementWithoutFreeze = 0.0025f;
	public float maxVelocity = 0.25f;
	public float framesUntilGiveUpSolidSolve = 60;
	public float solidRecoilMul = 1;
	public float maxRotRestrictionAngles = 30;
	public Vector3 moveOffsetOnGrabTool = new Vector3(0, 0.005f, 0);
	public Vector3 moveOffsetOnGrabPlate = new Vector3(0, -0.04f, 0.2f); //z should be -z, but in the inspector it shows -z when it's really z
	public GameObject debugSphere;

	public string handleName = "Handle";
	public string boundsName = "Bounds";
}
