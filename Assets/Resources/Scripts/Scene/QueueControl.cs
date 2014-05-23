﻿using UnityEngine;
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
	private GameObject firstInLine;
	private float lastSpawnTime = 0;
	private bool resetCreateNPCTimer = false;


	private bool npcIsTurning = false;
	private bool moveTurnQue = false;
	
	void Start()
	{
		InvokeRepeating("NewNpcCreated", startTime, repeatTime);
	}
	
	void Update()
	{
		Vector3 lastPosition = new Vector3(INFINITE, INFINITE, INFINITE);


		
		foreach(GameObject g in npcs)
		{
			g.SendMessage("TurnMoveChanged", true, SendMessageOptions.RequireReceiver);
			
		}
		
		foreach(GameObject npc in npcs)
		{
			if((npc.transform.position - lastPosition).magnitude < maxNpcDistance)
			{
				npc.SendMessage("TurnMoveChanged", false, SendMessageOptions.RequireReceiver);
			}
			lastPosition = npc.transform.position;
		}




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
			
			if(ArmInputManager.IsDown(ArmInputManager.Action.NEXT_CUSTOMER))
			{
				firstInLine.BroadcastMessage("ShowSpeechBubble", false, SendMessageOptions.RequireReceiver);
				firstInLine.BroadcastMessage("NpcGotFood", SendMessageOptions.RequireReceiver);
				foreach(GameObject g in npcs)
				{
					g.SendMessage("MoveChanged", true, SendMessageOptions.RequireReceiver);
				}
				npcIsWaitingForFood = false;
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
		if(resetCreateNPCTimer == false && npcs.Count < maxPhysicalNpcsInQueue)
		{
			AddNpcInPhysicalQueue();
		}
		resetCreateNPCTimer = false;
	}
	
	private void NpcDestroyed(GameObject npc)
	{
		npcs.Remove(npc);
		if(npcs.Count == 0)
		{
			resetCreateNPCTimer = true;
			AddNpcInPhysicalQueue();
			
		}
		GameObject.Destroy(npc);
	}
	

	private void NpcTurning()
	{
		npcIsTurning = true;
		//	npc.SendMessage("MoveChanged", false, SendMessageOptions.RequireReceiver);
	}
	
	private void NpcStoppedTurning()
	{
		npcIsTurning = false;
		moveTurnQue = true;
			
		//	npc.SendMessage("MoveChanged", true, SendMessageOptions.RequireReceiver);
	}


	private void NpcStopped(GameObject npc)
	{
		npcIsWaitingForFood = true;
		firstInLine = npc;
		npc.SendMessage("MoveChanged", false, SendMessageOptions.RequireReceiver);
		npc.SendMessage("ShowSpeechBubble", true, SendMessageOptions.RequireReceiver);
	}
}
