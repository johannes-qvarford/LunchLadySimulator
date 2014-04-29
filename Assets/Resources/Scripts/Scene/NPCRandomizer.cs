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



	private string currentDrink;
	private string currentSideOrder;
	private string[] currentMainOrder;

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
				
				
				reader.ReadToFollowing("sex"); //add sex
				reader.Read ();
				spliter = reader.Value;
				string[] s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddSex(s[i]);
				}
				
				reader.ReadToFollowing("skincolors");
				reader.Read ();
				spliter = reader.Value;
				
				s = spliter.Split(' ');
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
				reader.Read ();
				spliter = reader.Value;
				s = spliter.Split(' ');
				
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddShirt(s[i]);
				}
				
				reader.ReadToFollowing("pants");
				reader.Read ();
				spliter = reader.Value;
				s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddPants(s[i]);
				}
				
				reader.ReadToFollowing("accessories");
				reader.Read ();
				spliter = reader.Value;
				s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddAccessorie(s[i]);
				}
				
				reader.ReadToFollowing("hair");
				reader.Read ();
				spliter = reader.Value;
				s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddHair(s[i]);
				}
				
				reader.ReadToFollowing("haircolors");
				reader.Read ();
				spliter = reader.Value;
				s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddHairColor(s[i]);
				}
				
				
				reader.ReadToFollowing("face");
				reader.Read ();
				spliter = reader.Value;
				s = spliter.Split(' ');
				for(int i = 0;i < s.Length;i++)
				{
					categoryList[counter].AddFace(s[i]);
				}
				
				reader.ReadToFollowing("preferenceType");
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
					if(categoryList[i].getName() == value)
					{
						offset = i;
						i = categoryList.Count;
					}
				}
				
				
				reader.ReadToFollowing("maindish");
				
				
				while(reader.Name == "maindish")
				{
					
					reader.Read();
					spliter = reader.Value;
					
					
					s = spliter.Split(' ');
					categoryList[offset].AddMainOrder(s);
					
					reader.Read();
					reader.Read();
					reader.Read();
				}
				
				
				while(reader.Name == "sideorder")
				{
					
					reader.Read();
					spliter = reader.Value;
					categoryList[offset].AddSideOrder(spliter);
					reader.Read();
					reader.Read();
					reader.Read();
				}
				while(reader.Name == "drink")
				{
					
					reader.Read();
					spliter = reader.Value;
					categoryList[offset].AddDrink(spliter);
					reader.Read();
					reader.Read();
					reader.Read();
					
					
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
			
			
			//face operations-
			//head
			GameObject obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/CHead").gameObject;
			GameObject obj1 = (GameObject)Resources.Load("Prefabs/NPCParts/"+categoryList[type].GetRandomHead());
			obj.GetComponent<MeshFilter>().sharedMesh = obj1.GetComponent<MeshFilter>().sharedMesh;


			Material newMaterialPrefab = Resources.Load("Materials/"+categoryList[type].GetRandomSkinColor(), typeof(Material)) as Material;
			Material randomSkinColor = new Material(newMaterialPrefab);
			obj.renderer.material  = randomSkinColor;
			//-head


			//Eyes
			newMaterialPrefab = Resources.Load("Materials/Eye_color", typeof(Material)) as Material;
			Material EyeColor = new Material(newMaterialPrefab);

			obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/eye_left_mesh_003").gameObject;
			obj.renderer.material  = EyeColor;
			obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/eye_right_mesh_003").gameObject;
			obj.renderer.material  = EyeColor;
			//-Eyes

		//	transform.renderer.material = randomSkinColor;

			//-face operations

			/*
			//legs operation-
			obj = transform.Find("legs_mesh_001").gameObject;
			newMaterialPrefab = Resources.Load("Material/"+categoryList[type].GetRandomPants(), typeof(Material)) as Material;
			Material newMaterial2 = new Material(newMaterialPrefab);
			obj.renderer.material  = newMaterial2;
			//-legs operation


			*/
			obj = transform.Find("Body").gameObject;


			obj.renderer.material  = randomSkinColor;
			//-body operations
			
			//	obj.renderer.material;

			obj = transform.Find("Customer_Kid/Hips/Spine/Spine1/Spine2/Neck/Head/Headmesh/Hair").gameObject;
			obj1 = (GameObject)Resources.Load("Prefabs/NPCParts/"+categoryList[type].GetRandomHair());
		
			obj.GetComponent<MeshFilter>().sharedMesh = obj1.GetComponent<MeshFilter>().sharedMesh;


			newMaterialPrefab = Resources.Load("Materials/"+categoryList[type].GetRandomHairColor(), typeof(Material)) as Material;
			Material newMaterial2 = new Material(newMaterialPrefab);
			obj.renderer.material = newMaterial2;

			
			//DEBUG
			
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
			currentMainOrder = categoryList[type].GetRandomMainOrder();
			Debug.Log ("mainorder: " + currentMainOrder[0] + " " + currentMainOrder[1]);
			currentSideOrder = categoryList[type].GetRandomSideOrder();
			Debug.Log("sideorder: " + currentSideOrder);
			currentDrink = categoryList[type].GetRandomDrink();
			Debug.Log("drinks: " + currentDrink);
			Debug.Log ("--------------------------------");
			//-DEBUG
			
			
		}
		



		
	}


	public string[] GetMainOrder(){
		return currentMainOrder;
	}
	
	public string GetSideOrder(){
		return currentSideOrder;
	}
	public string GetDrink(){
		return currentDrink;
	}


}




