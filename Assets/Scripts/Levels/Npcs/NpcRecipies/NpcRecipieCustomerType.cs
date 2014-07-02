using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

/**
  * Class for loading an npctype's preferences from NpcRecipies.xml.
  * Every npc type has a name, and a list of main dishes, side orders and drinks it might order.
  * To see the strucure of the recipies, see NpcRecipie.cs.
  *
  * TODO: As of 2014-07-01, there has been talk of removing MainDishes/SideOrders/Drinks and just use a list of Recipies.
  * This class will have to be updated when that change occurs.
  **/
public class NpcRecipieCustomerType
{
	public string Type { get; private set; }
	public List<NpcRecipie> MainDishes { get; private set; }
	public List<NpcRecipie> SideOrders { get; private set; }
	public List<NpcRecipie> Drinks { get; private set; }

	public NpcRecipieCustomerType(string type, List<NpcRecipie> mainDishes, List<NpcRecipie> sideOrders, List<NpcRecipie> drinks)
	{
		Type = type;
		MainDishes = mainDishes;
		SideOrders = sideOrders;
		Drinks = drinks;
	}
	
	public static NpcRecipieCustomerType LoadFromXElement(XElement element)
	{
		string type = element.Attribute("name").Value;
		List<NpcRecipie> mainDishes = LoadInnerRecipies(element, "maindishes", "maindish");
		List<NpcRecipie> sideOrders = LoadInnerRecipies(element, "sideorders", "sideorder");
		List<NpcRecipie> drinks = LoadInnerRecipies(element, "drinks", "drink");
		
		return new NpcRecipieCustomerType
		(
			type: type,
			mainDishes: mainDishes, 
			sideOrders : sideOrders, 
			drinks: drinks
		);
	}
	
	/**
	  * Load a list of recipies from <groupName> <elementName>recipie1</elementName> <elementName>recipie2</elementName> ... </groupName>
	  **/
	private static List<NpcRecipie> LoadInnerRecipies(XElement element, string groupName, string elementName)
	{
		return element.Element(groupName)
			.Elements(elementName)
				.Select(so => NpcRecipie.LoadFromXElement(so))
				.ToList();
	}
}

