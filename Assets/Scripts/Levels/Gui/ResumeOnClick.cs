using UnityEngine;
using System.Collections;

public class ResumeOnClick : MonoBehaviour {
	public ShowPauseMenu menu;
	void OnMouseDown()
	{
		menu.returnToGame ();
	}
}
