using UnityEngine;
using System.Collections;

using UnityExtensions;

public class ToolBehaviour : MonoBehaviour
{
	private TransformInformation originalTransform;

	void Start()
	{
		originalTransform = transform.save();
	}
	
	public void ResetToOriginalTransform()
	{
		transform.restore(originalTransform);
	}
}
