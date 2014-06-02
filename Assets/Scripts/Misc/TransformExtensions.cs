using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UnityExtensions
{
	/** Class that encapsulates the state of a transform
	**/
	public struct TransformInformation
	{
		public Vector3 position;
		public Vector3 localScale;
		public Quaternion rotation;
	}

	/** Extension methods for the Transform class.

		TODO: move most of these methods to a new class "ComponentExtensions".
	**/
	public static class TransformExtensions
	{
		/** Find an ancestor of a components transform that fullfills a predicate.
		**/
		public static Transform FindAncestor(this Component c, Func<Transform, bool> pred)
		{
			return c.Ancestors().FirstOrDefault(pred);
		}
		
		/** Find an ancestor of a components transform that matches a given transform.
		**/
		public static Transform FindAncestor(this Component c, Transform needle)
		{
			return c.Ancestors().FirstOrDefault((u) => u == needle);
		}
		
		/** Get all ancestors of a transform
		**/
		public static System.Collections.Generic.IEnumerable<Transform> Ancestors(this Component c)
		{
			Transform t = c.transform;
			while(t != null)
			{
				yield return t;
				t = t.parent;
			}
		}
		
		/** Save information of a transform, that can later be used to set a transform state to that of the given transform
		**/
		public static TransformInformation save(this Transform t)
		{
			TransformInformation i;
			i.position = t.transform.position;
			i.localScale = t.transform.localScale;
			i.rotation = t.transform.rotation;
			return i;
		}
		
		/** Restore transform state previously saved with save, to a given transform
		**/
		public static void restore(this Transform t, TransformInformation i)
		{
			t.position = i.position;
			t.localScale = i.localScale;
			t.rotation = i.rotation;
		}
	}

}

