using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/**
  * Class for a lunch order.
  * TODO: As of 2014-07-02, the format of lunch orders will change, so this will need to change.
  **/
public class LunchOrder
{
	public NpcRecipie[] MainDishes{ get; private set; }
	public NpcRecipie SideOrder{ get; private set; }
	public NpcRecipie Drink{ get; private set; }
	
	public LunchOrder(NpcRecipie[] mainDishes, NpcRecipie sideOrder, NpcRecipie drink)
	{
		MainDishes = mainDishes;
		SideOrder = sideOrder;
		Drink = drink;
	}
	
	public IEnumerable<NpcRecipie> Recipies()
	{
		return MainDishes.Concat(new NpcRecipie[]{ SideOrder, Drink });
	}
}