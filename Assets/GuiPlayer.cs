using UnityEngine;
using System.Collections;

public class GuiPlayer : MonoBehaviour {

	public FMODAsset hover,click,slide;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void TriggerGuiSound(MenuButtonGraphic.GuiSoundMode mode)
	{
		if(mode == MenuButtonGraphic.GuiSoundMode.HOVER)
		{
		FMOD_StudioSystem.instance.PlayOneShot(hover,transform.position);
		}
		if(mode == MenuButtonGraphic.GuiSoundMode.CLICK)
		{
			FMOD_StudioSystem.instance.PlayOneShot(click,transform.position);
		}
		if(mode == MenuButtonGraphic.GuiSoundMode.SLIDE)
		{
			FMOD_StudioSystem.instance.PlayOneShot(slide,transform.position);
		}
	}
}
