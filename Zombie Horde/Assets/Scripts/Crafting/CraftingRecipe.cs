using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New crafting recipe", menuName = "Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public Item craftedItem;
    public List<ItemData> items = new List<ItemData>();
}
