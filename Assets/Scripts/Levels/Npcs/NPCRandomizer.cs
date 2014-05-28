using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

using System.Xml.Linq;
using System.Linq;

public class NPCRandomizer : MonoBehaviour {
	string loadFile;
	public string[] categories = new string[20];
	List<Category> categoryList = new List<Category>();
	public bool newType = false;

	private DishStruct currentDrink;
	private DishStruct currentSideOrder;
	private DishStruct[] currentMainOrder;

	private string headstring = "head_kid1";
	private string headstring2 = "head_kid";

	private GameObject sounds;
	// Use this for initialization
	void Start () {
		sounds = GameObject.FindWithTag(Tags.NPCSOUNDBANK);
		LoadNPCProperties();
		LoadNPCRecipies();
		randomizeNPC();		
	}
	
	private void LoadNPCRecipies()
	{
		int offset = 0;
		
		TextAsset asset = Resources.Load<TextAsset>("Npcs/XML/NpcRecipies");
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(asset.text);
		XElement xmlRandomizerString = XElement.Load(new XmlNodeReader(doc));//XElement.Load("Assets/Resources/XML/NPCrecipies.xml");
		
		IEnumerable<XElement> types = xmlRandomizerString.Elements();
		foreach(var type in types)
		{	
			offset = -1;
			for(int i = 0;i < categoryList.Count;i++)
			{
				if(categoryList[i].GetName() == type.FirstAttribute.Value)
				{
					offset = i;
					i = categoryList.Count;
				}
			}
			if(offset == -1)
			{	
				Debug.Log("ERROR LOADING RECIPIES FOR TYPE: " + type.FirstAttribute.Value);
			}
			else
			{
				LoadMainDishes(type,offset);
				LoadSideOrders(type,offset);
				LoadDrinks(type,offset);
			}
		} 
		
	}	



	private void LoadMainDishes(XElement type, int offset)
	{	
		var maindishes = type.Element("maindishes");
		foreach(var maindish in maindishes.Elements("maindish"))
		{
			List<DishStruct> dishList = new List<DishStruct>();
			foreach(var name in maindish.Elements("name"))
			{	
				DishStruct dish = new DishStruct();
				dish.dish = name.FirstAttribute.Value;
				var number = name.Element ("number");
				dish.number = int.Parse(number.Value);
				var value = name.Element("value");
				dish.baseValue = int.Parse(value.Value);
				
				dishList.Add (dish);
			}
			categoryList[offset].AddMainOrder(dishList.ToArray());
		}
	}

	private void LoadSideOrders(XElement type, int offset)
	{
		var sideorders = type.Element ("sideorders");
		foreach (var sideorder in sideorders.Elements("sideorder"))
		{
			DishStruct dish = new DishStruct();
			
			dish.dish = sideorder.FirstAttribute.Value;
			var number = sideorder.Element ("number");
			dish.number = int.Parse(number.Value);
			var value = sideorder.Element("value");
			dish.baseValue = int.Parse(value.Value);
			categoryList[offset].AddSideOrder(dish);
		}
	}


	private void LoadDrinks(XElement type, int offset)
	{
		var drinks = type.Element ("drinks");	
		foreach (var drink in drinks.Elements("drink"))
		{
			DishStruct dish = new DishStruct();	
			
			dish.dish = drink.FirstAttribute.Value;
			var number = drink.Element ("number");
			dish.number = int.Parse(number.Value);
			var value = drink.Element("value");
			dish.baseValue = int.Parse(value.Value);
			categoryList[offset].AddDrink(dish);
		}
	}

	private void LoadNPCProperties()
	{
		TextAsset asset = Resources.Load<TextAsset>("Npcs/XML/NpcProperties");
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(asset.text);
		XElement xmlRandomizerString = XElement.Load(new XmlNodeReader(doc));
		//XElement xmlRandomizerString = XElement.Load("Assets/Resources/XML/NPCproperties.xml");
		IEnumerable<XElement> categories = xmlRandomizerString.Elements();
		int i = 0;
		
		foreach (var category in categories) 
		{
			categoryList.Add(new Category(category.FirstAttribute.Value));
			
			LoadSkinColor(category,i);
			LoadHeads (category,i);
			LoadClothes(category,i);
			LoadAccesories(category,i);
			LoadHairs(category,i);
			LoadPreferenceTypes(category,i);
			LoadPreferenceAmounts(category,i);
			LoadPerfections(category,i);
			LoadPatience(category,i);
			i++;
		}
	}

