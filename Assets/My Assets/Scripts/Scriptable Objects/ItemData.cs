using Sirenix.OdinInspector;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
	[Tooltip("The name of the item")]
	[SerializeField]
	private string itemName;

	[Tooltip("A description of the item")]
	[SerializeField]
	[Multiline]
	private string itemDescription = default;

	[Tooltip("A preview image for the item")]
	[PreviewField(50, Alignment = ObjectFieldAlignment.Left)]
	[SerializeField] private Sprite previewImage;

	[Min(-1000)]
	public int Value;


	public AudioClip PickupClip;


	//[Tooltip("The type of item")]
	//[SerializeField]
	//private ItemType _itemType = default;

	//[Tooltip("A prefab reference for the model of the item")]
	//[SerializeField]
	//private GameObject _prefab = default;

	public string Name => itemName;
	public Sprite PreviewImage => previewImage;
	public string Description => itemDescription;
	//public ItemType ItemType => itemType;
	//public GameObject Prefab => prefab;

}