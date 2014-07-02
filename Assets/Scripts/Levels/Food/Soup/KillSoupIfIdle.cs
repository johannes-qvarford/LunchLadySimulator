using UnityEngine;
using System.Collections;

/* Kills the attached soup particle if it's idle.
 * It's idle if it doesn't touch plates, other food, or part of an arm (including attached tool) for long.
 * 
 * TODO: Make it so that soup is destroyed when it hits the bench instead.
 **/
public class KillSoupIfIdle : MonoBehaviour
{
	public float idleTimeUntilKill = 10.0f;

	private int numTouchingObjects = 0;
	private float lastActiveTime;

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
