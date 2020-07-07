using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] List<PlayerInventorySlot> inventorySlots = new List<PlayerInventorySlot>();

    public void AddTrashItem(ItemTrash trash)
    {
        PlayerInventorySlot openSlot = inventorySlots.FirstOrDefault<PlayerInventorySlot>(p => p.isFull == false);
        GameObject newItem = Instantiate<GameObject>(trash.item, openSlot.slot.transform, false);
        openSlot.item = newItem.GetComponent<ItemTrash>();
    }

    public void RemoveTrashItem(ItemTrash trash)
    {
        PlayerInventorySlot fullSlot = inventorySlots.Find(p => p.item == trash);
        Destroy(fullSlot.item.item);
        fullSlot.item = null;
    }

    public ItemTrash GetTrashItem()
    {
        return inventorySlots.Find(p => p.isFull == true).item;
    }
}

