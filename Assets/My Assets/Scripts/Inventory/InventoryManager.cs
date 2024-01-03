using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    public void HandleConsumablePickup(ItemData item)
    {
        if (inventory.Contents.ContainsKey(item))
        {
            int count = inventory.Contents[item];
            count++; //since int is value type this is a copy so we need to rewrite in
            inventory.Contents[item] = count;
            // inventory.Contents.Add(item, count);
            Debug.Log("Old item added");
        }
        else
        {
            inventory.Contents.Add(item, 1);
            Debug.Log("new item added");
        }
    }
}