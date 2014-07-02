using UnityEngine;

namespace UnityExtensions
{
	/**
	 * Extention methods for transforms.
	 **/
	public static class TransformExtensions
	{
		/** Class that encapsulates the state of a transform
		  **/
		public struct TransformInformation
		{
			public Vector3 position;
			public Vector3 localScale;
			public Quaternion rotation;
		}
	
		/** Save information of a transform, that can later be used to set a transform state to that of the given transform
		**/
		public static TransformInformation Save(this Transform t)
		{
			TransformInformation i;
			i.position = t.transform.position;
			i.localScale = t.transform.localScale;
			i.rotation = t.transform.rotation;
			return i;
		}
		
		/** Restore transform state previously saved with save, to a given transform
		**/
		public static void Load(this Transform t, TransformInformation i)
		{
			t.position = i.position;
			t.localScale = i.localScale;
			t.rotation = i.rotation;
		}
	}
}