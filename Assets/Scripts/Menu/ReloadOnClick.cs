using UnityEngine;
using System.Collections;

public class ReloadOnClick : MonoBehaviour {

	void OnMouseDown()
	{
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	void OnClick()
	{
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevelName);
	}
}
