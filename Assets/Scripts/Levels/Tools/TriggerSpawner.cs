using UnityEngine;
using System.Collections;

public class TriggerSpawner : MonoBehaviour
{
	public GameObject spawnObject;
	
	void OnTriggerStay(Collider col)
	{
		GameObject OTHER = col.gameObject;
		if(OTHER.tag == Tags.TOOL && OTHER.GetComponent(typeof(ToolHitbox)) != null)
		{
			GameObject RECEIVER = OTHER.transform.parent.parent.Find("Spawner").gameObject;
			RECEIVER.SendMessage("OnSpawnObjectChanged", spawnObject, SendMessageOptions.RequireReceiver);
			RECEIVER.SendMessage("OnSpawnAgain", SendMessageOptions.RequireReceiver);
			//SendMessage("TriggerSound");
			//TODO: uncomment when message has receiver
			//gameObject.SendMessage("TriggerSound");
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.tag != Tags.FOOD) 
		{
			SendMessage("TriggerSound",SendMessageOptions.RequireReceiver);
		}
	}
	void OnTriggerExit(Collider col)
	{
		
		if(col.tag != Tags.FOOD) 
		{
			SendMessage("TriggerSound",SendMessageOptions.RequireReceiver);
		}
	}
}
