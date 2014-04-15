using UnityEngine;
using System.Collections;

public class NpcMove : MonoBehaviour {

	public float speed = 0;
	public Vector3 direction;

	public bool move = true;
	public bool queMove = true;

	private GameObject CharControl;

	void Awake()
	{
		CharControl = GameObject.Find("GeneralCharController");
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.Log("Move: " + move);
		Debug.Log("QueMove: " + queMove);
		if(move && queMove)
		{
			Vector3 tempDir = direction * speed;
			transform.position += tempDir;
		}
	}

	void OnTriggerEnter(Collider collision)
	{
		Debug.Log("STOP!");
		CharControl.GetComponent<GeneralCharController>().stopped = this.gameObject;
		move = false;
	}

	void OnTriggerStay(Collider collision)
	{
		CharControl.GetComponent<GeneralCharController>().stopped = this.gameObject;
	}
}
