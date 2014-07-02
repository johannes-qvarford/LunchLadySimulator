using UnityEngine;
using System.Collections;
using UnityExtensions;

/** 
  * Script that destroys any object that has a certain tag, that collides with its attached game object.
  * It ignores plates that are in their plate stack.
  *
  * TODO: Change level so that killzones don't intersect with the plate stack, and remove the special condition.
  **/
public class KillWithTag : MonoBehaviour
{
	public string killTag;

	void OnCollisionEnter(Collision collision)
	{
		bool badIdea = collision.gameObject.IsPlateInStack();
		
		if(badIdea == false && collision.collider.gameObject.tag == killTag)
		{
			Destroy(collision.gameObject);
		}
	}
}

