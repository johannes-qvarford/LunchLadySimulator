using UnityEngine;
using System.Collections.Generic;
using UnityExtensions;
using System.Linq;

/** 
 * Utility class that holds constants for arms.
 **/
public sealed class ArmsState : MonoBehaviour 
{
	public float movementAcceleration = 0.05f;
	public float rotationAcceleration = 2;
	public float maxVelocity = 0.5f;
	public float recoilMulOnSolidCollision = 1;
	public float maxGrabDistance = 0.2f;
	public float framesUntilGiveUpSolidSolve = 60;
	public float throwVelocityMul = 5.0f;
	
	public float minZRotWithoutFreeze = 0.01f;
	public float minMovementWithoutFreeze = 0.0025f;
	public float epsilon = 0.01f;
	public float grabCylinderRadius = 0.1f;
	public float grabCylinderHeight = 0.2f;

	public List<GameObject> grabables;

	void Start()
	{
		grabables = GameObject
			.FindObjectsOfType<GameObject>()
			.Where(g => g.IsActiveGrabable()).ToList();
	}
}
