using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Container
{
    GameManager gameManager => GameManager.instance;
    
    public ItemData[] items;

    public Container(int size)
    {
        items = new ItemData[size];
        for (int index = 0; index < size; index++)
        {
            items[index] = new ItemData();
        }
    }

    public void Swap(int from, int to)
    {
        var temp = Get(from);
        items[from] = Get(to);
        items[to] = temp;
    }

    public ItemData Get(int slot)
    {
        return items[slot];
    }
    
    public bool Contains(int itemId, int amount = 1)
    {
        return items.Where(i => i != null && i.item != null).Any(i => i.item.itemId == itemId && i.amount >= amount);
    }

    public int GetSlot(int id)
    {
        for (var index = 0; index < items.Length; index++)
        {
            if (items[index] == null || items[index].item == null) continue;
            if (items[index].item.itemId == id) return index;
        }
        return -1;
    }

    public int GetAmount(int slot)
    {
        return (from i in items where i != null && !i.item where Get(slot).item.itemId == i.item.itemId select i.amount).Sum();
    }

    public int GetAmountFromItem(int id)
    {
        return (from i in items where i != null && i.item != null where id == i.item.itemId select i.amount).Sum();
    }

    public int FreeSlot()
    {
        for (var index = 0; index < items.Length; index++)
            if (items[index] == null || (items[index].item == null || items[index].item.itemId == -1)) return index;
        return -1;
    }

    public int FreeSlots()
    {
        return items.Count(i => i == null || i.item == null);
    }

    public bool Add(int itemId, int amount = 1, int slot = -1)
    {
        var itemToAdd = gameManager.itemDefinition[itemId];
        if (itemToAdd == null) return false;
        
        var newSlot = slot == -1 ? FreeSlot() : slot;
        
        if (itemToAdd.stackable && Contains(itemId)) newSlot = GetSlot(itemId);

        if (newSlot == -1) return false;

        if (itemToAdd.stackable)
        {
            var item = items[newSlot];
            if (item.item == null) item.item = itemToAdd;
            
            var totalAmount = item.amount + amount;
            if (totalAmount >= int.MaxValue || totalAmount < 1) return false;
            
            item.amount = totalAmount;
            return true;
        }
        else
        {
            int openSlots = FreeSlots();
            if (amount > openSlots) amount = openSlots;
            
            if (openSlots >= amount)
            {
                for (var index = 0; index < amount; index++)
                {
                    var item = items[FreeSlot()];
                    if (item.item == null) item.item = itemToAdd;
                    item.amount = 1;
                }
                return true;
            }
        }
        
        return true;
    }

    public bool Remove(int itemId, int amount = 1, int preferredSlot = -1)
    {
        var itemToRemove = gameManager.itemDefinition[itemId];
        if (itemToRemove == null) return false;
        
        var slot = GetSlot(itemId);
        if (slot == -1) return false;
        
        var item = items[slot];

        if (itemToRemove.stackable)
        {
            if (item == null || item.item == null) return false;
            if (item.amount >= amount)
                item.amount -= amount;
            else
            {
                item.item = null;
                item.amount = 0;
            }
        }
        else
        {
            for (var index = 0; index < amount; index++)
            {
                slot = GetSlot(itemId);
                if (slot != -1)
                {
                    item = items[slot];
                    item.item = null;
                    item.amount = 0;
                }
            }
            return true;
        }
        
        return true;
    }

    public void UpdateUI(GameObject[] ui)
    {
        for (int i = 0; i < ui.Length; i++)
        {
            for (var index = 0; index < items.Length; index++)
            {
                var player = GameManager.playerObject.GetComponent<Player>();
                int childCount = ui[i].transform.childCount;
                if (index >= childCount) continue;
                
                var slot = ui[i].transform.GetChild(index);

                //Handles highlighting the slot in the bottom inventory hotbar
                if (index < 9 && i == 0 && ui.Length > 1)
                {
                    var slotImage = slot.GetComponent<Image>();
                    if(index != player.inventorySlot)
                     
                        slotImage.color = new Color(1, 1, 1, 0.588f);
                    else
                        slotImage.color = new Color(1, 1, 1, 1);
                }
                
                var canvas = slot.GetChild(0);
                var image = canvas.GetChild(0);
                var text = image.GetChild(0);
                var bullets = image.GetChild(1);

                var itemSprite = image.GetComponent<Image>();
                var itemAmount = text.GetComponent<Text>();

                var item = items[ui.Length == 1 ? index + 9 : index];

                if (item == null || item.item == null)
                {
                    bullets.gameObject.SetActive(false);
                    itemSprite.enabled = false;
                    itemAmount.enabled = false;
                }
                else
                {
                    bullets.gameObject.SetActive(false);
                    itemSprite.enabled = true;
                    itemAmount.enabled = true;
                    itemSprite.sprite = item.item.uiSprite;
                    var amount = $"{item.amount}";
                    if (item.item.gun != null)
                    {
                        var weapon = player.weapon.GetWeapon(item.item.gun);
                        if (weapon != null)
                        {
                            var gun = weapon.gun;
                            bullets.gameObject.SetActive(true);
                            amount = $"{weapon.bulletsInChamber}/{player.inventory.GetAmountFromItem(gun.bullets.itemId)}";
                        }
                    }
                    else
                    if (!item.item.stackable) amount = "";
                    itemAmount.text = amount;
                }
            }
        }
    }
}
