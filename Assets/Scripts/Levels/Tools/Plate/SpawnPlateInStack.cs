using UnityEngine;
using System.Collections;

public class SpawnPlateInStack : MonoBehaviour 
{

	public GameObject spawnObject;
	public int items;
	public LayerMask mask;
	public float interval;
	public int maxPlatesOnWorkbench = 30;
	private GameObject leftArm;
	private GameObject rightArm;
	private GameObject spawnZone;
	private BoxCollider maxPlates;
	private int quantityOfPlateColliders,quantityOfPlatesInStack,quantityOfColliderChildren;
	public int quantityOfPlatesOnWorkbench;

	void Start () 
	{
		quantityOfColliderChildren = spawnObject.transform.FindChild("Colliders").childCount;
		leftArm = GameObject.FindWithTag(Tags.LEFT_ARM);
		rightArm = GameObject.FindWithTag(Tags.RIGHT_ARM);
		spawnZone = gameObject.transform.FindChild("SpawnZone").gameObject;
		maxPlates = transform.FindChild("MaxPlates").gameObject.GetComponent<BoxCollider>();
		StartCoroutine("SpawnPlate");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		CheckPlate();
		CheckPlatesOnWorkbench();
		
	}
	void CheckPlate()
	{
		quantityOfPlatesInStack = 0;
		quantityOfPlateColliders = 0;
		Collider[] temp = Physics.OverlapSphere(transform.position,0.5f,mask.value);
		for(int i = 0;i <temp.Length;i++)
		{
			if(temp[i].gameObject.transform.parent != null && temp[i].gameObject.transform.parent.parent != null)
			{
				if(temp[i].gameObject.transform.parent.parent.tag == Tags.PLATE)
				{	
					if(gameObject.GetComponent<BoxCollider>().bounds.Contains(temp[i].gameObject.transform.position))
					{
						quantityOfPlateColliders++;
					}
				}
			
			}
			
		}
		quantityOfPlatesInStack = quantityOfPlateColliders/quantityOfColliderChildren;
	}
	
	void CheckPlatesOnWorkbench()
	{
		quantityOfPlatesOnWorkbench=0;
		Collider[] hitcolliders = Physics.OverlapSphere(transform.position,1.8f,mask.value);
		for(int u=0;u<hitcolliders.Length;u++)
		{
			if(hitcolliders[u].gameObject.transform.parent != null && hitcolliders[u].gameObject.transform.parent.parent != null)
			{
				if(hitcolliders[u].gameObject.transform.parent.parent.tag == Tags.PLATE)
				{	
					if(maxPlates.bounds.Contains(hitcolliders[u].gameObject.transform.position))
					{
						quantityOfPlatesOnWorkbench++;
					}
				}
			}
		}
		quantityOfPlatesOnWorkbench /= quantityOfColliderChildren;
	}
	
	IEnumerator SpawnPlate()
	{
		while(true)
		{
			if(quantityOfPlatesInStack < items && quantityOfPlatesOnWorkbench < maxPlatesOnWorkbench)
			{
				GameObject g = (GameObject)Instantiate(spawnObject,spawnZone.transform.position,spawnZone.transform.rotation);
				g.GetComponent<CheckPlateInStack>().stack = gameObject;
				SpawnedJunk.BecomeParentToGameObject(g);
				leftArm.SendMessage("AddGrabable", g.gameObject, SendMessageOptions.RequireReceiver);
			}
			yield return new WaitForSeconds(interval);
		}
	}
}
