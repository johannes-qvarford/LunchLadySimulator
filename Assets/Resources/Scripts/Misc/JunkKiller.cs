using UnityEngine;
using System.Collections;

public class JunkKiller : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Food" || collision.gameObject.tag == "Plate")
		{
			Destroy(collision.gameObject);
		}
	}
}

