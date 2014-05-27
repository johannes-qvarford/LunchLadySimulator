using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UnityExtensions
{
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
	}

}

