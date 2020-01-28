using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourceSystem : MonoBehaviour
{
    public class Resource
    {
        ResourceObject resource;
    }

    [System.Serializable]
    public class ItemGiven
    {
        public Item items;
        public int amount;
    }

    [SerializeField] private Tilemap resourceTilemap;
    [SerializeField] private Tilemap shadowTilemap;

    public void SpawnResource(Vector3 position, ResourceObject resource)
    {

    }
}
