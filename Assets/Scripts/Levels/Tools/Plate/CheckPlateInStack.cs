using UnityEngine;
using System.Collections;

/*
 * Class for affecting a plate that is inside the plate stack.
 * At the momoment, the plate gets some constraints when its inside the plate stack,
 * to stop the plate stack from falling over.
 *
 * TODO: Fix the bug where plate is sometimes seemingly hovering in midair,
 * because it could fall down gentrly, but not with its current constraints.
 * Either change the constriants, or find some other way to keep the plate stack from falling over.
 */
public class CheckPlateInStack : MonoBehaviour {

	public GameObject stack;
	private RigidbodyConstraints constrain;
	void Start () 
	{
		constrain = rigidbody.constraints;
	}
	

	void Update () 
	{
		if(gameObject.GetComponent<Rigidbody>() != null)
		{
		
			if(stack.GetComponent<BoxCollider>().bounds.Contains(transform.position))
			{
				GetComponent<PlateBehaviour>().inBox = true;
				rigidbody.constraints = constrain;
			}
			else
			{
				GetComponent<PlateBehaviour>().inBox = false;
				rigidbody.constraints = RigidbodyConstraints.None;
				
			}
		}
	}
}
