using UnityEngine;
using System.Collections;
using System;

public class ArmLogic : MonoBehaviour 
{
	public ArmInputManager.Arm arm;
	public string handleName = "Handle";
	public string boundsName = "Bounds";
	public float movementSpeed = 0.1f;
	public float rotationSpeed = 2.0f;
	
	private Transform bounds;
	private Transform handle;

	void Start()
	{
		handle = transform.Find(handleName);
		bounds = transform.Find(boundsName);
	}

	void Update()
	{
		//x and z axis is flipped on the model
		float Z_ROTATION = rotationSpeed * 		ArmInputManager.GetMovement(arm, ArmInputManager.HORIZONTAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Z_ROTATION, arm)); 
		float X_MOVEMENT = -1 * movementSpeed * ArmInputManager.GetMovement(arm, ArmInputManager.HORIZONTAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Z_ROTATION, arm) == false);
		float Y_MOVEMENT = movementSpeed * 		ArmInputManager.GetMovement(arm, ArmInputManager.VERTICAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Y_MOVEMENT, arm));
		float Z_MOVEMENT = -1 * movementSpeed * ArmInputManager.GetMovement(arm, ArmInputManager.VERTICAL) * 	Convert.ToInt32(ArmInputManager.IsOn(ArmInputManager.Y_MOVEMENT, arm) == false);
		bool GRIP_ON = ArmInputManager.IsOn(ArmInputManager.GRIP, arm);

		handle.Rotate(-1 * Vector3.forward * Z_ROTATION, Space.Self);

		Vector3 MOVEMENT = new Vector3(X_MOVEMENT, Y_MOVEMENT, Z_MOVEMENT);
		Vector3 OFFSET = (handle.position + MOVEMENT) - bounds.position;
		Vector3 LIMIT = bounds.localScale;

		int MOVING_INSIDE_X = Convert.ToInt32(Mathf.Abs(OFFSET.x) <= LIMIT.x);
		int MOVING_INSIDE_Y = Convert.ToInt32(Mathf.Abs(OFFSET.y) <= LIMIT.y);
		int MOVING_INSIDE_Z = Convert.ToInt32(Mathf.Abs(OFFSET.z) <= LIMIT.z);

		handle.position += new Vector3(MOVING_INSIDE_X * MOVEMENT.x, MOVING_INSIDE_Y * MOVEMENT.y, MOVING_INSIDE_Z * Z_MOVEMENT);
	}
}
