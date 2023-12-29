using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
	[Tooltip("The name of the item")]
	[SerializeField]
	private string name;

	[Tooltip("A description of the item")]
	[SerializeField]
	[Multiline]
	private string description = default;

	[Tooltip("A preview image for the item")]
	[SerializeField]
	private Sprite previewImage;


	//[Tooltip("The type of item")]
	//[SerializeField]
	//private ItemType _itemType = default;

	//[Tooltip("A prefab reference for the model of the item")]
	//[SerializeField]
	//private GameObject _prefab = default;

	public string Name => name;
	public Sprite PreviewImage => previewImage;
	public string Description => description;
	//public ItemType ItemType => itemType;
	//public GameObject Prefab => prefab;

}