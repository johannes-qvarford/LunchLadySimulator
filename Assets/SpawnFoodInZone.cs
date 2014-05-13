using UnityEngine;
using System.Collections;

public class SpawnFoodInZone : MonoBehaviour {
	// Behövs "finkod" för bröd
	public GameObject spawnObject;
	public GameObject foodObject;
	public int items;
	public LayerMask mask;
	private int quantityOfFood,tries;
	private GameObject leftArm;
	private GameObject rightArm;
	private GameObject spawnZone;
	private Vector3 spawnPosTest,spawnZonePos,Spawn;
	private bool foundPos;
	public float interval;
	
	void Start () 
	{
		leftArm = GameObject.FindWithTag(Tags.LEFT_ARM);
		rightArm = GameObject.FindWithTag(Tags.RIGHT_ARM);
		spawnZone = transform.FindChild("SpawnZone").gameObject;
		if(spawnZone == null)
		{
			Debug.Log ("Couldn't Find child SpawnZone");
		}
		StartCoroutine("SpawnFood");
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckFood();	
		
	}
	void CheckFood()
	{
		quantityOfFood=0;
		Collider[] hitcolliders = Physics.OverlapSphere(transform.position,1.8f,mask.value);
		for(int u=0;u<hitcolliders.Length;u++)
		{
			if(hitcolliders[u].gameObject.GetComponent<FoodID>())
			{
				if(hitcolliders[u].gameObject.GetComponent<FoodID>().foodID == foodObject.GetComponent<FoodID>().foodID)
				{
					if(gameObject.GetComponent<BoxCollider>().bounds.Contains(hitcolliders[u].gameObject.transform.position))
					{
						quantityOfFood++;
					}
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.N))
		{
			Debug.Log(spawnObject.collider.bounds.size.magnitude);
		}
	}
	IEnumerator SpawnFood()
	{
		while(true)
		{
			if(quantityOfFood < items)
			{
				foundPos = false;
				tries = 0;
				while(foundPos == false && tries < 5)
				{
					tries ++;
					spawnPosTest = new Vector3(
					Random.Range(spawnZone.transform.position.x-(spawnZone.collider.bounds.size.x/2),spawnZone.transform.position.x+(spawnZone.collider.bounds.size.x/2)),
					Random.Range(spawnZone.transform.position.y-(spawnZone.collider.bounds.size.y/2),spawnZone.transform.position.y+(spawnZone.collider.bounds.size.y/2)),
					Random.Range(spawnZone.transform.position.z-(spawnZone.collider.bounds.size.z/2),spawnZone.transform.position.z+(spawnZone.collider.bounds.size.z/2)));
				
					Collider[] temp = Physics.OverlapSphere(spawnPosTest,spawnObject.GetComponent<BoxCollider>().size.magnitude/2,mask.value);
					Debug.Log(temp.Length);
					for(int i=0;i<temp.Length;i++)
					{
						Debug.Log(temp[i].gameObject.name);
					}
					if(temp.Length < 1)
					{
						foundPos = true;
						GameObject g = (GameObject)Instantiate(spawnObject,spawnPosTest,transform.rotation);
						SpawnedJunk.BecomeParentToGameObject(g);
						AddGrabablesRecursive(g.transform);
						//rightArm.SendMessage("AddGrabable", g, SendMessageOptions.RequireReceiver);
						
					}
			
				}
			}
			yield return new WaitForSeconds(interval);	
		}
	}
	
	void AddGrabablesRecursive(Transform t)
	{
		if(t == null)
		{
			return;
		}
		else
		{
			if(t.gameObject.layer == LayerMask.NameToLayer(Layers.GRABABLE))
			{
				leftArm.SendMessage("AddGrabable", t.gameObject, SendMessageOptions.RequireReceiver);
			}
			for(int i = 0; i < t.childCount; ++i)
			{
				Transform child = t.GetChild(i);
				AddGrabablesRecursive(child);
			}
		}
	}
}

 
	

