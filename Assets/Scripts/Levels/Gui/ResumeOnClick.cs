using UnityEngine;
using System.Collections;

public class ResumeOnClick : MonoBehaviour {
	public ShowPauseMenu menu;
	private GameObject masterVolumeObject;
	
	void Start()
	{
		masterVolumeObject = GameObject.FindWithTag(Tags.MASTERVOLUME);
		
	}
	
	void OnClick()
	{
		//masterVolumeObject.SendMessage("SetVolumeOnSounds",1.0f ,SendMessageOptions.RequireReceiver);
		//Time.timeScale = 1;
		//menu.returnToGame ();
	}
	
	void OnMouseDown()
	{
		menu.returnToGame ();
	}
}
