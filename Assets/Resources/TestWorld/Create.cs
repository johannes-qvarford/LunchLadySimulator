using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	public GameObject create;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(false)//if(Input.GetKeyDown(KeyCode.Q))
		{
			GameObject temp = Instantiate(create, this.transform.position, this.transform.rotation) as GameObject;
		}
	}
}
