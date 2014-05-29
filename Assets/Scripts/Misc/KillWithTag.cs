using UnityEngine;
using System.Collections;

public class KillWithTag : MonoBehaviour
{
	public string killTag;

	void OnCollisionEnter(Collision collision)
	{
		PlateBehaviour b = collision.collider.gameObject.GetComponent<PlateBehaviour>();
		bool badIdea = b != null && b.inBox == true;
		
		if(badIdea == false && collision.collider.gameObject.tag == killTag)
		{
			Destroy(collision.gameObject);
		}
	}
}

