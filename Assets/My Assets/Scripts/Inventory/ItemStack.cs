using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStack
{
	public ItemData itemData;
	public int stackSize;

	public ItemStack(ItemData item)
	{
		itemData = item;
		AddToStack();
	}

	public void AddToStack()
    {
		stackSize++;
	}

	public void RemoveFromStack()
    {
		stackSize--;
	}
}
