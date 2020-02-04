using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    [HideInInspector] public List<CraftingRecipe> craftingRecipes = new List<CraftingRecipe>();
    [SerializeField] private GameObject recipePrefab, recipeParent;
    private Player player;
    
    private void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
        
        //foreach (var recipe in craftingRecipes)
        for(var slot = 0; slot < craftingRecipes.Count; slot++)
        {
            var recipe = craftingRecipes[slot];
            var recipeObject = Instantiate(recipePrefab);
            recipeObject.GetComponent<CraftItem>().slot = slot;
            recipeObject.transform.SetParent(recipeParent.transform);
            recipeObject.transform.localScale = new Vector3(1,1,1);

            UpdateUI(recipeObject, recipe);
        }
    }

    private void Update()
    {
        var parent = recipeParent.transform;
        for (var slot = 0; slot < craftingRecipes.Count; slot++)
        {
            var recipe = craftingRecipes[slot];
            var recipeObject = parent.GetChild(slot);
            
            UpdateUI(recipeObject.gameObject, recipe);
        }
    }

    void UpdateUI(GameObject recipeObject, CraftingRecipe recipe)
    {
        var itemCount = recipe.items.Count;

        var trasnform = recipeObject.transform;
            
        var sprite = trasnform.GetChild(0);
        var makeImage = sprite.GetComponent<Image>();
        makeImage.sprite = recipe.craftedItem.item.uiSprite;
            
        var name = trasnform.GetChild(1);
        var nameText = name.GetComponent<Text>();
        nameText.text = $"{recipe.craftedItem.item.itemName}";
            
            
        var desc = trasnform.GetChild(2);
        var descText = desc.GetComponent<Text>();
        descText.text = $"{recipe.craftedItem.item.itemDescription}";

        var resources = trasnform.GetChild(3);

        var items = resources.GetChild(1);

        for (int index = 0; index < 5; index++)
        {
            var item = items.GetChild(index);
            if (index >= itemCount)
                item.gameObject.SetActive(false);
            else
            {
                var itemSprite = item.GetChild(0);
                var itemText = item.GetChild(1);

                var image = itemSprite.GetComponent<Image>();
                var text = itemText.GetComponent<Text>();

                image.sprite = recipe.items[index].item.uiSprite;
                    
                var itemAmount = player.inventory.GetAmountFromItem(recipe.items[index].item.itemId);
                var itemAmountRequired = recipe.items[index].amount;
                var hasCorrectAmount = itemAmount >= itemAmountRequired;
                    
                text.text = $"{itemAmount}/{itemAmountRequired}";
                text.color = hasCorrectAmount ? Color.green : Color.red;
            }
        }
    }
}
