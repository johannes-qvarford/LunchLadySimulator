using UnityEngine;
using System.Collections;

public class InstantiateAtKeyPress : MonoBehaviour
{
	public GameObject create;
	public KeyCode keyCode;

	void Update()
	{
		if(Input.GetKeyDown(keyCode))
		{
			SpawnedJunk.Instantiate(create, transform.position, transform.rotation);
		}
	}
}