	private void LoadSkinColor(XElement category, int counter)
	{
		var skincolors = category.Element ("skincolors");
		foreach(var skincolor in skincolors.Elements ("skincolor"))
		{
			categoryList[counter].AddSkinColor(skincolor.Value);
		}
	}

	private void LoadHeads(XElement category, int counter)
	{	
		var heads = category.Element ("heads");
		foreach(var head in heads.Elements ("head"))
		{
			categoryList[counter].AddHead (head.Value);
		}
	}
	
	private void LoadClothes(XElement category, int counter)
	{
		var clothes = category.Element ("clothes");
		foreach (var clothestype in clothes.Elements("clothestype")){
			categoryList[counter].AddClothes(clothestype.FirstAttribute.Value);
			
			foreach(var texture in clothestype.Elements("texture")){
				categoryList[counter].AddClothesColor(texture.Value);
			}				
		}
	}

	private void LoadAccesories(XElement category, int counter)
	{
		var accessories = category.Element ("accessories");		
		foreach(var accessory in accessories.Elements ("accessory"))
		{
			categoryList[counter].AddAccessory(accessory.FirstAttribute.Value);
			
			foreach(var texture in accessory.Elements("texture"))
			{
				categoryList[counter].AddAccessoryColor(texture.Value);
			}
		}
	}

	private void LoadHairs(XElement category, int counter)
	{
		var hairs = category.Element ("hairs");
		foreach(var hair in hairs.Elements("hair"))
		{
			categoryList[counter].AddHair (hair.FirstAttribute.Value);
			
			foreach(var texture in hair.Elements ("texture"))
			{
				categoryList[counter].AddHairColor(texture.Value);
			}
		}
	}

	private void LoadPreferenceTypes(XElement category, int counter)
	{
		var preferenceTypes = category.Element ("preferenceTypes");
		foreach(var preferenceType in preferenceTypes.Elements("preferenceType"))
		{
			categoryList[counter].setPreferenceType(preferenceType.Value);
		}
		
	}
	
	private void LoadPreferenceAmounts(XElement category, int counter)
	{
		var preferenceAmounts = category.Element ("preferenceAmounts");
		foreach(var preferenceAmount in preferenceAmounts.Elements("preferenceAmount"))
		{
			categoryList[counter].setPreferenceAmount(preferenceAmount.Value);
		}
	}

	private void LoadPerfections(XElement category, int counter)
	{
		var perfections = category.Element ("perfections");
		foreach(var perfection in perfections.Elements("perfection"))
		{
			categoryList[counter].setPerfection(perfection.Value);
		}
	}

	private void LoadPatience(XElement category, int counter)
	{
		var patiences = category.Element ("patiences");
		foreach(var patience in patiences.Elements("patience"))
		{
			categoryList[counter].setPatience(patience.Value);
		}
	}

	void Update ()
	{
		if (newType) 
		{
			newType = false;
			randomizeNPC();
		}
	}

	public void randomizeNPC()
	{
		int type = Random.Range(0,categoryList.Count);
		GetComponent<SoundCheck>().setFmodAsset(sounds.GetComponent<SoundBank>().GetNpcSound(categoryList[type].GetName()));
		ChangeClothes(type);
		ChangeHead(type);
		ChangeSkinColor(type);
		ChangeHair(type);
		
		currentMainOrder = categoryList[type].GetRandomMainOrder();
		
		currentSideOrder = categoryList[type].GetRandomSideOrder();
		
		currentDrink = categoryList[type].GetRandomDrink();

		transform.GetComponent<NpcBehaviour>().setFaceReady(true,headstring);
	}

	private void ChangeHair(int type)
	{
		string hairType = categoryList[type].GetRandomHair();
		
		GameObject Hair = (GameObject)Resources.Load("Npcs/BodyParts/"+hairType);
		GameObject setHair = GameObject.Instantiate(Hair) as GameObject;
		GameObject refHead =  transform.Find("Customer_Kid/Hips 1/Spine/Spine1/Spine2/Neck/Head 1/"+headstring).gameObject;
		setHair.transform.position = transform.position;
		setHair.transform.parent = refHead.transform;
		
		setHair.transform.rotation = refHead.transform.rotation;
		
		Vector3 positionOffset = new Vector3(0.00323f,0.764549f, -0.005494945f);
		setHair.transform.localPosition = positionOffset;
	
		setHair.name = "hair";
		
		Material newMaterialPrefab = Resources.Load("Npcs/Materials/Hairs/"+categoryList[type].GetRandomHairColor(hairType), typeof(Material)) as Material;
		Material newMaterial = new Material(newMaterialPrefab);
		setHair.renderer.material = newMaterial;
	}
	
