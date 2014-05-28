using UnityEngine;
using System.Collections;

public class DynamicMusic : MonoBehaviour {

	// Use this for initialization
	private GameObject mood;
	void Start () 
	{	
		mood = GameObject.FindWithTag(Tags.DYNAMICMUSIC);
	}
	
	// Update is called once per frame
	void Update () 
	{
		SendMessage("SetMood",mood.GetComponent<HappyBarController>().GetHappyPercentage(),SendMessageOptions.RequireReceiver);
	}
}
