using UnityEngine;
using System.Collections.Generic;

public class QueueControl : MonoBehaviour
{
	public GameObject instantiateObject;
	public float repeatTime = 10.0f;
	public float startTime = 0.0f;
	public float maxNpcDistance = 0.2f;
	
	private List<GameObject> npcs = new List<GameObject>();
	private const float INFINITE = 10000;
	private bool npcIsWaiting = false;
	
	void Start()
	{
		InvokeRepeating("CreateNewNPC", startTime, repeatTime);
	}
	
	void Update()
	{
		Vector3 lastPosition = new Vector3(INFINITE, INFINITE, INFINITE);
		if(npcIsWaiting)
		{
			foreach(GameObject npc in npcs)
			{
				if((npc.transform.position - lastPosition).magnitude < maxNpcDistance)
				{
					npc.SendMessage("MoveChanged", false, SendMessageOptions.RequireReceiver);
				}
				lastPosition = npc.transform.position;
			}
		}
	}
	
	private void CreateNewNPC()
	{
		GameObject npc = SpawnedJunk.Instantiate(instantiateObject, transform.position, transform.rotation);
		npc.transform.position = transform.position;
		npc.SendMessage("QueueControlChanged", gameObject, SendMessageOptions.RequireReceiver);
		npc.SendMessage("MoveChanged", true, SendMessageOptions.RequireReceiver);
		npcs.Add(npc);
	}
	
	private void NpcDestroyed(GameObject npc)
	{
		npcs.Remove(npc);
		GameObject.Destroy(npc);
	}
	
	private void NpcGotFood()
	{
		npcIsWaiting = false;
		foreach(GameObject g in npcs)
		{
			g.SendMessage("MoveChanged", true, SendMessageOptions.RequireReceiver);
		}
	}
	
	private void NpcStopped(GameObject npc)
	{
		npcIsWaiting = true;
		npc.SendMessage("MoveChanged", false, SendMessageOptions.RequireReceiver);
	}
}
