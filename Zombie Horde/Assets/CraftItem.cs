using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour
{
    private Player player;
    
    [SerializeField] public int slot;
    private Image image;
    private CraftingUI crafting;

    public void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
        crafting = GameManager.instance.GetComponent<CraftingUI>();
        image = GetComponent<Image>();
    }

    public void Craft()
    {
        var recipe = crafting.craftingRecipes[slot];
        var containsAll = player.inventory.ContainsAll(recipe.items);
        
        if (!containsAll) return;

        foreach (var item in recipe.items)
            player.inventory.Remove(item.item.itemId, item.amount);

        player.inventory.Add(recipe.craftedItem.item.itemId, recipe.craftedItem.amount);
    }

    public void HoverEnter()
    {
        image.color = new Color(1, 0.9682621f, 0, 0.09803922f);
    }

    public void HoverExit()
    {
        image.color = new Color(1, 1, 1, 0);
    }
}
