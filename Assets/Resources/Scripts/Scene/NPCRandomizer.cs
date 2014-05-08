using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;



public class NPCRandomizer : MonoBehaviour {
	
	
	
	
	string loadFile;
	public string[] categories = new string[20];
	List<Category> categoryList = new List<Category>();
	public bool newType = true;



	private DishStruct currentDrink;
	private DishStruct currentSideOrder;
	private DishStruct[] currentMainOrder;

	// Use this for initialization
	void Start () {
		string dataString;
		string value;
		string spliter;
		int counter = 0; //temporary for debug
		
		
		loadFile = "NPCproperties.xml";
		StreamReader r = File.OpenText ("Assets/Resources/XML/" + loadFile);
		
		dataString = r.ReadToEnd ();
		
		
		XmlReader reader = XmlReader.Create (new StringReader (dataString));
		
		while (!reader.EOF) 
		{
			reader.ReadToFollowing ("category");
			reader.MoveToFirstAttribute ();
			value = reader.Value;
			
			if(value != "")
			{	
				categories[counter] = value;
				categoryList.Add(new Category(value));
				
				
				
				reader.ReadToFollowing("skincolors");
				reader.Read ();
				spliter = reader.Value;
				
				string[] s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddSkinColor(s[i]);
				}
				
				
				reader.ReadToFollowing("head");
				reader.Read ();
				spliter = reader.Value;
				
				s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddHead(s[i]);
				}
				
				
				reader.ReadToFollowing("shirts");
				do
				{
					reader.MoveToFirstAttribute ();
					categoryList[counter].AddShirt(reader.Value);
					reader.Read();
					
					spliter = reader.Value;
					s = spliter.Split(' ');
					foreach(string p in s){
						categoryList[counter].AddShirtColor(p);
					}
					reader.Read();
					reader.Read();
					reader.Read();
					
					
				}while(reader.Name == "shirts");
				
				
				
				
				reader.Read ();
				spliter = reader.Value;
				s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddAccessorie(s[i]);
				}
				
				//HAIR START
				reader.ReadToFollowing("hair");
				
				do
				{
					reader.MoveToFirstAttribute ();
					categoryList[counter].AddHair (reader.Value);
					
					reader.Read();
					
					spliter = reader.Value;
					
					s = spliter.Split(' ');
					foreach(string p in s){
						categoryList[counter].AddHairColor(p);
					}
					reader.Read();
					reader.Read();
					reader.Read();
					
					
				}while(reader.Name == "hair");
				
				//--HAIR END
				
				
				//reader.ReadToFollowing("preferenceType");
				reader.Read ();
				spliter = reader.Value;
				categoryList[counter].setPreferenceType(spliter);
				
				reader.ReadToFollowing("preferenceAmount");
				reader.Read ();
				spliter = reader.Value;
				categoryList[counter].setPreferenceAmount(spliter);
				
				
				reader.ReadToFollowing("perfection");
				reader.Read ();
				spliter = reader.Value;
				categoryList[counter].setPerfection(spliter);
				
				reader.ReadToFollowing("patience");
				reader.Read ();
				spliter = reader.Value;
				categoryList[counter].setPatience(spliter);
				
				
				
