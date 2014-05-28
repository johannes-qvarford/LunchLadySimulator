using UnityEngine;
using System.Collections;

public class KillSoupIfIdle : MonoBehaviour
{
	public float idleTimeUntilKill = 10.0f;

	private int numTouchingObjects = 0;
	private float lastActiveTime;
	// Use this for initialization
	void Start ()
	{
		lastActiveTime = Time.time;
	}
	
	void Update()
	{
		if(numTouchingObjects > 0)
		{
			lastActiveTime = Time.time;
		}
		
		if(lastActiveTime + idleTimeUntilKill <= Time.time)
		{
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.collider.tag == Tags.PLATE || col.collider.gameObject.layer == LayerMask.NameToLayer(Layers.CONTROL) || col.collider.tag == Tags.FOOD)
		{
			numTouchingObjects++;
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if(col.collider.tag == Tags.PLATE || col.collider.gameObject.layer == LayerMask.NameToLayer(Layers.CONTROL) || col.collider.tag == Tags.FOOD)
		{
			numTouchingObjects--;
		}
	}
}
