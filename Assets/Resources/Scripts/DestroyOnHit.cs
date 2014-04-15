using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour {

	void OnTriggerEnter(Collider collision)
	{
		if(collision.tag == "Destroy")
			Destroy(gameObject);
	}
}
