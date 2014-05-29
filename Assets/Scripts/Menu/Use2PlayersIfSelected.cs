using UnityEngine;
using System.Collections;

public class Use2PlayersIfSelected : MonoBehaviour
{
	public bool use2 = false;

	void OnSelected(bool yes)
	{
		if(yes)
		{
			ArmInputManager.Use2Players(use2);
		}
	}
}

