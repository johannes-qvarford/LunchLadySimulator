using UnityEngine;
using System.Collections;

public class QueBehaviour : MonoBehaviour {

	public float rayDistance = 10f;
	public float queDistance = 0f;
	private RaycastHit hitInfo;

	private NpcMove npcMove;

	// Use this for initialization
	void Start ()
	{
		
	}

	void Awake()
	{
		npcMove = GetComponent<NpcMove>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray queRay = new Ray(transform.position, transform.forward);
		if(Physics.Raycast(queRay, out hitInfo, rayDistance))
		{
			Debug.DrawLine(queRay.origin, hitInfo.point, Color.blue);
			if(hitInfo.collider.tag == "NPC")
			{
				//Debug.Log("Hit: " + hitInfo.distance);
				if(hitInfo.distance <= queDistance)
				{
					Debug.Log("QueMove = FALSE");
					npcMove.queMove = false;
				}
				else
				{
					Debug.Log("QueMove = TRUE");
					npcMove.queMove = true;

				}
			}
		}
	}
}
