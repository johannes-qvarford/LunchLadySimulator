using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

/**
  * Class for building an NPC form random parts.
  * It looks into RecipiesData and PropertiesData, finds a random customer type,
  * and then builds an NPC from a random selection of the available parts for the customer type ala Frankenstein's monster.
  * It also randomizes the NPCs lunch order.
  **/
public class NpcBuilder : MonoBehaviour
{
	private const string HEAD_NPC_NAME = "head_kid1";
	private const string HEAD_NPC_PATH = "Customer_Kid/Hips 1/Spine/Spine1/Spine2/Neck/Head 1/" + HEAD_NPC_NAME;
	private const string BODY_MESH_NPC_PATH = "body_kid_mesh_005";
	private const string CLOTHES_NPC_PATH = "Clothes";
	
	private const string HAIRS_PATH = "Npcs/Materials/Hairs/";
	private const string BODY_PARTS_PATH = "Npcs/BodyParts/";
	private const string SKINS_PATH = "Npcs/Materials/Skins/";
	private const string CLOTHES_PATH = "Npcs/Materials/Clothes/";
	private const string CLOTHES_MESH_NAME = "clothes_mesh";

	private static Vector3 HAIR_OFFSET = new Vector3(-0.004115761f,0.7650016f, 0.00103934f);

	private GameObject headRef;
	private GameObject bodyMeshRef;
	private GameObject clothesRef;
	private GameObject clotherMeshRef;

	void Start()
	{
		BuildNpc();
	}

	public void BuildNpc()
	{
		NpcRecipiesData recipieData = PersistantNpcData.RecipiesData;
		NpcPropertiesData propertiesData = PersistantNpcData.PropertiesData;
		headRef = transform.Find(HEAD_NPC_PATH).gameObject;
		bodyMeshRef = transform.Find(BODY_MESH_NPC_PATH).gameObject;
		clothesRef = transform.Find(CLOTHES_NPC_PATH).gameObject;
		
		string randomType = RandomElement(recipieData.CustomerTypesToRecipies.Keys);
		
		BuildBodyParts(randomType, propertiesData);
		BuildLunchOrder(randomType, recipieData);
		BuildSoundBank(randomType);
		
		/*
		 * TODO: Find a more elegant way to do it.
		 */
		transform.GetComponent<NpcBehaviour>().setFaceReady(true, HEAD_NPC_NAME);
	}
	
	private void BuildBodyParts(string type, NpcPropertiesData propertiesData)
	{
		/*
		 * Order is important,
		 * Skin color has to be built before hair.
		 * TODO: Fix so that skin color doesn't replace hairs material, so the order doesn't matter.
		 */
		NpcPropertyCustomerType customerType = propertiesData.CustomerTypesToProperties[type];
		
		BuildHead(RandomElement(customerType.Heads));
		BuildSkinColor(RandomElement(customerType.SkinColors));
		
		{
			var clothes = customerType.Clothes;
			var clothesType = RandomElement(clothes);
			BuildClothes(clothesType.Attribute, RandomElement(clothesType.List));
		}
		
		{
			var hairs = customerType.Hairs;
			var hairType = RandomElement(hairs);
			BuildHair(hairType.Attribute, RandomElement(hairType.List));
		}
	}
	
	private void BuildLunchOrder(string type, NpcRecipiesData recipieData)
	{
		NpcRecipieCustomerType customerType = recipieData.CustomerTypesToRecipies[type];
		LunchOrder order = new LunchOrder
		(
			mainDishes: new NpcRecipie[] { RandomElement(customerType.MainDishes) }, //always one main dish, this will change in the future anyway.
			sideOrder: RandomElement(customerType.SideOrders),
			drink: RandomElement(customerType.Drinks)
		);
		BroadcastMessage("LunchOrderCreated", order, SendMessageOptions.RequireReceiver);
	}
	
	private void BuildSoundBank(string type)
	{
		var sounds = GameObject.FindWithTag(Tags.NPC_SOUND_BANK);
		GetComponent<SoundCheck>().FModAsset = sounds.GetComponent<SoundBank>().GetNpcSound(type);
	}
	
	private void BuildHair(string hairType, string hairColor)
	{
		GameObject Hair = (GameObject)Resources.Load(BODY_PARTS_PATH + hairType);
		GameObject setHair = (GameObject)GameObject.Instantiate(Hair);
		setHair.transform.position = transform.position;
		setHair.transform.parent = headRef.transform;
		
		setHair.transform.localPosition = HAIR_OFFSET;
		
		setHair.name = "hair";
		
		Material newMaterialPrefab = (Material)Resources.Load(HAIRS_PATH + hairColor);
		Material newMaterial = new Material(newMaterialPrefab);
		setHair.renderer.material = newMaterial;
		
		setHair.transform.rotation = headRef.transform.rotation;
	}
	
	private void BuildSkinColor(string skinColor)
	{
		Material newMaterialPrefab = (Material)Resources.Load(SKINS_PATH + skinColor);
		Material skinColorMaterial = new Material(newMaterialPrefab);
		
		MeshRenderer[] meshRendereres = headRef.transform.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer b in meshRendereres) 
		{
			b.material = skinColorMaterial;
		}
		
		SkinnedMeshRenderer[] skinnedMeshRenderers = headRef.transform.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer b in skinnedMeshRenderers) 
		{
			b.material = skinColorMaterial;
		}
		
		bodyMeshRef.renderer.material = skinColorMaterial;
	}
	
	private void BuildHead(string headType)
	{
		GameObject head = (GameObject)Resources.Load(BODY_PARTS_PATH + headType);
		GameObject switchHead = (GameObject)GameObject.Instantiate(head);
		headRef = SwapPlaceholderObject(headRef, switchHead);
	}
	
	private void BuildClothes(string shirt, string shirtColor)
	{
		{
			GameObject clothes = (GameObject)Resources.Load(BODY_PARTS_PATH + shirt);
			GameObject switchClothes = (GameObject)GameObject.Instantiate(clothes);
			clothesRef = SwapPlaceholderObject(clothesRef, switchClothes);
		}
		
		Vector3 positionOffset = new Vector3(0.0f,0.006f, 0.002f);
		clothesRef.transform.localPosition = positionOffset;
		
		Material newMaterialPrefab = (Material)Resources.Load(CLOTHES_PATH + shirtColor);
		Material clothesMaterial = new Material(newMaterialPrefab);
		
		GameObject mesh = clothesRef.transform.Find(CLOTHES_MESH_NAME).gameObject;
		SkinnedMeshRenderer renderer = mesh.GetComponent<SkinnedMeshRenderer>();
		renderer.material = clothesMaterial;
		
		/*
		 * Don't know why this is here but it works.
		 */
		if(renderer.materials.Length > 1)
		{
			renderer.materials[1] = clothesMaterial;
		}
	}
	
	private GameObject SwapPlaceholderObject(GameObject from, GameObject to)
	{
		to.transform.position = from.transform.position;
		to.transform.rotation = from.transform.rotation;
		to.transform.parent = from.transform.parent;
		to.name = from.name;
		GameObject.Destroy(from);
		return to;
	}
	
	private E RandomElement<E>(IEnumerable<E> sequence)
	{
		int randomIndex = UnityEngine.Random.Range(0, sequence.Count() - 1);
		return sequence
			.Select((elem, i) => new { Elem = elem, Index = i })
			.Single(pair => pair.Index == randomIndex)
			.Elem;
	}
	
	
}

