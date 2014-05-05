﻿using UnityEngine;
using System.Collections;

public class SpawnZone : MonoBehaviour
{
	public GameObject spawnObject;
	
	void OnTriggerEnter(Collider col)
	{
		Debug.Log("hello");
		GameObject OTHER = col.gameObject;
		if(OTHER.tag == Tags.TOOL && OTHER.GetComponent(typeof(ToolHitbox)) != null)
		{
			GameObject RECEIVER = OTHER.transform.parent.Find("Spawner").gameObject;
			RECEIVER.SendMessage("OnSpawnObjectChanged", spawnObject, SendMessageOptions.RequireReceiver);
			RECEIVER.SendMessage("OnSpawnStatusChanged", true, SendMessageOptions.RequireReceiver);
			gameObject.SendMessage("TriggerSound");
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		GameObject OTHER = col.gameObject;
		if(OTHER.tag == Tags.TOOL && OTHER.GetComponent(typeof(ToolHitbox)) != null)
		{
			GameObject RECEIVER = OTHER.transform.parent.Find("Spawner").gameObject;
			RECEIVER.SendMessage("OnSpawnStatusChanged", false, SendMessageOptions.RequireReceiver);
			gameObject.SendMessage("TriggerSound");
		}
	}
}
