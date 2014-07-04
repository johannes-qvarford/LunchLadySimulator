using UnityEngine;
using UnityExtensions;

/**
 * Class for sending messages that both arms should be aware of.
 * For example, when a grabable is created.
 **/
public class ArmsDispatcher : MonoBehaviour
{
	private ArmsState state;
	private DoOncer getArmsStateOnce = new DoOncer();
	
	private void AddGrabable(GameObject g)
	{
		if(g.IsInactiveGrabable() == false)
		{
			Debug.LogError("tried to add non grabable gameobject");
			Debug.DebugBreak();
		}
		getArmsStateOnce.doOnce(() => { state = gameObject.GetComponent<ArmsState>(); });
		state.grabables.Add(g);
	}
}

