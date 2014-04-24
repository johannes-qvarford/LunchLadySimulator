using UnityEngine;
using System.Collections.Generic;

public class QueueControl : MonoBehaviour
{
	public GameObject instantiateObject;
	public float repeatTime = 10.0f;
	public float startTime = 0.0f;
	public float maxNpcDistance = 0.2f;
	public int maxPhysicalNpcsInQueue = 5;
	
	private List<GameObject> npcs = new List<GameObject>();
	private const float INFINITE = 10000;
	private bool npcIsWaitingForFood = false;
	private int actualNpcsInQueue = 0;
	
	void Start()
	{
		InvokeRepeating("NewNpcCreated", startTime, repeatTime);
	}
	
	void Update()
	{
		Vector3 lastPosition = new Vector3(INFINITE, INFINITE, INFINITE);
		if(npcIsWaitingForFood)
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
	
	private void AddNpcInPhysicalQueue()
	{
		GameObject npc = SpawnedJunk.Instantiate(instantiateObject, transform.position, transform.rotation);
		npc.transform.position = transform.position;
		npc.SendMessage("QueueControlChanged", gameObject, SendMessageOptions.RequireReceiver);
		npc.SendMessage("MoveChanged", true, SendMessageOptions.RequireReceiver);
		npcs.Add(npc);
	}
	
	private void NewNpcCreated()
	{
		if(npcs.Count < maxPhysicalNpcsInQueue)
		{
			AddNpcInPhysicalQueue();
		}
		actualNpcsInQueue++;
	}
	
	private void NpcDestroyed(GameObject npc)
	{
		npcs.Remove(npc);
		actualNpcsInQueue--;
		if(actualNpcsInQueue > 0)
		{
			AddNpcInPhysicalQueue();
		}
		GameObject.Destroy(npc);
	}
	
	private void NpcGotFood()
	{
		npcIsWaitingForFood = false;
		foreach(GameObject g in npcs)
		{
			g.SendMessage("MoveChanged", true, SendMessageOptions.RequireReceiver);
		}
	}
	
	private void NpcStopped(GameObject npc)
	{
		npcIsWaitingForFood = true;
		npc.SendMessage("MoveChanged", false, SendMessageOptions.RequireReceiver);
	}
}
