using UnityEngine;
using System.Collections;

public class SpawnPlateInStack : MonoBehaviour 
{

	public GameObject spawnObject;
	public int items;
	public LayerMask mask;
	public float interval;
	private GameObject leftArm;
	private GameObject rightArm;
	private GameObject spawnZone;
	private int quantityOfPlateColliders,quantityOfPlatesInStack,quantityOfColliderChildren;

	void Start () 
	{
		quantityOfColliderChildren = spawnObject.transform.FindChild("Colliders").childCount;
		leftArm = GameObject.FindWithTag(Tags.LEFT_ARM);
		rightArm = GameObject.FindWithTag(Tags.RIGHT_ARM);
		spawnZone = gameObject.transform.FindChild("SpawnZone").gameObject;
		StartCoroutine("SpawnPlate");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		CheckPlate();
		
	}
	void CheckPlate()
	{
		quantityOfPlatesInStack = 0;
		quantityOfPlateColliders = 0;
		Collider[] temp = Physics.OverlapSphere(transform.position,0.5f,mask.value);
		for(int i = 0;i <temp.Length;i++)
		{
			if(temp[i].gameObject.transform.parent.parent != null)
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
	
	IEnumerator SpawnPlate()
	{
		while(true)
		{
			if(quantityOfPlatesInStack < items)
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
