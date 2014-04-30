using UnityEngine;
using System.Collections;


public abstract class MonoSingleton<T> : MonoBehaviour where T:Component, new()
{
	static private T instance;
	
	void Start()
	{
		if(GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
		{
			Destroy(gameObject);
			Debug.LogError("impossible unless a MonoSingleton is placed in a level, which it shouldn't be.");
		}
		if(ShouldBeDestroyedOnLoad())
		{
			Debug.Log("hello should destroy " + typeof(T).Name);
			DontDestroyOnLoad(gameObject);
		}
		instance = gameObject.GetComponent<T>();
		VirtualStart();
	}
	
	public virtual bool ShouldBeDestroyedOnLoad()
	{
		return true;
	}
	
	protected static T GetInstance()
	{
		if(instance == null)
		{
			var newObject = new GameObject();
			newObject.AddComponent<T>();
			newObject.name = typeof(T).FullName;
			DontDestroyOnLoad(newObject);
			instance = newObject.GetComponent<T>();
		}
		return instance;
	}
	
	protected virtual void VirtualStart()
	{
	}
}
