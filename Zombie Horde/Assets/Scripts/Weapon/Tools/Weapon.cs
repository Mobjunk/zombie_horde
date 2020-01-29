using UnityEngine;

public class Weapon
{
    private Player player;
    
    public Weapon(Player player)
    {
        this.player = player;
    }
    
    public void Shoot()
    {
        var selectedItem = player.inventory.Get(player.inventorySlot);
        if (selectedItem == null || selectedItem.item == null)
        {
            //Debug.Log($"No item found.");
            return;
        }
        
        //Debug.Log($"name: {selectedItem.item.itemName}");
    }
}