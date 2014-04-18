using UnityEngine;
using System.Collections;

public class CreateFood : MonoBehaviour {

	public GameObject create;

	public bool foodType = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.J))
		{
			GameObject gameObject = Instantiate(create, this.transform.position, Quaternion.Euler(90f, 0f, 0f)) as GameObject;
			if(!foodType)
			{
				gameObject.renderer.material.color = Color.yellow;
				gameObject.GetComponent<FoodID>().foodID = "Yellow";
			}
			if(foodType)
			{
				gameObject.renderer.material.color = Color.green;
				gameObject.GetComponent<FoodID>().foodID = "Green";
			}
		}
	}
}
