using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{

    [SerializeField] private List<CraftingRecipe> craftingRecipes = new List<CraftingRecipe>();
    [SerializeField] private GameObject recipePrefab, recipeParent;

    private void Start()
    {
        foreach (var recipe in craftingRecipes)
        {
            var gameObject = Instantiate(recipePrefab);
            gameObject.transform.SetParent(recipeParent.transform);
            gameObject.transform.localScale = new Vector3(1,1,1);
            
            
        }
    }
}
