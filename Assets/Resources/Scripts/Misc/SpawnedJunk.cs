
using UnityEngine;

public class SpawnedJunk : MonoSingleton<SpawnedJunk>
{
	public static void BecomeParentToGameObject(Transform t)
	{
		GetInstance().BecomeParentToGameObjectInternal(t);
	}
	
	public static void BecomeParentToGameObject(GameObject g)
	{
		GetInstance().BecomeParentToGameObjectInternal(g.transform);
	}

	public static GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation)
	{
		return GetInstance().InstantiateInternal(original, position, rotation);
	}
	
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

