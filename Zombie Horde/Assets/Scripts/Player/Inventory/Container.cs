using System.Linq;
using UnityEngine;

[System.Serializable]
public class Container
{
    GameManager gameManager => GameManager.instance;
    
    public ItemData[] items;

    public Container(int size)
    {
        items = new ItemData[size];
    }

    public ItemData Get(int slot)
    {
        return items[slot];
    }
    
    public bool Contains(int itemId, int amount = 1)
    {
        return items.Where(i => i != null).Any(i => i.item.itemId == itemId && i.amount >= amount);
    }

    public int GetSlot(int id)
    {
        for (int index = 0; index < items.Length; index++)
        {
            if (items[index] == null) continue;
            //If the id's match return the right slot
            if (items[index].item.itemId == id) return index;
        }
        return -1;
    }

    public int GetAmount()
    {
        
    }

    public int FreeSlot()
    {
        for (var index = 0; index < items.Length; index++)
            if (items[index] == null || items[index].item.itemId == -1) return index;
        return -1;
    }

    public bool Add(int itemId, int amount = 1, int slot = -1)
    {
        var itemToAdd = gameManager.itemDefinition[itemId];
        if (itemToAdd == null) return false;
        
        int newSlot = slot == -1 ? FreeSlot() : slot;
        if (itemToAdd.stackable) newSlot = GetSlot(itemId);

        if (newSlot == -1) return false;

        if (itemToAdd.stackable)
        {
            var item = items[newSlot];
            var totalAmount = item.amount + amount;
            if (totalAmount >= int.MaxValue || totalAmount < 1) return false;

            item.amount = totalAmount;
            return true;
        }
        else
        {
            
        }

        Debug.Log($"itemName[Add]: {itemToAdd.itemName}");
        
        return true;
    }

    public bool Remove(int itemId, int amount = 1)
    {
        var itemToRemove = gameManager.itemDefinition[itemId];
        
        Debug.Log($"itemName[Remove]: {itemToRemove.itemName}");
        
        return true;
    }
}
