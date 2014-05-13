using UnityEngine;
using System.Collections;

public class GrabableBehaviour : MonoBehaviour
{
//	public Vector3 moveOffsetOnGrabTool = new Vector3(0, 0.005f, 0);
//	public Vector3 moveOffsetOnGrabPlate = new Vector3(0, -0.04f, 0.2f); //z should be -z, but in the inspector it shows -z when it's really z
	public Vector3 moveOffsetOnGrab = new Vector3(0, 0, 0);
	public Renderer outline;
}
