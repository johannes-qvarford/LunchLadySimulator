using System;
using UnityEngine;
using System.Collections.Generic;

public static class Layers
{
	public const string INTERACT = "Interact";
	public const string FOOD_PLATE = "FoodPlate";
	public const string TRIGGER_ZONE = "TriggerZone";
	public const string CONTROL = "Control";
	public const string GRABABLE = "Grabable";
	public const string HUMAN = "Human";
	
	public static int CombineLayerNames(params string[] names)
	{
		int mask = 0;
		foreach(string name in names)
		{
			mask |= 1 << LayerMask.NameToLayer(name);
		}
		return mask;
	}
	
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
	
	public static void SetLayerRecursive(Transform t, string name)
	{
		SetLayerRecursive(t, LayerMask.NameToLayer(name));
	}
	
	public static void SetLayerRecursive(Transform t, int layer)
	{
		t.gameObject.layer = layer;
		for(int i = 0; i < t.childCount; ++i)
		{
			SetLayerRecursive(t.GetChild(i), layer);
		}
	}

}

