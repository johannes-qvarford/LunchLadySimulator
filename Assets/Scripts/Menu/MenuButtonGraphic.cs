using UnityEngine;
using System.Collections;

public class MenuButtonGraphic : MonoBehaviour {
	public GameObject defaultObject;
	public GameObject overObject;
	public GameObject clickingObject;
	private GameObject SoundMgr;
	private bool mouseOver;
	private bool clicking;
	
	public enum GuiSoundMode {HOVER,CLICK,SLIDE,SPEEECHBUBBLE};
	
	void Start()
	{
		SoundMgr = GameObject.FindWithTag(Tags.GUISOUND);
	}
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
		SoundMgr.SendMessage("TriggerGuiSound",GuiSoundMode.HOVER,SendMessageOptions.RequireReceiver);
	}
	private void showMouseDown()
	{
		turnOffAll ();
		clickingObject.renderer.enabled = true;
		SoundMgr.SendMessage("TriggerGuiSound",GuiSoundMode.CLICK,SendMessageOptions.RequireReceiver);
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
		if(mouseOver == false)
		{
			mouseOver = true;
			updateState ();
		}
	}
	void OnMouseExit()
	{
		if(mouseOver == true)
		{
			mouseOver = false;
			updateState ();
		}
	}
	
	
	void OnMouseDown()
	{
		if(clicking == false)
		{
			clicking = true;
			updateState ();
		}
	}
	void OnMouseUp()
	{
		if(clicking == true)
		{
			clicking = false;
			updateState ();
		}
	}
}
