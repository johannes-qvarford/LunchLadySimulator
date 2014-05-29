using UnityEngine;
using System.Collections;

public class MenuChange : MonoBehaviour {
	public GameObject thisMenu;
	public GameObject targetMenu;
	
	//right now we can't go back from level select
	private bool done;
	/*
	void OnMouseUpAsButton()
	{
		targetMenu.SetActive(true);
		thisMenu.SetActive(false);
	}
	*/
	
	void Update()
	{
		if(done == false && ArmInputManager.IsDown(ArmInputManager.Action.CONFIRM))
		{
			targetMenu.SetActive(true);
			thisMenu.SetActive(false);
			done = true;
		}
	}
}
