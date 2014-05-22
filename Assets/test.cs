using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.N))
		{
			Debug.Log("Playing SOund");
			SendMessage("TriggerSound");
		}
		if(Input.GetKeyDown(KeyCode.M))
		{
			Debug.Log("Changing Parameter");
			SendMessage("ChangeParameter");
		}
	
	}
}
