using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Resource", menuName = "Resource")]
public class ResourceObject : ScriptableObject
{
    public Tile[] tiles;
    public ResourceSystem.ItemGiven[] itemsGivenPerHit;
    public int durability = 0;
}
