using System.Linq;
using UnityEngine;

public class Tool : Weapon<ToolData>
{
    public Tool(Player player) : base(player) { }

    public override bool CanUse()
    {
        return Get(GetWeapon(player.inventorySlot), player.inventorySlot) != null;
    }

    public override void Use()
    {
        if (!inputManager.pressedAttack || player.invetoryOpened || player.craftingOpened) return;
        
        var weapon = Get(GetWeapon(player.inventorySlot), player.inventorySlot);
        if (weapon == null) return;


        var correctTool = resourceSystem.CorrectTool(weapon.tool);

        if (!correctTool) return;
        
        weapon.toolDurability -= resourceSystem.GetResource().resourceObject.toolDamage;
        
        if (weapon.toolDurability <= 0)
        {
            player.inventory.Remove(weapon.tool.item.itemId, 1, weapon.slot);
            player.tools.Remove(weapon);
        }
        
        resourceSystem.DestroyResource((int) GetDamage());
    }

    public override float GetDamage()
    {
        var weapon = Get(GetWeapon(player.inventorySlot), player.inventorySlot);
        if (weapon == null) return 0;
        return weapon.tool.weaponDamage;
    }

    public override ToolData GetWeapon(int slot)
    {
        var selectedItem = player.inventory.Get(slot);
        if (selectedItem == null || selectedItem.item == null || selectedItem.item.tool == null) return null;
        
        if(!WeaponExists(selectedItem.item.tool, slot))
            player.tools.Add(new Tools(selectedItem.item.tool, slot));
        
        return selectedItem.item.tool;
    }

    public override bool WeaponExists(ToolData tool, int slot)
    {
        return player.tools.Where(tools => tools != null && tools.tool != null).Any(tools => tools.tool.Equals(tool) && tools.slot == slot);
    }
    
    public Tools Get(ToolData tool, int slot)
    {
        return player.tools.Where(tools => tools != null && tools.tool != null).FirstOrDefault(tools => tools.tool.Equals(tool) && tools.slot == slot);
    }
}