	private void ChangeSkinColor(int type)
	{
		
		Material newMaterialPrefab = Resources.Load("Npcs/Materials/Skins/"+categoryList[type].GetRandomSkinColor(), typeof(Material)) as Material;
		Material skinColor = new Material(newMaterialPrefab);
		GameObject refObj =  transform.Find("Customer_Kid/Hips 1/Spine/Spine1/Spine2/Neck/Head 1/"+headstring).gameObject;
		MeshRenderer[] obj;
		obj = refObj.transform.GetComponentsInChildren<MeshRenderer>();
		
		foreach (MeshRenderer b in obj) 
		{
			b.material = skinColor;
		}
		SkinnedMeshRenderer[] obj1 = refObj.transform.GetComponentsInChildren<SkinnedMeshRenderer>();
		
		foreach (SkinnedMeshRenderer b in obj1) 
		{
			b.material = skinColor;
		}
		GameObject obj2 = transform.Find("body_kid_mesh_005").gameObject;
		obj2.renderer.material  = skinColor;
	}
	
	private void ChangeHead(int type)
	{
		string headType = categoryList[type].GetRandomHead();
		GameObject head = (GameObject)Resources.Load("Npcs/BodyParts/"+headType);
		GameObject switchHead = GameObject.Instantiate(head) as GameObject;
		
		GameObject refHead =  transform.Find("Customer_Kid/Hips 1/Spine/Spine1/Spine2/Neck/Head 1/"+headstring).gameObject;
		
		switchHead.transform.position = refHead.transform.position;
		switchHead.transform.rotation = refHead.transform.rotation;
		switchHead.transform.parent = refHead.transform.parent;
		
		string temp = headstring;
		headstring = headstring2;
		headstring2 = temp;
		switchHead.name = headstring;
		
		GameObject.Destroy(refHead); 
	}
	
	private void ChangeClothes(int type)
	{
		string clothesType = categoryList[type].GetRandomShirt();
		GameObject clothes = (GameObject)Resources.Load("Npcs/BodyParts/"+clothesType);
		GameObject switchClothes = GameObject.Instantiate (clothes) as GameObject;

		GameObject refClothes = transform.Find ("Clothes").gameObject;
		
		switchClothes.transform.position = refClothes.transform.position;
		
		switchClothes.transform.parent = refClothes.transform.parent;
		switchClothes.transform.rotation = transform.rotation;
		
		Vector3 positionOffset = new Vector3(0.0139f,0.0049f, 0.0039f);
		switchClothes.name = "Clothes";
		
		GameObject.Destroy(refClothes);
		Material newMaterialPrefab = Resources.Load("Npcs/Materials/Clothes/"+categoryList[type].GetRandomShirtColor(clothesType), typeof(Material)) as Material;
		Material clothesMaterial = new Material(newMaterialPrefab);
		switchClothes = switchClothes.transform.Find ("clothes_mesh").gameObject;
		switchClothes.GetComponent<SkinnedMeshRenderer>().rootBone = transform.Find ("Customer_Kid/Hips 1");
		switchClothes.GetComponent<SkinnedMeshRenderer>().material = clothesMaterial;
		
		Material[] s = switchClothes.GetComponent<SkinnedMeshRenderer>().materials;
		if(s.Length > 1)
		{
			s[1] = clothesMaterial;
		}
		switchClothes.GetComponent<SkinnedMeshRenderer>().materials = s;
	}

	public DishStruct[] GetMainOrder(){
		return currentMainOrder;
	}
	
	public DishStruct GetSideOrder(){
		return currentSideOrder;
	}
	public DishStruct GetDrink(){
		return currentDrink;
	}
}

class Category
{
	string name;
	//apperance Lists
	List<string> skinColor = new List<string>();
	List<string> head = new List<string>();
	List<string> shirt = new List<string>();
	List<string> hair = new List<string>();
	List<string> hairColor = new List<string>();
	
	List<textureLinker> hairList = new List<textureLinker>();
	List<textureLinker> clothesList = new List<textureLinker>();	
	List<textureLinker> accessoryList = new List<textureLinker>();
	
	//food Lists
	
	List<DishStruct[]> mainOrders = new List<DishStruct[]>();
	List<DishStruct> sideOrders = new List<DishStruct>();
	List<DishStruct> drinks = new List<DishStruct>();
	
	string preferenceType;
	float preferenceAmount;
	float perfection;
	float patience;
	
	public Category (string name)
	{
		this.name = name;
	}
	
	public string GetName()
	{
		return name;
	}
	
