using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public int ForceMult = 100;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("q")){
			rigidbody.AddForce((new Vector3(Random.Range(-0.15f,0.15f), Random.Range(0.15f,0.25f)) + transform.forward) * ForceMult);
			rigidbody.AddTorque(Random.Range(-250,250),Random.Range(-250,250),Random.Range(-250,250));
			
			
				//(new Vector3(Random.Range(-15,15),Random.Range(-15,15),Random.Range(-15,15)));
		}
	
	}
}
