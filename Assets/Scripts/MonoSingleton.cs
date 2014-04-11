using UnityEngine;
using System.Collections;


public class MonoSingleton<T> : MonoBehaviour where T:Component, new() 
{
	static private T instance;
	
	public void Start() 
	{
		if(GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1) 
		{
			Destroy(gameObject);
			Debug.LogError("impossible unless a MonoSingleton is placed in a level, which it shouldn't be.");
		}
		DontDestroyOnLoad(gameObject);
		instance = gameObject.GetComponent<T>();
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
}
