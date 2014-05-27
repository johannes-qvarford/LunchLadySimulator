using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UnityExtensions
{
	public struct TransformInformation
	{
		public Vector3 position;
		public Vector3 localScale;
		public Quaternion rotation;
	}

	public static class TransformExtensions
	{
		public static Transform FindAncestor(this Component c, Func<Transform, bool> pred)
		{
			return c.Ancestors().FirstOrDefault(pred);
		}
		
		public static Transform FindAncestor(this Component c, Transform needle)
		{
			return c.Ancestors().FirstOrDefault((u) => u == needle);
		}
		
		public static System.Collections.Generic.IEnumerable<Transform> Ancestors(this Component c)
		{
			Transform t = c.transform;
			while(t != null)
			{
				yield return t;
				t = t.parent;
			}
		}
		
		public static TransformInformation save(this Transform t)
		{
			TransformInformation i;
			i.position = t.transform.position;
			i.localScale = t.transform.localScale;
			i.rotation = t.transform.rotation;
			return i;
		}
		
		public static void restore(this Transform t, TransformInformation i)
		{
			t.position = i.position;
			t.localScale = i.localScale;
			t.rotation = i.rotation;
		}
	}

}

