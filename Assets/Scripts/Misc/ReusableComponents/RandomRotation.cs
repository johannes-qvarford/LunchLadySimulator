using UnityEngine;
using System.Collections;

/**
 * Rotate randomly around the x axis at creating time.
 * 
 * TODO: Rename to RandomYRotation.
 **/
public class RandomRotation : MonoBehaviour {
	Transform start;
	float yRotate;

	void Start () 
	{
		yRotate = Random.Range(0,360);
		start = transform;
		transform.rotation = Quaternion.Euler(start.rotation.x, yRotate ,start.rotation.z);
	}
}
