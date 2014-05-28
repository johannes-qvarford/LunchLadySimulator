using UnityEngine;
using System.Collections.Generic;
using System.Linq;



public static class ObjectAttributesExtensions
{
	public static bool HasAllAttributes(this GameObject g, string[] other)
	{
		return ObjectAttributes.hasAllAttributesStatic(g, other);
	}
	
	public static bool HasAnyAttributes(this GameObject g, string[] other)
	{
		return ObjectAttributes.hasAnyAttributesStatic(g, other);
	}
}

public class ObjectAttributes : MonoBehaviour
{
	public static string GRABABLE = "Grabable";


	public string[] attributes;
	
	public bool hasAllAttributes(params string[] other)
	{
		return hasAllAttributesStatic(attributes, other);
	}
	
	public bool hasAnyAttributes(params string[] other)
	{
		 return hasAnyAttributesStatic(attributes, other);
	}
	
	public static GameObject[] FindObjectsWithAllAttributes(params string[] other)
	{
		GameObject[] gs = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		return (from g in gs where hasAllAttributesStatic(g, other) select g).ToArray();
	}
	
	public static GameObject[] FindObjectWithAnyAttributes(params string[] other)
	{
		GameObject[] gs = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		return (from g in gs where hasAnyAttributesStatic(g, other) select g).ToArray();
	}
	
	public static bool hasAnyAttributesStatic(GameObject g, params string[] other)
	{
		ObjectAttributes oa = g.GetComponent<ObjectAttributes>();
		return oa == null ? false : oa.hasAnyAttributes(other);
	}
	
	public static bool hasAllAttributesStatic(GameObject g, params string[] other)
	{
		ObjectAttributes oa = g.GetComponent<ObjectAttributes>();
		return oa == null ? false : oa.hasAllAttributes(other);
	}
	
	public static bool hasAnyAttributesStatic(string[] att, params string[] other)
	{
		return other.Any((o) => att.Contains(o));
	}
	
	public static bool hasAllAttributesStatic(string[] att, params string[] other)
	{
		return other.All((o) => att.Contains(o));
	}
}
