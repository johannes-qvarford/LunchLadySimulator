using UnityEngine;

/**
  * Class that keeps the Npcs lunch order when it is first created.
  **/
public class LunchOrderBehaviour : MonoBehaviour
{
	public LunchOrder TheLunchOrder { get; private set; }
	
	
	public void LunchOrderCreated(LunchOrder lunchOrder)
	{
		TheLunchOrder = lunchOrder;
	}
	
}