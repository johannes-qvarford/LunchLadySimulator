using UnityEngine;
using System.Collections;

public class RemoveItself : MonoBehaviour
{
	public float removeTime = 1;
	
	void Start ()
	{
		Destroy (this.gameObject, removeTime);
	}
}
