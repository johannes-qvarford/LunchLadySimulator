using UnityEngine;
using System.Collections;

public class ReturnToolsToSpawn : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Tool")
		{
			if(collision.gameObject.GetComponent<RememberSpawnPoint>() != null)
			{
				((RememberSpawnPoint)collision.gameObject.GetComponent<RememberSpawnPoint>()).returnToSpawn();
			}
		}
	}
}
