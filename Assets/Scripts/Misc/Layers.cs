using System;
using UnityEngine;
using System.Collections.Generic;

/** Utility class for providing compile time safety for Layer names.
	
	The reason this class exist is that if you need to write a layer name several times,
	you may misspell it and notice that your code doesn't work during runtime.
	If you instead misspell one of these constants you will get a compiler error.
**/
public static class Layers
{
	public const string INTERACT = "Interact";
	public const string FOOD_PLATE = "FoodPlate";
	public const string TRIGGER_ZONE = "TriggerZone";
	public const string CONTROL = "Control";
	public const string GRABABLE = "Grabable";
	public const string HUMAN = "Human";
	public const string SOUP = "Soup";
	public const string SOUP_PLANE = "SoupPlane";
	public const string SHADOW_PLANE = "ShadowPlane";
	
	/** Creates a layer mask of all the layer names provided.
	**/
	public static int CombineLayerNames(params string[] names)
	{
		int mask = 0;
		foreach(string name in names)
		{
			mask |= 1 << LayerMask.NameToLayer(name);
		}
		return mask;
	}
	
	/** Find all objects that are in a layer
	**/
	public static GameObject[] FindGameObjectsInLayer(int layer)
	{
		GameObject[] gs = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		List<GameObject> objectsInLayer = new List<GameObject>();
		foreach(GameObject g in gs)
		{
			if(g.layer == layer)
			{
				objectsInLayer.Add(g);
			}
		}
		return objectsInLayer.ToArray();
	}
	
	/** Determines whether a layer exists in a collection of layer names
	**/
	public static bool IsAnyLayer(int needle, params string[] layers)
	{
		foreach(string layer in layers)
		{
			if(needle == LayerMask.NameToLayer(layer))
			{
				return true;
			}
		}
		return false;
	}
	
	/** Set the layer of a transform and its ancestors to a specified layer name
	**/
	public static void SetLayerRecursive(Transform t, string name)
	{
		SetLayerRecursive(t, LayerMask.NameToLayer(name));
	}
	
	/** Set the layer of a transform and its ancestors to a specified layer name
	**/
	public static void SetLayerRecursive(Transform t, int layer)
	{
		t.gameObject.layer = layer;
		for(int i = 0; i < t.childCount; ++i)
		{
			SetLayerRecursive(t.GetChild(i), layer);
		}
	}

}

