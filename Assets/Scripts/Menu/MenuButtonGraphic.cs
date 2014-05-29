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
		setSoundManagerIfNotAlready();
	}
	
	void OnClick()
	{
		SoundMgr.SendMessage("TriggerGuiSound",GuiSoundMode.CLICK,SendMessageOptions.RequireReceiver);
	}
	
	void Update()
	{
		clicking = ArmInputManager.IsDown(ArmInputManager.Action.CONFIRM);
	}
	
	void OnEnable ()
	{
		showDefault();
		mouseOver = false;
		clicking = false;
	}
	
	private void setSoundManagerIfNotAlready()
	{
		if(SoundMgr == null)
		{
			SoundMgr = GameObject.FindWithTag(Tags.GUISOUND);
		}
	}

	private void showDefault()
	{
		turnOffAll ();
		defaultObject.active = true;
	}
	private void showMouseOver()
	{
		turnOffAll ();
		overObject.active = true;
		setSoundManagerIfNotAlready();
		SoundMgr.SendMessage("TriggerGuiSound",GuiSoundMode.HOVER,SendMessageOptions.RequireReceiver);
	}
	private void showMouseDown()
	{
		turnOffAll();
		clickingObject.active = true;
	}
	private void turnOffAll()
	{
		defaultObject.active = false;
		overObject.active = false;
		clickingObject.active = false;
	}

	private void updateState()
	{
		if(mouseOver == false)
		{
			showDefault();
			return;
		}
		if(clicking == true)
		{
			showMouseDown();
		}
		else
		{
			showMouseOver();
		}
	}
	void OnMouseOver()
	{
		if(mouseOver == false)
		{
			mouseOver = true;
			updateState();
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
	
	void OnSelected(bool yes)
	{
		mouseOver = yes;
		Debug.Log("selected = " + yes);
		updateState();
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
