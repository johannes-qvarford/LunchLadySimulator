using UnityEngine;
using System.Collections;
using System.Linq;
using UnityExtensions;

/**
 * Class for spawning food in a zone.
 * Food is spawned at a set interval.
 * Every time, it tries to look for a few places within an area to put a new object without it colliding with another object.
 * No objects are spawned if there are at least a certain number of them on the work bench.
 * 
 * TODO: Refactor out GetFoodId, IsFood and Inside to new classes FoodExtensions, and ShapeExtensions.
 **/
public class SpawnFoodInZone : MonoBehaviour 
{
	public float interval;
	public GameObject spawnObject;
	public GameObject foodObject;
	public int items;
	public LayerMask mask;
	public int numRandomSpawnTries = 5;
	public float countFoodInterval = 0.5f;

	private int numFoodInstances;
	private int tries;
	private GameObject arms;
	private GameObject spawnZone;
	private Vector3 spawnPosTest;
	private Vector3 spawnZonePos;
	private Vector3 Spawn;
	private bool foundPos;
	private BoxCollider workbenchCol;
	
	void Start() 
	{
		workbenchCol = gameObject.GetComponent<BoxCollider>();
		arms = GameObject.FindWithTag(Tags.ARMS);
		spawnZone = transform.FindChild("SpawnZone").gameObject;
		if(spawnZone == null)
		{
			Debug.LogError("Couldn't Find child SpawnZone");
			Debug.DebugBreak();
		}
		InvokeRepeating("SpawnFoodUpdate", 0, interval);
		InvokeRepeating("CountFoodUpdate", 0, countFoodInterval);
	}

	void CountFoodUpdate()
	{
		numFoodInstances = Physics.OverlapSphere(transform.position,1.8f,mask.value)
			.Where((h) => GetFoodId(h) == GetFoodId(foodObject) && Inside(workbenchCol, h.transform.position))
				.Count();	
	}

	void SpawnFoodUpdate()
	{
		if(numFoodInstances < items)
		{
			/*
			 * Try numRandomSpawnTries number of times to spawn food.
			 */
			TryAction(numRandomSpawnTries, () => 
			{
				Vector3 spawnPos = spawnZone.transform.position;
				Vector3 spawnSize = spawnZone.collider.bounds.size;

				spawnPosTest = new Vector3(
					Random.Range(spawnPos.x - spawnSize.x / 2, spawnPos.x + spawnSize.x / 2),
					Random.Range(spawnPos.y - spawnSize.y / 2, spawnPos.y + spawnSize.y / 2),
					Random.Range(spawnPos.z - spawnSize.z / 2, spawnPos.z + spawnSize.z / 2));

				float sphereRadius = spawnObject.GetComponent<BoxCollider>().size.magnitude / 2;

				int numCollisions = Physics.OverlapSphere(spawnPosTest, sphereRadius, mask.value).Count();
				if(numCollisions == 0)
				{
					GameObject g = (GameObject)Instantiate(spawnObject,spawnPosTest,transform.rotation);
					SpawnedJunk.BecomeParentToGameObject(g);

					var grabables = g.AllChildren()
						.Where((c) => c.gameObject.layer == LayerMask.NameToLayer(Layers.GRABABLE));
					foreach(var grabable in grabables)
					{
						arms.SendMessage("AddGrabable", grabable.gameObject, SendMessageOptions.RequireReceiver);
					}
					return true;
				}
				else
				{
					return false;
				}
			});
		}
	}

	delegate bool Action();

	bool TryAction(int numTimes, Action action)
	{
		for(int i = 0; i < numTimes; ++i)
		{
			if(action())
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsFood(GameObject g)
	{
		return g.GetComponent<FoodID>() != null;
	}

	private static bool IsFood(Component c)
	{
		return IsFood(c.gameObject);
	}

	private static string GetFoodId(GameObject g)
	{
		FoodID id = g.GetComponent<FoodID>();
		return id == null ? null
			: id.foodID;
	}

	private static string GetFoodId(Component c)
	{
		return GetFoodId(c.gameObject);
	}

	private static bool Inside(BoxCollider col, Vector3 pos)
	{
		return col.bounds.Contains(pos);
	}
}

 
	

