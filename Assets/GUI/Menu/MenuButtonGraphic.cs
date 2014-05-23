using UnityEngine;
using System.Collections;

public class MenuButtonGraphic : MonoBehaviour {
	public GameObject defaultObject;
	public GameObject overObject;
	public GameObject clickingObject;

	private bool mouseOver;
	private bool clicking;
	
	void SelectedChanged(bool on)
	{
		mouseOver = on;
		updateState();
	}
	
	void Update()
	{
		clicking = ArmInputManager.IsDown(ArmInputManager.Action.CONFIRM);
	}
	
	void OnEnable ()
	{
		showDefault ();
		mouseOver = false;
		clicking = false;
	}

	private void showDefault()
	{
		turnOffAll ();
		defaultObject.renderer.enabled = true;
	}
	private void showMouseOver()
	{
		turnOffAll ();
		overObject.renderer.enabled = true;
	}
	private void showMouseDown()
	{
		turnOffAll ();
		clickingObject.renderer.enabled = true;
	}
	private void turnOffAll()
	{
		defaultObject.renderer.enabled = false;
		overObject.renderer.enabled = false;
		clickingObject.renderer.enabled = false;
	}

	private void updateState()
	{
		if(mouseOver == false)
		{
			showDefault();
		}
		else
		{
			if(clicking == true)
			{
				showMouseDown();
			}
			else
			{
				showMouseOver();
			}
		}
	}
	void OnMouseOver()
	{
		mouseOver = true;
		updateState ();
	}
	void OnMouseExit()
	{
		mouseOver = false;
		updateState ();
	}
	
	
	void OnMouseDown()
	{
		clicking = true;
		updateState ();
	}
	void OnMouseUp()
	{
		clicking = false;
		updateState ();
	}
}
