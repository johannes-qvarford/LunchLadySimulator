using UnityEngine;
using System.Collections;

public class MenuCameraRotation : MonoBehaviour {
	private float rotationTarget = 0;
	public float edgePercentage;
	public float rotationAmmount;
	public float smooth;
	public float delay;
	private float coolDown = 0;
	private GameObject soundMgr;
	private Collider lastHitButton = null;
	
	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		soundMgr = GameObject.FindWithTag(Tags.GUISOUND);
	}
	
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit))
		{
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
		if(ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_LEFT) && coolDown < 0)
		//if(Input.GetKeyDown(KeyCode.A) || (coldDown < 0 && Input.mousePosition.x < edgePercentage))
		{
			coolDown = delay;
			rotationTarget -= rotationAmmount;
			soundMgr.SendMessage("TriggerGuiSound",MenuButtonGraphic.GuiSoundMode.SLIDE,SendMessageOptions.RequireReceiver);
			
		}
		if(ArmInputManager.IsDown(ArmInputManager.Action.NEXT_OPTION_RIGHT) && coolDown < 0)
		//if(Input.GetKeyDown(KeyCode.D) || (coolDown < 0 && Input.mousePosition.x > Screen.width - edgePercentage))
		{
			coolDown = delay;
			rotationTarget += rotationAmmount;
			soundMgr.SendMessage("TriggerGuiSound",MenuButtonGraphic.GuiSoundMode.SLIDE,SendMessageOptions.RequireReceiver);
		}
		Quaternion target = Quaternion.Euler(0, rotationTarget, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
	}
}
