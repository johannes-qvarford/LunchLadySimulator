using UnityEngine;
using System.Collections;
using System.Linq;
using UnityExtensions;

/** 
 * Behaviour for spawning plates in a plate stack at regular intervals.
 * Plates are spawned when there are too few plates in plate stack,
 * and there are to few plates on the work bench.
 * 
 * This script makes the following assumptions.
 * * There is an arm tagged with Tags.LEFT_ARM, and one of its script has a method named AddGrabable,
 *    used to notify BOTH arms that there is a new grabable in the world.
 * 
 * * There are at least two children to the bound game object.
 * ** SpawnZone is a child and is placed where new plates are expected to spawn.
 * ** MaxPlates is a child that has a box collider which encapsulates the area where "plates are on the work bench".
 * 
 * * There is singleton SpawnedJunk which is bound to a single game object,
 *    where created plates are placed in the heirarcy.
 * 
 * TODO: Generally rewrite the code to be more intuitive and readable in a few places.
 **/
public class SpawnPlateInStack : MonoBehaviour
{
	public GameObject spawnObject;
	public int items; /* TODO: rename to maxPlatesInStack */
	public LayerMask mask;
	public float interval;
	public int maxPlatesOnWorkbench = 30;
	public float checkSphereWorkbenchRadius = 1.8f;
	public float checkSphereStackRadius = 0.5f;
	public float countInterval = 0.5f;
	public float spawnInterval = 0.5f;

	private GameObject arms;
	private GameObject spawnZone;
	private BoxCollider maxPlates; /* TODO: Rename to something more fitting like workbenchZone (including child object in prefab, not just variable name) */
	private int numPlatesInStack;
	private int numCollidersPerPlate;
	public int numPlatesOnWorkbench;

	void Start () 
	{
		numCollidersPerPlate = spawnObject.transform.FindChild("Colliders").childCount;
		arms = GameObject.FindWithTag(Tags.ARMS);
		spawnZone = gameObject.transform.FindChild("SpawnZone").gameObject;
		maxPlates = transform.FindChild("MaxPlates").gameObject.GetComponent<BoxCollider>();
		InvokeRepeating("CountPlatesUpdate", 0, countInterval);
		InvokeRepeating("SpawnPlateUpdate", 0, spawnInterval);
	}

	private void CountPlatesUpdate() 
	{
		numPlatesOnWorkbench = Physics.OverlapSphere(transform.position, checkSphereWorkbenchRadius, mask.value)
			.Where(c => c.IsPlateCollider() && OnWorkbench(c.transform.position))
			.Count()
			/ numCollidersPerPlate;
		numPlatesInStack = Physics.OverlapSphere(transform.position, checkSphereStackRadius, mask.value)
			.Where(c => c.IsPlateCollider() && InStack(c.transform.position))
			.Count()
			/ numCollidersPerPlate;
	}
	
	private void SpawnPlateUpdate()
	{
		if(numPlatesInStack < items && numPlatesOnWorkbench < maxPlatesOnWorkbench)
		{
			GameObject g = (GameObject)Instantiate(spawnObject, spawnZone.transform.position, spawnZone.transform.rotation);
			g.GetComponent<CheckPlateInStack>().stack = gameObject;
			SpawnedJunk.BecomeParentToGameObject(g);

			arms.SendMessage("AddGrabable", g.gameObject, SendMessageOptions.RequireReceiver);
		}
	}

	private bool OnWorkbench(Vector3 position)
	{
		return maxPlates.bounds.Contains(position);
	}

	private bool InStack(Vector3 position)
	{
		return gameObject.GetComponent<BoxCollider>().bounds.Contains(position);
	}
}
