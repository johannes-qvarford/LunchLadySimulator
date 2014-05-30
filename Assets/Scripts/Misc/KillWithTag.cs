using UnityEngine;
using System.Collections;

/** Script that destroys any object that has a certain tag, that collides with its attached game object.
**/
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

