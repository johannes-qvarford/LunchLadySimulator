using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

/**
  * Class encapsulating an NpcRecipie from NpcRecipies.xml.
  * It contains a Name, which is the name of the recipie like "Bread", "Milk" etc.
  * It contains a Value, which is the base points value of this recipie.
  *  Getting a better result on a recipie with a high base value gives more points than on one with a lower base value.
  * It contains a Number, which is the max amount the customer expects for a full score on the recipie.
  *  Giving the customer more than this does not decrease or increase the score from maximum.
  **/
public class NpcRecipie
{
	public String Name { get; private set; }
	public int Value { get; private set; }
	public int Number { get; private set; }

	public NpcRecipie(string name, int value, int number)
	{
		Name = name;
		Value = value;
		Number = number;
	}

	/**
	  * Load Name, Value, Number from
	  * <element name="Name">
	  *  <value>Value</value>
	  *  <number>Number</number>
	  * </element>
	  **/
	public static NpcRecipie LoadFromXElement(XElement element)
	{
		string name = element.Attribute("name").Value;
		int value = int.Parse(element.Element("value").Value);
		int number = int.Parse(element.Element("number").Value);
		return new NpcRecipie(name, value, number);
	}
}

