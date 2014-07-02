using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Class for playing Gui sounds.
 */
public class GuiPlayer : MonoBehaviour
{
	public FMODAsset hover;
	public FMODAsset click;
	public FMODAsset slide;
	public FMODAsset SpeechBubble;
	
	private Dictionary<GuiSoundMode, FMODAsset> SOUND_MODE_TO_ASSET;
	
	void Start()
	{
		SOUND_MODE_TO_ASSET = new Dictionary<GuiSoundMode, FMODAsset>
		{
			{GuiSoundMode.HOVER, hover},
			{GuiSoundMode.CLICK, click},
			{GuiSoundMode.SLIDE, slide},
			{GuiSoundMode.SPEEECHBUBBLE, SpeechBubble}
		};
	}
	
	void TriggerGuiSound(GuiSoundMode mode)
	{
		FMOD_StudioSystem.instance.PlayOneShot(SOUND_MODE_TO_ASSET[mode], transform.position);
	}
}
