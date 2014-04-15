using UnityEngine;
using System.Collections;

public class GeneralCharController : MonoBehaviour {

	public GameObject stopped;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.U))
		{
			if(stopped != null)
			{
				stopped.GetComponent<NpcMove>().move = true;
			}
		}
	}
}
