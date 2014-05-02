using UnityEngine;
using System.Collections;

public class SpawnZone : MonoBehaviour
{
	public GameObject spawnObject;
	
	void OnTriggerEnter(Collider col)
	{
		Debug.Log("col " + col);
		GameObject OTHER = col.gameObject;
		if(OTHER.tag == Tags.TOOL && OTHER.GetComponent(typeof(ToolHitbox)) != null)
		{
			GameObject RECEIVER = OTHER.transform.parent.parent.Find("Spawner").gameObject;
			RECEIVER.SendMessage("OnSpawnObjectChanged", spawnObject, SendMessageOptions.RequireReceiver);
			RECEIVER.SendMessage("OnSpawnStatusChanged", true, SendMessageOptions.RequireReceiver);
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		GameObject OTHER = col.gameObject;
		if(OTHER.tag == Tags.TOOL && OTHER.GetComponent(typeof(ToolHitbox)) != null)
		{
			GameObject RECEIVER = OTHER.transform.parent.parent.Find("Spawner").gameObject;
			RECEIVER.SendMessage("OnSpawnStatusChanged", false, SendMessageOptions.RequireReceiver);
		}
	}
}
