using UnityEngine;
using System.Collections;

public class ResumeOnClick : MonoBehaviour {
	public ShowPauseMenu menu;
	
	void OnInputClick()
	{
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	void OnMouseDown()
	{
		menu.returnToGame ();
	}
}
