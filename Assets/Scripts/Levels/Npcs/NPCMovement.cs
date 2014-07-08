using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {
	

	//Walk används för ett kontinuerligt kollande, tex raycast för att kolla om en NPC är framför i kön.
	//Stop används för ett engångs stopp, tex stoppet i kön.
	public bool walk = false;
	public bool stop = false;

	public Vector3 walkDirectionVector;
	public float acceleration;
	public float maxSpeed;
	


	void Start () {
	
	}
	
	
	void Update () {
		
		updatePosition ();

		


	}
	

	void updatePosition()
	{
		
	
		if(rigidbody.velocity.magnitude < maxSpeed-acceleration && !stop && walk)
		{
			rigidbody.AddForce(Vector3.right * acceleration, ForceMode.VelocityChange);
		}
		else if(rigidbody.velocity.magnitude < maxSpeed && !stop && walk)
		{
			float accelerationFix = maxSpeed - rigidbody.velocity.magnitude;
			rigidbody.AddForce(Vector3.right * accelerationFix, ForceMode.VelocityChange);
		}
		else if(stop || !walk)
		{
			rigidbody.velocity = Vector3.zero;
		}
		
	}

	

	



}
