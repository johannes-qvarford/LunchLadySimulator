using UnityEngine;
using System.Collections;

public class MagnusControls : MonoBehaviour {

	public float MoveForce;
	public float JumpForce;
	public float ShootForce;
	public float FloorDrag;
	public bool ShootInAir;
	public GameObject floor;
	
	private float floorDragMulti;
	private bool onFloor = false;
	// Use this for initialization
	
	void OnTriggerEnter(Collider aCol)
	{
		if(aCol.gameObject == floor)
		{
			onFloor = true;
		}
	}
	void OnTriggerExit(Collider aCol)
	{
		if(aCol.gameObject == floor)
		{
			onFloor = false;
		}
	}
	
	void Start () {
		floorDragMulti = 1.0f / FloorDrag;
		
		rigidbody.AddForce (transform.forward * 1000);
	}
	
	// Update is called once per frame
	void Update () {

		if(onFloor)
		{
			rigidbody.velocity = rigidbody.velocity * floorDragMulti;
			
			rigidbody.AddForce(
				new Vector3(
					-Input.GetAxis("MagnusHorizontal"),
					0,
				-Input.GetAxis("MagnusVertical")
				) * MoveForce
			);
			
			/*if(Input.GetKey ("w")){ //forward
				rigidbody.AddForce(new Vector3(0,0,-1) * MoveForce);
			}
			if(Input.GetKey ("s")){ //backward
				rigidbody.AddForce(new Vector3(0,0,1) * MoveForce);
			}
	
	
			if(Input.GetKey ("a")){ //left
				rigidbody.AddForce(new Vector3(1,0,0) * MoveForce);
			}
			if(Input.GetKey ("d")){ //right
				rigidbody.AddForce(new Vector3(-1,0,0) * MoveForce);
			}
			*/
			if(Input.GetButtonDown ("MagnusJump")){ //right
				rigidbody.AddForce(new Vector3(0,1,0) * JumpForce);
			}
	
			//Debug.Log(rigidbody.velocity.magnitude);
			if(rigidbody.velocity.magnitude > 0.25f)
			{
				Vector3 velocityXY = new Vector3(rigidbody.velocity.normalized.x, 0.0f, rigidbody.velocity.normalized.z);
				transform.localRotation = Quaternion.RotateTowards(
					transform.localRotation,
					Quaternion.FromToRotation(
						new Vector3(0,0,1), 
						velocityXY
					), 
					5f
				);
			}
		}
		if(onFloor || ShootInAir)
		{
			if(Input.GetButtonDown ("MagnusFire1")){
				rigidbody.AddForce((new Vector3(Random.Range(-0.15f,0.15f), Random.Range(0.15f,0.25f), 0.0f) + transform.forward) * ShootForce);
				//rigidbody.AddForce((new Vector3(0.0f, 0.4f, 0.0f) + transform.forward) * ShootForce);
				rigidbody.AddTorque(
					Random.Range(-0.25f,0.25f) * ShootForce, 
					Random.Range(-0.25f,0.25f) * ShootForce, 
					Random.Range(-0.25f,0.25f) * ShootForce
					);
			}
		}
	}
}