				//	categoryList[counter].writeProperties();
				
			}
			counter++;
		}
		
		
		// recipie XML
		
		
		loadFile = "NPCrecipies.xml";
		r = File.OpenText ("Assets/Resources/XML/" + loadFile);
		dataString = r.ReadToEnd ();
		reader = XmlReader.Create (new StringReader (dataString));
		while (!reader.EOF) 
		{
			reader.ReadToFollowing ("type");
			reader.MoveToFirstAttribute ();
			value = reader.Value;
			
			if(value != "")
			{
				int offset = 0;
				string[] s;
				for(int i = 0;i < categoryList.Count;i++)
				{
					if(categoryList[i].GetName() == value)
					{
						offset = i;
						i = categoryList.Count;
					}
				}
				

				reader.ReadToFollowing("maindish");
				
				
				while(reader.Name == "maindish")
				{
					List<DishStruct> dishList = new List<DishStruct>();
					reader.Read();	//<name>
					while(reader.Name == "name")
					{
						DishStruct dish = new DishStruct();
						reader.Read();	//Soup
						dish.dish = reader.Value;
						reader.ReadToFollowing("number");
						reader.Read();	//20
						dish.number =  int.Parse(reader.Value);
						reader.ReadToFollowing("value");
						reader.Read();	//100
						dish.baseValue = int.Parse(reader.Value);
						reader.Read();	//</value>
						reader.Read();	//NewLine
						reader.Read();	//<name> OR </maindish>
						dishList.Add (dish);
					}
					reader.Read();	//New line
					reader.Read();	//<maindish> OR <SideOrder>
					//Old code
					//s = spliter.Split(' ');	
					categoryList[offset].AddMainOrder(dishList.ToArray());
				}
				
				while(reader.Name == "sideorder")
				{
					DishStruct dish = new DishStruct();
					reader.Read();	//<name>
					reader.Read();	//Bread
					dish.dish = reader.Value;
					reader.ReadToFollowing("number");
					reader.Read();	//1
					dish.number = int.Parse(reader.Value);
					reader.ReadToFollowing("value");
					reader.Read();	//50
					dish.baseValue = int.Parse(reader.Value);

					//spliter = reader.Value;
					categoryList[offset].AddSideOrder(dish);
					reader.Read();	//</value>
					reader.Read();	//New line
					reader.Read();	//</sideorder>
					reader.Read();	//New line
					reader.Read();	//<sideorder> OR <drink>

				}
				while(reader.Name == "drink")
				{
					DishStruct dish = new DishStruct();
					reader.Read();	//<name>
					reader.Read();	//Milk
					dish.dish = reader.Value;
					reader.ReadToFollowing("number");
					reader.Read();	//1
					dish.number = int.Parse(reader.Value);
					reader.ReadToFollowing("value");
					reader.Read();	//50
					dish.baseValue = int.Parse(reader.Value);
					reader.Read();	//</value>
					reader.Read();	//New line
					reader.Read();	//</drink>
					reader.Read();	//New line
					reader.Read();	//<drink> OR </type>

					categoryList[offset].AddDrink(dish);
					
				}
				
				
				
			}
			
		}
		
		
		/*	for (int i = 0; i < categoryList.Count; i++) {
			categoryList[i].WriteRecipies();
		}*/
		
		
		
		
		newType = true;
		
		
		
	}
	
	// Update is called once per frame
	void Update () {

		if (newType) 
		{
			//debug grejer
			newType = false;
			int type = Random.Range(0,categoryList.Count);
			ChangeClothes(type);
			ChangeHair(type);
			ChangeSkinColor(type);
			ChangeHead(type);
			
			
			
			//DEBUG
			/*
			Debug.Log("type: "+categoryList[type].getName());
			Debug.Log("sex: "+categoryList[type].GetRandomSex());
			Debug.Log("skinColor: "+categoryList[type].GetRandomSkinColor());
			Debug.Log("shirt: "+categoryList[type].GetRandomShirt());
			Debug.Log("pants: "+categoryList[type].GetRandomPants());
			Debug.Log("accessories: "+categoryList[type].GetRandomAccessories());
			Debug.Log("hair: "+categoryList[type].GetRandomHair());
			Debug.Log("hairColor: "+categoryList[type].GetRandomHairColor());
			Debug.Log("face: "+categoryList[type].GetRandomFace());
	//		Debug.Log("preferenceType: "+categoryList[type].GetPreferenceType());
		//	Debug.Log("preferenceAmount: "+categoryList[type].GetPreferenceAmount());
	//		Debug.Log("perfection: "+categoryList[type].GetPerfection());
	//		Debug.Log("patience: "+categoryList[type].GetPatience());
			*/
			currentMainOrder = categoryList[type].GetRandomMainOrder();
			//Debug.Log ("mainorder: " + currentMainOrder[0] + " " + currentMainOrder[1]);
			currentSideOrder = categoryList[type].GetRandomSideOrder();
			//Debug.Log("sideorder: " + currentSideOrder);
			currentDrink = categoryList[type].GetRandomDrink();
			//Debug.Log("drinks: " + currentDrink);
			//Debug.Log ("--------------------------------");
			//-DEBUG
			
			
		}
		



		
	}
	

	private void ChangeHair(int type)
	{
		string hairType = categoryList[type].GetRandomHair();
		GameObject obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/Hair").gameObject;
		
		GameObject obj1 = (GameObject)Resources.Load("Prefabs/NPCParts/"+hairType);
		
		obj.GetComponent<MeshFilter>().mesh = obj1.GetComponent<MeshFilter>().sharedMesh;
		
		Material newMaterialPrefab = Resources.Load("Materials/NPCMaterials/"+categoryList[type].GetRandomHairColor(hairType), typeof(Material)) as Material;
		Material newMaterial = new Material(newMaterialPrefab);
		obj.renderer.material = newMaterial;
		
	}
	
	
	
	
	
	private void ChangeSkinColor(int type)
	{
		
		GameObject obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/CHead").gameObject;		
		Material newMaterialPrefab = Resources.Load("Materials/NPCMaterials/"+categoryList[type].GetRandomSkinColor(), typeof(Material)) as Material;
		Material skinColor = new Material(newMaterialPrefab);
		obj.renderer.material  = skinColor;
		obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/eye_left_mesh_003").gameObject;
		obj.renderer.material  = skinColor;
		obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/eye_right_mesh_003").gameObject;
		obj.renderer.material  = skinColor;
		//-Eyes
		
		
		obj = transform.Find("Body").gameObject;
		obj.renderer.material  = skinColor;
	}
	
	
	
	
	
	
	private void ChangeHead(int type)
	{
		GameObject obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/CHead").gameObject;
		GameObject obj1 = (GameObject)Resources.Load("Prefabs/NPCParts/"+categoryList[type].GetRandomHead());
		obj.GetComponent<MeshFilter>().sharedMesh = obj1.GetComponent<MeshFilter>().sharedMesh;
		
	}
	
	
	
	
	
	private void ChangeClothes(int type)
	{
		string clothesType = categoryList[type].GetRandomShirt();
		GameObject obj1 = (GameObject)Resources.Load("Prefabs/NPCParts/"+clothesType);
		obj1 = obj1.transform.Find("clothes_mesh").gameObject;
		GameObject obj = transform.Find("Clothes/Clothes_Mesh").gameObject;
		
		
		obj.GetComponent<SkinnedMeshRenderer>().sharedMesh = obj1.GetComponent<SkinnedMeshRenderer>().sharedMesh;
		
		Material newMaterialPrefab = Resources.Load("Materials/NPCMaterials/"+categoryList[type].GetRandomShirtColor(clothesType), typeof(Material)) as Material;
		Material clothesMaterial = new Material(newMaterialPrefab);
		obj.renderer.material = clothesMaterial;
		
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




class Category{
	string name;
	//apperance Lists
	List<string> skinColor = new List<string>();
	List<string> head = new List<string>();
	List<string> shirt = new List<string>();
	List<string> accessories = new List<string>();
	List<string> hair = new List<string>();
	List<string> hairColor = new List<string>();
	
	List<textureLinker> hairList = new List<textureLinker>();
	List<textureLinker> shirtList = new List<textureLinker>();	

	
	//food Lists
	
	List<DishStruct[]> mainOrders = new List<DishStruct[]>();
	List<DishStruct> sideOrders = new List<DishStruct>();
	List<DishStruct> drinks = new List<DishStruct>();
	/*List<string[]> mainOrders = new List<string[]>();
	List<int[]> mainNumbers = new List<int[]> ();
	List<int[]> mainScore = new List<int[]> ();
	List<string> sideOrders = new List<string>();
	List<int> siteNumbers = new List<int> ();
	List<int> siteScore = new List<int> ();
	List<string> drinks = new List<string>();
	List<int> drinkNumbers = new List<int> ();
	List<int> drinkScore = new List<int> ();*/
	
	
	string preferenceType;
	float preferenceAmount;
	float perfection;
	float patience;
	
	
	
	public Category (string name)
	{
		this.name = name;
		
	}
	
	public string GetName(){
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
		int value = shirtList.Count;
		return shirtList[Random.Range(0,value)].GetType();
	}

	public string GetRandomShirtColor(string type)
	{
		int value = 0;
		for (int i = 0; i < shirtList.Count; i++) {
			if(shirtList[i].GetType() == type){
				return shirtList[i].getRandomTexture();
			}
		}
		
		return "";
	}

	public string GetRandomAccessories()
	{
		int value = accessories.Count;
		return accessories[Random.Range(0,value)];
	}
	public string GetRandomHair()
	{
		int value = hairList.Count;
		return hairList[Random.Range(0,value)].GetType();
	}
	public string GetRandomHairColor(string type)
	{
		int value = 0;
		for (int i = 0; i < hairList.Count; i++) {
			if(hairList[i].GetType() == type){
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
		foreach (string p in skinColor) {
			Debug.Log ("skinColor: "+p);
		}
		foreach (string p in shirt) {
			Debug.Log ("shirt: "+p);
		}
		foreach (string p in accessories) {
			Debug.Log ("accesorie: "+p);
		}
		
	}
	
	public void WriteRecipies()
	{
		
		/*Debug.Log ("Start of: " + name);
		
		for (int i = 0; i < mainOrders.Count; i++) 
		{
			Debug.Log ("mainorder: " + mainOrders[i][0] + " " + mainOrders[i][1]);
		}
		foreach (string p in sideOrders) {
			Debug.Log ("sideorder: "+p);
		}
		foreach (string p in drinks) {
			Debug.Log ("drink: "+p);
		}
		Debug.Log ("End of: " + name);*/
	}
	

	public void AddSkinColor(string skinColor)
	{
		this.skinColor.Add (skinColor);
	}
	public void AddHead(string head)
	{
		this.head.Add (head);
	}
	public void AddShirt(string shirt)
	{
		shirtList.Add (new textureLinker (shirt));
	}
	public void AddShirtColor(string shirtColor)
	{
		shirtList[shirtList.Count-1].AddTexture (shirtColor);
	}
	public void AddAccessorie(string accessorie)
	{
		this.accessories.Add (accessorie);
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
	
	public void AddDrink(DishStruct drink){
		drinks.Add(drink);
		
	}
	
	public void setPreferenceType(string f)
	{
		preferenceType = f;
		
	}
	public void setPreferenceAmount(string f)
	{
	//	preferenceAmount = float.Parse (f);
		
	}
	public void setPerfection(string f)
	{
	//	perfection = float.Parse (f);
		
	}
	public void setPatience(string f)
	{
	//	patience = float.Parse (f);
		
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
	
	
	public void print(){
		Debug.Log (type);
		foreach (string p in textures) {
			Debug.Log(p);
		}
		Debug.Log("-------");
	}
	
	
}
