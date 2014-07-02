using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace UnityExtensions
{
	/** 
	 * Extension methods for GameObjects related to the game hierarchy, like children, or convinience methods for finding ancestors or children.
	 **/
	public static class HierarchyExtensions
	{

		public static Transform FindAncestorOrSelf(this ConvertedGameObject cg, Func<Transform, bool> pred)
		{
			return cg.AncestorsAndSelf().FirstOrDefault(pred);
		}

		public static Transform FindAncestorOrSelf(this ConvertedGameObject cg, Transform needle)
		{
			return cg.AncestorsAndSelf().FirstOrDefault((u) => u == needle);
		}
		
		public static IEnumerable<Transform> AncestorsAndSelf(this ConvertedGameObject cg)
		{
			Transform t = cg.OwnerGameObject.transform;
			while(t != null)
			{
				yield return t;
				t = t.parent;
			}
		}

		public static IEnumerable<Transform> AllChildren(this ConvertedGameObject cg)
		{
			Transform t = cg.OwnerGameObject.transform;
			Queue<Transform> parents = new Queue<Transform>();
			parents.Enqueue(t);
			while(parents.Count() != 0)
			{
				Transform queueChild = parents.Dequeue();
				for(int i = 0; i < queueChild.childCount; ++i)
				{
					Transform child = queueChild.GetChild(i);
					yield return child;
					parents.Enqueue(child);
				}
			}
		}

		public static IEnumerable<Transform> Children(this ConvertedGameObject cg)
		{
			Transform t = cg.OwnerGameObject.transform;
			for(int i = 0; i < t.childCount; ++i)
			{
				yield return t.GetChild(i);
			}
		}
		
		public static string FullName(this ConvertedGameObject cg)
		{
			return cg.AncestorsAndSelf().Reverse().Aggregate("", (s, b) => s + "/" + b.name);
		}
	}

}

