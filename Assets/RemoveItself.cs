using UnityEngine;
using System.Collections;

public class RemoveItself : MonoBehaviour {
	public float removeTime = 1;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, removeTime);
	}
}
