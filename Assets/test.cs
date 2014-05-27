using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	private GameObject sounds;
	void Start () {
		sounds = GameObject.FindWithTag(Tags.NPCSOUNDBANK);
		GetComponent<SoundCheck>().setFmodAsset(sounds.GetComponent<SoundBank>().GetNpcSound("Male Nerd"));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.N))
		{
			SendMessage("TriggerSound",SendMessageOptions.RequireReceiver);	
		}
		if(Input.GetKeyDown(KeyCode.M))
		{
			SendMessage("ChangeParameter",SendMessageOptions.RequireReceiver);
		}
	
	}
}
