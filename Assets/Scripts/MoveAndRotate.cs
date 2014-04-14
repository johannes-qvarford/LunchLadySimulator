using UnityEngine;
using System.Collections;

public class MoveAndRotate : MonoBehaviour {

	public int upPower = 300;
	public int sidePower = 300;
	void FixedUpdate() {
		if (Input.GetKey (KeyCode.E)) {
			rigidbody.AddForce (0, upPower, 0);
		}
		if (Input.GetKey (KeyCode.A)) {
			rigidbody.AddForce (-sidePower, 0, 0);
		}
		if (Input.GetKey (KeyCode.D)) {
			rigidbody.AddForce (sidePower, 0, 0);
		}
		if (Input.GetKey (KeyCode.W)) {
			rigidbody.AddForce (0, 0, sidePower);
		}
		if (Input.GetKey (KeyCode.S)) {
			rigidbody.AddForce (0, 0, -sidePower);
		}
	}
}
