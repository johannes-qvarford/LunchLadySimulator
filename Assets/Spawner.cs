using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawning;
	private GameObject leftArm;
	private GameObject rightArm;
	void Start () {
		leftArm = GameObject.FindWithTag(Tags.LEFT_ARM);
		rightArm = GameObject.FindWithTag(Tags.RIGHT_ARM);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M))
		{
			GameObject g = (GameObject)Instantiate(spawning,transform.position,transform.rotation);
			SpawnedJunk.BecomeParentToGameObject(g);
			leftArm.SendMessage("AddGrabable", g, SendMessageOptions.RequireReceiver);
			rightArm.SendMessage("AddGrabable", g, SendMessageOptions.RequireReceiver);
		}
	}
}
