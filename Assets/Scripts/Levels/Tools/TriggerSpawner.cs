using UnityEngine;
using System.Collections;

/** Script that makes a tool with hitboxes start spawning food when inside the trigger.

	The following assumptions are made in the script:
		Any colliding game object with an attached ToolHitbox and tag Tool has:
			A parents cousin named "Spawner"
			this cousin has scripts with a a non-zero number of 
			"void OnSpawnObjectChanged(GameObject)" and "void OnSpawnAgain()" methods.

	The attached game object has scripts with a non-zero number of
		"void TriggerSound()" methods.
**/
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
