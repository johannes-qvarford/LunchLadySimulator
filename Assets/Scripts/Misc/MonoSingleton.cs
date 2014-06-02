using UnityEngine;
using System.Collections;

/** Singleton class that can be updated each frame like a GameObject.

	Inerit from this call 
**/
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
		/*
			TODO: Investigate if this is a bug
			Should an object that should be destroyed on load, at the same time be destroyed at load?
			Maybe classes that wants to be destroyed inherit ShouldBeDestroyed to (incorrectly) return true?
		*/
		if(ShouldBeDestroyedOnLoad())
		{
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
	
	/** Script that gets called after Unitys Start function.
	
		Unity uses reflection to find its callback functions, 
		and this is workaround to allow different start behaviour in classes inheriting from this class.
	**/
	protected virtual void VirtualStart()
	{
	}
}
