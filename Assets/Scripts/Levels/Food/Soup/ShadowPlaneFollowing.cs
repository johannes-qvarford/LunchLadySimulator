using UnityEngine;
using System.Collections;

/*
 * Used by "shadows" to follow their real counterparts.
 *
 * TODO: Remove this when the soup shader is removed.
 */
public class ShadowPlaneFollowing : MonoBehaviour {
	public Transform m_parent;
	
	void Update ()
	{
		if(m_parent != null)
		{
			gameObject.transform.position = m_parent.position;
			gameObject.transform.rotation = m_parent.rotation;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
