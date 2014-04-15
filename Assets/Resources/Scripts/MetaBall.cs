using UnityEngine;
using System.Collections;

public class MetaBall : MonoBehaviour {

	public float time;
	public Vector3 inputPosition;
	public Vector3 resolution;

	/* Gets a vec3 and divides 1 with all the coordinates 
	 * raised by a power of 2 
	 * added together.
	 */
	float Ball(Vector3 position)
	{
		return 1.0f/(Mathf.Pow(position.x, 2.0f) + Mathf.Pow(position.y, 2.0f) + Mathf.Pow(position.z, 2.0f));
	}
	
	float Blob(Vector3 position, Vector3 point, float radius)
	{
		float temp = Mathf.Pow(position.x - point.x, 2.0f) + Mathf.Pow(position.y - point.y, 2.0f) + Mathf.Pow(position.z - point.z, 2.0f);
		float result = 0f;
		if(temp < Mathf.Pow(radius, 2.0f))
		{
			float distance = Mathf.Sqrt(Mathf.Pow(position.x - point.x, 2.0f) + Mathf.Pow(position.y - point.y, 2.0f) + Mathf.Pow(position.z - point.z, 2.0f)) / radius;
			result = Mathf.Pow((1.0f - Mathf.Pow(distance, 2.0f)), 2.0f);
		}
		return result;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
