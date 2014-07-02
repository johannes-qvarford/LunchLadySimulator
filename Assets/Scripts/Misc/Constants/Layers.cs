using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/** 
  * Utility class for providing compile time safety for Layer names.
  *	
  * The reason this class exist is that if you need to write a layer name several times,
  * you may misspell it and notice that your code doesn't work during runtime.
  * If you instead misspell one of these constants you will get a compiler error.
  *	Note: This utility class does not contain all known FoodIds, only those that have been used in the project,
  *	If you need to use a food id anywhere in the code base, and the constant isn't here; just add it.
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
	
	public static int CombineLayerNames(params string[] names)
	{
		int mask = 0;
		foreach(string name in names)
		{
			mask |= 1 << LayerMask.NameToLayer(name);
		}
		return mask;
	}
	
	public static bool IsAnyLayer(int needle, params string[] layers)
	{
		return layers.Any(la => LayerMask.NameToLayer(la) == needle);
	}
}

