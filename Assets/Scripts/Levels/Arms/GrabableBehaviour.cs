using UnityEngine;
using System.Collections;

/** Script that identifies an attached game object as grabable, and holds the properties of a grabable.
**/
public class GrabableBehaviour : MonoBehaviour
{
	/*
		TODO: remove as grabables should no longer be moved when grabbed.
	*/
	public Vector3 moveOffsetOnGrab = new Vector3(0, 0, 0);
	public Renderer outline;
}
