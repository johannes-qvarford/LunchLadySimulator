using UnityEngine;
using System.Collections;

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
