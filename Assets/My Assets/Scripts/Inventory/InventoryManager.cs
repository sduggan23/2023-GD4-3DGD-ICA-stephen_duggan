using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    public void HandleConsumablePickup(ItemData item)
    {
        // Check if the item exists in the inventory
        if (inventory.Contents.ContainsKey(item))
        {
            int count = inventory.Contents[item];
            count++;
            inventory.Contents[item] = count;
            // Update the GameManager to reflect the change in the item count
            GameManager.instance.UpdatetemCount();
        }
        else
        {
            // If the item is not in the inventory, add it
            inventory.Contents.Add(item, 1);
            GameManager.instance.UpdatetemCount();
        }
    }
}