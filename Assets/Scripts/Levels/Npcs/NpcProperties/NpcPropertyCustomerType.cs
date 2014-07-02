

using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

/**
  * Class for the structure of a <category> element in NPCProperties.xml.
  * Some child elements of <category>, like <heads> is just a list of strings.
  *  These are usually just for random selection.
  * Other child elements, like <hairs> has child elements with an attribute and a list of strings.
  *  The attribute is usually a type, like hairtype, and the list contains things like colors.
  * As of 2014-07-01, all elements are not used in the game, like <perfections>.
  **/
public class NpcPropertyCustomerType
{
	public string Name { get; private set; }
	public List<string> SkinColors { get; private set; }
	public List<string> Heads { get; private set; }
	public List<NpcPropertyAttributeAndList> Clothes { get; private set; }
	public List<NpcPropertyAttributeAndList> Accessories { get; private set; }
	public List<NpcPropertyAttributeAndList> Hairs { get; private set; }
	public List<string> PreferenceTypes { get; private set; }
	public List<int> PreferenceAmounts { get; private set; }
	public List<int> Perfections { get; private set; }
	public List<int> Patiences { get; private set; }
	
	public static NpcPropertyCustomerType LoadFromXElement(XElement element)
	{
		return new NpcPropertyCustomerType
		{
			Name = element.FirstAttribute.Value,
			SkinColors = LoadValueList(element, "skincolors", "skincolor"),
			Heads = LoadValueList(element, "heads", "head"),
			Clothes = LoadPropertyAndListList(element, "clothes", "clothestype", "name", "texture"),
			Accessories = LoadPropertyAndListList(element, "accessories", "accessory", "name", "texture"),
			Hairs = LoadPropertyAndListList(element, "hairs", "hair", "name", "texture"),
			PreferenceTypes = LoadValueList(element, "preferenceTypes", "preferenceType"),
			PreferenceAmounts = LoadValueIntList(element, "preferenceAmounts", "preferenceAmount"),
			Perfections = LoadValueIntList(element, "perfections", "perfection"),
			Patiences = LoadValueIntList(element, "patiences", "patience")
		};
	}
	
	private static List<string> LoadValueList(XElement element, string listName, string elementName)
	{
		return element.Element(listName)
			.Elements(elementName)
			.Select(elem => elem.Value)
			.ToList();
	}
	
	private static List<int> LoadValueIntList(XElement element, string listName, string elementName)
	{
		return element.Element(listName)
			.Elements(elementName)
			.Select(elem => int.Parse(elem.Value))
			.ToList();
	}
	/**
	  * Load list of (Attribute + List of Strings). That is: (a1, [s11,s12, ...]]) (a2, [s21, s22, ...]) from:
	  * <listName>
	  *  <elementName attributeName="a1">
	  *   <innerItemName>s11</innerItemName>
	  *   <innerItemName>s12</innerItemName>
	  *   ...
	  *  <elementName attributeName="a2">
	  *   ...
	  *  </elementName>
	  *  ...
	  * </listName>
	  *
	  **/
	private static List<NpcPropertyAttributeAndList> LoadPropertyAndListList(XElement element, string listName, string elementName, string attributeName, string innerItemName)
	{
		return element.Element(listName)
			.Elements(elementName)
			.Select(elem => NpcPropertyAttributeAndList.LoadFromXElement(elem, attributeName, innerItemName))
			.ToList();
	}
}