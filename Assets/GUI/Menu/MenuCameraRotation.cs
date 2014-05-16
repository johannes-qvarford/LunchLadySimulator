using UnityEngine;
using System.Collections;

public class MenuCameraRotation : MonoBehaviour {
	private float rotationTarget = 0;
	public float edgePercentage;
	public float rotationAmmount;
	public float smooth;
	public float delay;
	private float coldDown = 0;
	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		coldDown -= Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.A) || (coldDown < 0 && Input.mousePosition.x < edgePercentage))
		{
			coldDown = delay;
			rotationTarget -= rotationAmmount;
		}
		if(Input.GetKeyDown(KeyCode.D) || (coldDown < 0 && Input.mousePosition.x > Screen.width - edgePercentage))
		{
			coldDown = delay;
			rotationTarget += rotationAmmount;
		}
		Quaternion target = Quaternion.Euler(0, rotationTarget, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
	}
}
