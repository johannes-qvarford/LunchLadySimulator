using UnityEngine;
using System.Collections;
using UnityExtensions;

public class ReturnToolsToSpawn : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.IsTool())
		{
			if(collision.gameObject.GetComponent<RememberSpawnPoint>() != null)
			{
				((RememberSpawnPoint)collision.gameObject.GetComponent<RememberSpawnPoint>()).returnToSpawn();
			}
		}
	}
}
