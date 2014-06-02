using UnityEngine;
using System.Collections;

using UnityExtensions;

/** Script that identifies an attached game object as a tool, and holds the properties and methods of a tool.
**/
public class ToolBehaviour : MonoBehaviour
{
	private TransformInformation originalTransform;

	void Start()
	{
		originalTransform = transform.save();
	}
	
	/** Reset the tool to its original position.
	**/
	public void ResetToOriginalTransform()
	{
		transform.restore(originalTransform);
	}
}
