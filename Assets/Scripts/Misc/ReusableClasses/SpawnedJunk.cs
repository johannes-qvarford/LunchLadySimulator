
using UnityEngine;

/** Utility class for a global object to become parent to spawned objects
	that would otherwise be a distraction in Unitys object heirarchy during debugging.

	TODO: rename to more fitting name.
**/
public class SpawnedJunk : MonoSingleton<SpawnedJunk>
{
	public override bool ShouldBeDestroyedOnLoad()
	{
		/*
			TODO: Fix logic in MonoSingleton that requires this class to incorrectly state its game object shouldn't be destroyed on load.
		*/
		return false;
	}
	
	void OnLevelWasLoaded()
	{
		/*
			TODO: rewrite using Linq
		*/
		for(int i = 0; i < transform.childCount; ++i)
		{
			Transform child = transform.GetChild(i);
			GameObject.Destroy(child.gameObject);
		}
	}

	/**
		TODO: write generic code for becoming parent to components
	**/

	/**	Become parent to a game objects transform
	**/
	public static void BecomeParentToGameObject(Transform t)
	{
		GetInstance().BecomeParentToGameObjectInternal(t);
	}
	
	/**	Become parent to a transform
	**/
	public static void BecomeParentToGameObject(GameObject g)
	{
		GetInstance().BecomeParentToGameObjectInternal(g.transform);
	}

	/**	Instantiate a game object at a position with a rotation, and let SpawnedJunk become parent to it.
	**/
	public static GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation)
	{
		return GetInstance().InstantiateInternal(original, position, rotation);
	}
	
	/**	Instantiate a game object at a position and let SpawnedJunk become parent to it.
	**/
	public static GameObject Instantiate(GameObject original)
	{
		return GetInstance().InstantiateInternal(original);
	}

	private void BecomeParentToGameObjectInternal(Transform t)
	{
		t.parent = transform;
	}
	
	private GameObject InstantiateInternal(GameObject original, Vector3 position, Quaternion rotation)
	{
		GameObject g = (GameObject)GameObject.Instantiate(original, position, rotation);
		g.transform.parent = transform;
		return g;
	}
	
	private  GameObject InstantiateInternal(GameObject original)
	{
		GameObject g = (GameObject)GameObject.Instantiate(original);
		g.transform.parent = transform;
		return g;
	}
}

