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
		
		
		//StreamReader r = File.OpenText ("Assets/Resources/XML/" + loadFile);
		
		//dataString = r.ReadToEnd ();
		TextAsset textAsset = (TextAsset) Resources.Load("XML/NPCproperties");
		if(textAsset == null)
		{
			Debug.Log("null testAsset");
		}
		//XmlDocument xmldoc = new XmlDocument();
		//xmldoc.LoadXml ( textAsset.text );
		var sr = new StringReader (textAsset.text);
		if(sr == null)
		{
			Debug.Log("null sr");
		}
		XmlReader reader = XmlReader.Create(sr);
		
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
				
				
				
				do
				{
					reader.MoveToFirstAttribute ();
					categoryList[counter].AddAccessory(reader.Value);
					reader.Read();
					
					spliter = reader.Value;
					s = spliter.Split(' ');
					foreach(string p in s){
						categoryList[counter].AddAccessoryColor(p);
					}
					reader.Read();
					reader.Read();
					reader.Read();
					
					
				}while(reader.Name == "accessory");
				
				
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
		
		
		//loadFile = "NPCrecipies.xml";
		//r = File.OpenText ("Assets/Resources/XML/" + loadFile);
		//dataString = r.ReadToEnd ();
		
		textAsset = (TextAsset) Resources.Load("XML/NPCrecipies");
		//XmlDocument xmldoc = new XmlDocument();
		//xmldoc.LoadXml ( textAsset.text );
		reader = XmlReader.Create (new StringReader (textAsset.text));
		
		//reader = XmlReader.Create (new StringReader (dataString));
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
		
			newType = false;
			int type = Random.Range(0,categoryList.Count);
			ChangeClothes(type);
			ChangeHead(type);
			ChangeSkinColor(type);
			ChangeHair(type);
			
			

			
			currentMainOrder = categoryList[type].GetRandomMainOrder();
		
			currentSideOrder = categoryList[type].GetRandomSideOrder();
		
			currentDrink = categoryList[type].GetRandomDrink();

			transform.GetComponent<NpcBehaviour>().faceready = true;
			
		}
		



		
	}
	

	private void ChangeHair(int type)
	{
		string hairType = categoryList[type].GetRandomHair();
		
		
		GameObject Hair = (GameObject)Resources.Load("Prefabs/NPCParts/"+hairType);
		GameObject setHair = GameObject.Instantiate(Hair) as GameObject;
		GameObject refHead =  transform.Find("Customer_Kid/Hips 1/Spine/Spine1/Spine2/Neck/Head 1/head_kid").gameObject;
		setHair.transform.position = transform.position;
		setHair.transform.parent = refHead.transform;
		
		setHair.transform.rotation = refHead.transform.rotation;
		
		Vector3 positionOffset = new Vector3(0.00323f,0.764549f, -0.005494945f);
		setHair.transform.localPosition = positionOffset;
	
		
		
		
		setHair.name = "hair";
		
		
		Material newMaterialPrefab = Resources.Load("Materials/NPCMaterials/"+categoryList[type].GetRandomHairColor(hairType), typeof(Material)) as Material;
		Material newMaterial = new Material(newMaterialPrefab);
		setHair.renderer.material = newMaterial;
		
	}
	
	
	
	
	
	private void ChangeSkinColor(int type)
	{
		
		Material newMaterialPrefab = Resources.Load("Materials/NPCMaterials/"+categoryList[type].GetRandomSkinColor(), typeof(Material)) as Material;
		Material skinColor = new Material(newMaterialPrefab);
		GameObject refObj =  transform.Find("Customer_Kid/Hips 1/Spine/Spine1/Spine2/Neck/Head 1/head_kid").gameObject;
		MeshRenderer[] obj;
		obj = refObj.transform.GetComponentsInChildren<MeshRenderer>();
		
		foreach (MeshRenderer b in obj) 
		{
			Debug.Log (b.ToString ());
			
			b.material = skinColor;
		}
		SkinnedMeshRenderer[] obj1 = refObj.transform.GetComponentsInChildren<SkinnedMeshRenderer>();
		
		
		foreach (SkinnedMeshRenderer b in obj1) 
		{
			Debug.Log (b.ToString ());
			
			b.material = skinColor;
		}
	
		GameObject obj2 = transform.Find("body_kid_mesh_005").gameObject;
		obj2.renderer.material  = skinColor;
	}
	
	
	
	
	
	
	private void ChangeHead(int type)
	{
		string headType = categoryList[type].GetRandomHead();
		GameObject head = (GameObject)Resources.Load("Prefabs/NPCParts/"+headType);
		GameObject switchHead = GameObject.Instantiate(head) as GameObject;
		
		GameObject refHead =  transform.Find("Customer_Kid/Hips 1/Spine/Spine1/Spine2/Neck/Head 1/head_kid1").gameObject;
		
		switchHead.transform.position = refHead.transform.position;
		switchHead.transform.rotation = refHead.transform.rotation;
		switchHead.transform.parent = refHead.transform.parent;
		switchHead.name = "head_kid";
		GameObject.Destroy(refHead); 
		
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
	List<string> hair = new List<string>();
	List<string> hairColor = new List<string>();
	
	List<textureLinker> hairList = new List<textureLinker>();
	List<textureLinker> shirtList = new List<textureLinker>();	
	List<textureLinker> accessoryList = new List<textureLinker>();
	
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
	
	public string GetRandomAccessory()
	{
		int value = accessoryList.Count;
		return accessoryList[Random.Range(0,value)].GetType();
	}
	public string GetRandomAccessoryColor(string type)
	{
		int value = 0;
		for (int i = 0; i < accessoryList.Count; i++) {
			if(accessoryList[i].GetType() == type){
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
