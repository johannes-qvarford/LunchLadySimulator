using UnityEngine;
using System.Collections;




public class QueueController : MonoBehaviour {

	public Vector3 directionVector;
	public int queueDistance = 1;
	public string[] queueStopList;
	
	bool stop = false;	
	
	public QueueSpawner queueSpawner;


	void Start () 
	{
		

		
	}
	

	void Update () 
	{
		if(IsObjectInFront ()){
			transform.GetComponent<NPCMovement>().walk = false;
			
		}else{
			transform.GetComponent<NPCMovement>().walk = true;
		}
		
		if(Input.GetKeyDown(KeyCode.U) && stop)
		{
			transform.GetComponent<NPCMovement>().stop = false;
			LeaveStop();
		}
		
	}



	void OnTriggerEnter(Collider col)
	{
		
		GameObject OTHER = col.gameObject;
		Vector3 turnAngle;
		Quaternion changeRotation;
		switch(OTHER.tag)
		{	


			//NPC ÄR LÄNGST FRAM I KÖN

			case Tags.STOP:

				transform.GetComponent<NPCMovement>().stop = true;
				stop = true;
				EnterStop();
				break;
			
			//NPC SKA SVÄNGA ÅT VÄNSTER
			case Tags.TURNLEFT:
				turnAngle = new Vector3(0,270,0);
				changeRotation = transform.localRotation;
				changeRotation.eulerAngles += turnAngle;
				transform.localRotation = changeRotation;

				break;
		
			//NPC SKA SVÄNGA ÅR HÖGER
			case Tags.TURNRIGHT:
				turnAngle = new Vector3(0,90,0);
				changeRotation = transform.localRotation;
				changeRotation.eulerAngles += turnAngle;
				transform.localRotation = changeRotation;
				break;
			case Tags.DESTROY:
				queueSpawner.NPCDestroyed();
				Destroy(gameObject);
				break;
			default:
				break;
		}
		
		
	}
	
	/*
	* Funktion för att kolla om ett objekt är framför objektet.
	* Arrayen queueStopList innehåller alla objekts taggar NPC ska reagera på
	*/
	
	bool IsObjectInFront()
	{
		RaycastHit hit;
		
		
		Vector3 raycastLineVector = transform.position+(directionVector*queueDistance);
		
		Debug.DrawLine(transform.position,raycastLineVector,Color.red);

		if(Physics.Raycast(transform.position,directionVector,out hit,queueDistance))
		{
			foreach(string s in queueStopList)
			{
				
				if(s == hit.collider.tag)
				{
					return true;
				}
			}
			
		}
		return false;

	}
	
	//SKRIV LEAVE STOPP KODEN HÄR STEFAN

	void LeaveStop()
	{
		


	}
	//SKRIV ENTER STOPP KODEN HÄR STEFAN

	void EnterStop()
	{


	}
	

}
