using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public List<ItemStack> itemStack = new List<ItemStack>();
	private Dictionary<ItemData, ItemStack> itemDictionary = new Dictionary<ItemData, ItemStack>();

    private void OnEnable()
    {
		Item.OnItemCollected += AddToInventory;

	}

    public void AddToInventory(ItemData itemData)
	{
        if (itemDictionary.TryGetValue(itemData, out ItemStack item))
        {
			item.AddToStack();
			Debug.Log(item.itemData.name + "total stack is now: " + item.stackSize);
		}
        else
        {
			ItemStack newItem = new ItemStack(itemData);
			itemStack.Add(newItem);
			itemDictionary.Add(itemData, newItem);
			Debug.Log("Added to the stack");
		}

	}

	public void RemoveFromInventory(ItemData itemData)
	{
        if (itemDictionary.TryGetValue(itemData, out ItemStack item))
		{
			item.RemoveFromStack();
            if (item.stackSize == 0)
            {
				itemStack.Remove(item);
			}
        }
	}
}
