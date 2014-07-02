using UnityEngine;
using System.Collections;

/*
 * Class for rotating the camera around.
 * The camera is surrounded by a bunch of buttons,
 * and every time a new one is in front of it, it notifies it that it sees it(activating it),
 * and notifies the previously seen button that it no longer sees it(deactivating it).
 */
public class MenuCameraRotation : MonoBehaviour
{
	private float rotationTarget = 0;
	public float edgePercentage;
	public float rotationAmmount;
	public float smooth;
	public float delay;
	private float coolDown = 0;
	private GameObject soundMgr;
	private Collider lastHitButton = null;
	
	void Start ()
	{
		/*
		 * Not sure if this is needed.
		 */
		QualitySettings.vSyncCount = 0;
		
		soundMgr = GameObject.FindWithTag(Tags.GUISOUND);
	}
	
	void Update ()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit))
		{
			/*
			 * Only send SelectedChanged when switching to a new button.
			 */
			if(lastHitButton != hit.collider)
			{
				hit.collider.BroadcastMessage("SelectedChanged", true, SendMessageOptions.DontRequireReceiver);
				if(lastHitButton != null)
				{
					lastHitButton.BroadcastMessage("SelectedChanged", false, SendMessageOptions.DontRequireReceiver);
				}
			}
			lastHitButton = hit.collider;
		} 
	
		coolDown -= Time.deltaTime;
		if(ActionInputManager.ActionIsPerformed(ActionInputManager.Action.OPTION_LEFT) && coolDown < 0)
		{
			coolDown = delay;
			rotationTarget -= rotationAmmount;
			soundMgr.SendMessage("TriggerGuiSound", GuiSoundMode.SLIDE,SendMessageOptions.RequireReceiver);
		}
		
		if(ActionInputManager.ActionIsPerformed(ActionInputManager.Action.OPTION_RIGHT) && coolDown < 0)
		{
			coolDown = delay;
			rotationTarget += rotationAmmount;
			soundMgr.SendMessage("TriggerGuiSound", GuiSoundMode.SLIDE,SendMessageOptions.RequireReceiver);
		}
		
		/*
		 * Rotate towards a target.
		 */
		Quaternion target = Quaternion.Euler(0, rotationTarget, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
	}
}
