using UnityEngine;
using System.Collections;

public class MenuChange : MonoBehaviour {
	public GameObject thisMenu;
	public GameObject targetMenu;
	
	static public bool done = false;
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
//			gameObject.SetActive(false);
		}
	}
}
