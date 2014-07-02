using System;
using UnityEngine;

namespace UnityExtensions
{
	/**
		 * Extension methods for identifying attributes of game objects.
		 * 
		 * If for example, an object is identified to be food because it has a FoodID component,
		 * the code checking for that is unclear if the reader doesn't know that.
		 * Also in the future, the way to identify food may change, and now every place that used
		 * GetComponent<T>() has to change... except for those that really needed the component.
		 **/
	public static class IdentityExtensions
	{
		public static bool IsKnife(this ConvertedGameObject cg)
		{
			return cg.OwnerGameObject.GetComponent<CutBread>() != null;
		}
		
		public static bool IsFood(this ConvertedGameObject cg)
		{
			return cg.OwnerGameObject.tag == Tags.FOOD;
		}
		
		public static bool HasFoodId(this ConvertedGameObject cg, string foodId)
		{
			GameObject g = cg.OwnerGameObject;
			return cg.IsFood() ? g.GetComponent<FoodID>().foodID == foodId : false;
		}
		
		public static bool IsBreadSlice(this ConvertedGameObject cg)
		{
			return cg.HasFoodId(FoodIds.BREAD);
		}
		
		public static bool IsPlate(this ConvertedGameObject cg)
		{
			return cg.OwnerGameObject.GetComponent<PlateBehaviour>() != null;
		}
		
		public static bool IsPlateInStack(this ConvertedGameObject cg)
		{
			PlateBehaviour pb = cg.OwnerGameObject.GetComponent<PlateBehaviour>();
			return pb != null && pb.inBox;
		}
		
		public static bool IsInactiveGrabable(this ConvertedGameObject cg)
		{
			return cg.OwnerGameObject.GetComponent<GrabableBehaviour>();
		}
		
		public static bool IsActiveGrabable(this ConvertedGameObject cg)
		{
			return cg.OwnerGameObject.layer == LayerMask.NameToLayer(Layers.GRABABLE);
		}

		public static bool IsPlateCollider(this ConvertedGameObject cg)
		{
			GameObject g = cg.OwnerGameObject;
			return g.transform.parent != null
				&& g.transform.parent.parent != null
				&& g.transform.parent.parent.IsPlate();
		}
		
		public static bool IsSolid(this ConvertedGameObject cg)
		{
			return Layers.IsAnyLayer(cg.OwnerGameObject.layer, Layers.INTERACT, Layers.GRABABLE) == false;
		}

		public static bool IsToolCollider(this ConvertedGameObject cg)
		{
			GameObject g = cg.OwnerGameObject;
			return g.GetComponent<ToolHitbox>() != null;
		}

		public static Transform GetToolOfToolCollider(this ConvertedGameObject cg)
		{
			return cg.OwnerGameObject.transform.parent.parent;
		}

		public static Transform GetSpawnTransformFromTool(this ConvertedGameObject cg)
		{
			return cg.OwnerGameObject.GetComponent<ToolBehaviour>().spawnTransform;
		}
	}
}
