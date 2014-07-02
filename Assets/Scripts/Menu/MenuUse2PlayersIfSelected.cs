using UnityEngine;
using System.Collections;

/*
 * Use two players or one players when this button is selected.
 */
public class MenuUse2PlayersIfSelected : MonoBehaviour
{
	public bool use2 = false;

	void SelectedChanged(bool yes)
	{
		if(yes)
		{
			JoypadState.TwoPlayers = use2;
		}
	}
}

