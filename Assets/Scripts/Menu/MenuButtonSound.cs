using UnityEngine;
using UnityExtensions;

/*
 * Class for playing sound when a button is selected or clicked.
 */
public class MenuButtonSound : MonoBehaviour
{
	private DoOncer setSoundManagerOnce = new DoOncer();
	private GameObject soundManager;
	
	void SelectedChanged(bool yes)
	{
		if(yes)
		{
			setSoundManagerOnce.doOnce(() => { soundManager = GameObject.FindWithTag(Tags.GUISOUND); } );
			soundManager.SendMessage("TriggerGuiSound", GuiSoundMode.HOVER, SendMessageOptions.RequireReceiver);
		}
	}

	void OnClick()
	{
		setSoundManagerOnce.doOnce(() => { soundManager = GameObject.FindWithTag(Tags.GUISOUND); } );
		soundManager.SendMessage("TriggerGuiSound", GuiSoundMode.CLICK, SendMessageOptions.RequireReceiver);
	}
}
