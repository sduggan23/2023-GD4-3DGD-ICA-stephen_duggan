using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory")]
public class Inventory : SerializedScriptableObject
{
    public Dictionary<ItemData, int> Contents;

    public int GetItemDataCount()
    {
        return Contents.Keys.Count;
    }
}