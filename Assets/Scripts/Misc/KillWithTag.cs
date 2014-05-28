using UnityEngine;
using System.Collections;

public class KillWithTag : MonoBehaviour
{
	public string killTag;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == killTag)
		{
			Destroy(collision.gameObject);
		}
	}
}