	public string GetRandomSkinColor()
	{
		int value = skinColor.Count;
		return skinColor[Random.Range(0,value)];
	}
	
	public string GetRandomHead()
	{
		int value = head.Count;
		return head [Random.Range (0, value)];
	}
	
	public string GetRandomShirt()
	{
		int value = clothesList.Count;
		return clothesList[Random.Range(0,value)].GetType();
	}
	
	public string GetRandomShirtColor(string type)
	{
		int value = 0;
		for (int i = 0; i < clothesList.Count; i++)
		{
			if(clothesList[i].GetType() == type)
			{
				return clothesList[i].getRandomTexture();
			}
		}
		return "";
	}
	
	public string GetRandomAccessory()
	{
		int value = accessoryList.Count;
		return accessoryList[Random.Range(0,value)].GetType();
	}
	
	public string GetRandomAccessoryColor(string type)
	{
		int value = 0;
		for (int i = 0; i < accessoryList.Count; i++)
		{
			if(accessoryList[i].GetType() == type)
			{
				return accessoryList[i].getRandomTexture();
			}
		}
		return "";
	}
	
	public string GetRandomHair()
	{
		int value = hairList.Count;
		return hairList[Random.Range(0,value)].GetType();
	}
	
	public string GetRandomHairColor(string type)
	{
		int value = 0;
		for (int i = 0; i < hairList.Count; i++)
		{
			if(hairList[i].GetType() == type)
			{
				return hairList[i].getRandomTexture();
			}
		}
		return "";
	}
	
	public string GetPreferenceType()
	{
		return preferenceType;
	}
	
	public float GetPreferenceAmount()
	{
		return preferenceAmount;
	}
	
	public float GetPerfection()
	{
		return perfection;
	}
	public float GetPatience()
	{
		return patience;
	}

	public DishStruct[] GetRandomMainOrder()
	{
		int value = mainOrders.Count;
		return mainOrders[Random.Range(0,value)];
	}
	
	public DishStruct GetRandomSideOrder()
	{
		int value = sideOrders.Count;
		return sideOrders[Random.Range(0,value)];
	}
	public DishStruct GetRandomDrink()
	{
		int value = drinks.Count;
		return drinks[Random.Range(0,value)];
	}
	
	public void writeProperties()
	{
		foreach (string p in skinColor)
		{
			Debug.Log ("skinColor: "+p);
		}
		foreach (string p in shirt)
		{
			Debug.Log ("shirt: "+p);
		}
	}
	
	public void WriteRecipies()
	{
	}

	public void AddSkinColor(string skinColor)
	{
		this.skinColor.Add (skinColor);
	}
	
	public void AddHead(string head)
	{
		this.head.Add (head);
	}
	
	public void AddClothes(string shirt)
	{
		clothesList.Add (new textureLinker (shirt));
	}
	
	public void AddClothesColor(string shirtColor)
	{
		clothesList[clothesList.Count-1].AddTexture (shirtColor);
	}
	
	public void AddAccessory(string accessory)
	{
		accessoryList.Add (new textureLinker (accessory));
	}
	
	public void AddAccessoryColor(string AccesoryColor)
	{
		accessoryList[accessoryList.Count-1].AddTexture (AccesoryColor);
	}
	
	public void AddHair(string hair)
	{
		hairList.Add (new textureLinker (hair));
	}
	
	public void AddHairColor(string hairColor)
	{
		hairList[hairList.Count-1].AddTexture (hairColor);
	}
	
	public void AddMainOrder(DishStruct[] dish)
	{
		mainOrders.Add(dish);
	}
	
	public void AddSideOrder(DishStruct side)
	{
		sideOrders.Add(side);
	}
	
	public void AddDrink(DishStruct drink)
	{
		drinks.Add(drink);
	}
	
	public void setPreferenceType(string f)
	{
		preferenceType = f;
	}
	
	public void setPreferenceAmount(string f)
	{
	}
	
	public void setPerfection(string f)
	{
	}
	
	public void setPatience(string f)
	{
	}
}

class textureLinker
{
	string type;
	
	List<string> textures = new List<string>();
	
	public textureLinker(string type)
	{
		this.type = type;
	}
	
	public void AddTexture(string texture)
	{
		textures.Add (texture);
	}
	
	public string getRandomTexture()
	{
		int value = textures.Count;
		return textures[Random.Range(0,value)];
	}
	
	public string GetType()
	{
		return type;
	}
	
	public void print()
	{
		Debug.Log (type);
		foreach (string p in textures)
		{
			Debug.Log(p);
		}
		Debug.Log("-------");
	}
}
