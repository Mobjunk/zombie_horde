using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{

    [SerializeField] private List<CraftingRecipe> craftingRecipes = new List<CraftingRecipe>();
    [SerializeField] private GameObject recipePrefab, recipeParent;
    private Player player;
    
    private void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
        
        foreach (var recipe in craftingRecipes)
        {
            var gameObject = Instantiate(recipePrefab);
            gameObject.transform.SetParent(recipeParent.transform);
            gameObject.transform.localScale = new Vector3(1,1,1);
            
            var itemCount = recipe.items.Count;
            Debug.Log($"itemCount: {itemCount}");

            var trasnform = gameObject.transform;
            
            var sprite = trasnform.GetChild(0);
            var makeImage = sprite.GetComponent<Image>();
            makeImage.sprite = recipe.craftedItem.uiSprite;
            
            var name = trasnform.GetChild(1);
            var nameText = name.GetComponent<Text>();
            nameText.text = $"{recipe.craftedItem.itemName}";
            
            
            var desc = trasnform.GetChild(2);
            var descText = desc.GetComponent<Text>();
            descText.text = $"{recipe.craftedItem.itemDescription}";

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
}