class Category{
	string name;
	//apperance Lists
	List<string> sex = new List<string>();
	List<string> skinColor = new List<string>();
	List<string> head = new List<string>();
	List<string> shirt = new List<string>();
	List<string> pants = new List<string>();
	List<string> accessories = new List<string>();
	List<string> hair = new List<string>();
	List<string> hairColor = new List<string>();
	List<string> face = new List<string>();
	
	
	//food Lists
	
	List<string[]> mainOrders = new List<string[]>();
	List<string> sideOrders = new List<string>();
	List<string> drinks = new List<string>();
	
	
	string preferenceType;
	float preferenceAmount;
	float perfection;
	float patience;
	
	
	
	public Category (string name)
	{
		this.name = name;
		
	}
	
	public string getName(){
		return name;
	}
	
	public string GetRandomSex()
	{
		int value = sex.Count;
		return sex[Random.Range(0,value)];
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
		int value = shirt.Count;
		return shirt[Random.Range(0,value)];
	}
	public string GetRandomPants()
	{
		int value = pants.Count;
		return pants[Random.Range(0,value)];
	}
	public string GetRandomAccessories()
	{
		int value = accessories.Count;
		return accessories[Random.Range(0,value)];
	}
	public string GetRandomHair()
	{
		int value = hair.Count;
		return hair[Random.Range(0,value)];
	}
	public string GetRandomHairColor()
	{
		int value = hairColor.Count;
		return hairColor[Random.Range(0,value)];
	}
	public string GetRandomFace()
	{
		int value = face.Count;
		return face[Random.Range(0,value)];
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
	
	public string[] GetRandomMainOrder()
	{
		int value = mainOrders.Count;
		return mainOrders[Random.Range(0,value)];
	}
	
	public string GetRandomSideOrder()
	{
		int value = sideOrders.Count;
		return sideOrders[Random.Range(0,value)];
	}
	public string GetRandomDrink()
	{
		int value = drinks.Count;
		return drinks[Random.Range(0,value)];
	}
	
	
	public void writeProperties()
	{
		foreach (string p in sex) {
			Debug.Log ("sex: "+p);
		}
		foreach (string p in skinColor) {
			Debug.Log ("skinColor: "+p);
		}
		foreach (string p in shirt) {
			Debug.Log ("shirt: "+p);
		}
		foreach (string p in pants) {
			Debug.Log ("pants: "+p);
		}
		foreach (string p in accessories) {
			Debug.Log ("accesorie: "+p);
		}
		foreach (string p in hair) {
			Debug.Log ("hair: "+p);
		}
		foreach (string p in hairColor) {
			Debug.Log ("hairColor: "+p);
		}
		foreach (string p in face) {
			Debug.Log ("face: "+p);
		}
		
	}
	
	public void WriteRecipies()
	{
		
		Debug.Log ("Start of: " + name);
		
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
		Debug.Log ("End of: " + name);
	}
	
	
	public void AddSex(string sex)
	{
		this.sex.Add (sex);
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
		this.shirt.Add (shirt);
	}
	public void AddPants(string pants)
	{
		this.pants.Add (pants);
	}
	public void AddAccessorie(string accessorie)
	{
		this.accessories.Add (accessorie);
	}
	public void AddHair(string hair)
	{
		this.hair.Add (hair);	
	}
	public void AddHairColor(string hairColor)
	{
		this.hairColor.Add (hairColor);
	}
	public void AddFace(string face)
	{
		this.face.Add(face);
	}
	
	public void AddMainOrder(string[] dish)
	{
		mainOrders.Add(dish);
	}
	
	public void AddSideOrder(string side)
	{
		sideOrders.Add(side);
	}
	
	public void AddDrink(string drink){
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







