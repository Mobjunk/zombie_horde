using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourceSystem : MonoBehaviour
{
    public class Resource
    {
        public Resource(ResourceObject resourceObject, Vector3 Position)
        {
            durability = resourceObject.durability;
            this.resourceObject = resourceObject;
            position = Position;
        }

        public int durability;
        public ResourceObject resourceObject;
        public Vector3 position;
    }

    [System.Serializable]
    public class ItemGiven
    {
        public Item item;
        public int amount;
    }

    [Header("Tilemaps")]
    [SerializeField] private Tilemap resourceTilemap;
    [SerializeField] private Tilemap shadowTilemap;
    [SerializeField] private Tilemap structuresTilemap;
    [Space]
    [Header("Posible Resources")]
    [SerializeField] private ResourceObject[] resourceObjects;

    private List<Resource> resources = new List<Resource>();
    private Player player;

    public Tile test;

    private void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
    }

    public void SpawnResource(Vector3 position, Tile tile)
    {
        Vector3Int gridPosition = resourceTilemap.WorldToCell(position);
        if (resourceTilemap.GetTile(gridPosition) == null && structuresTilemap.GetTile(gridPosition) == null)
        {
            foreach (var resourceObject in resourceObjects)
            {
                foreach (var resourceTile in resourceObject.tiles)
                {
                    if (resourceTile == tile)
                    {
                        resourceTilemap.SetTile(gridPosition, tile);
                        shadowTilemap.SetTile(resourceTilemap.WorldToCell(position + resourceTilemap.transform.position), tile);
                        resources.Add(new Resource(resourceObject, gridPosition));
                        return;
                    }
                }
            }
            Debug.LogError("Tile isn't a resource");
        }
    }

    public void DestroyResource(Vector3 position, int damage)
    {
        Vector3Int gridPosition = resourceTilemap.WorldToCell(position);
        if (resourceTilemap.GetTile(gridPosition) != null)
        {
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i].position == gridPosition)
                {
                    if (resources[i].durability - damage <= 0)
                    {
                        damage += resources[i].durability - damage;
                    }

                    resources[i].durability -= damage;

                    foreach (var item in resources[i].resourceObject.itemsGivenPerHit)
                    {
                        player.inventory.Add(item.item.itemId, item.amount * damage);
                    }

                    if (resources[i].durability <= 0)
                    {
                        resourceTilemap.SetTile(gridPosition, null);
                        shadowTilemap.SetTile(resourceTilemap.WorldToCell(position + resourceTilemap.transform.position), null);
                        resources.RemoveAt(i);
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnResource(Camera.main.ScreenToWorldPoint(Input.mousePosition), test);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            DestroyResource(Camera.main.ScreenToWorldPoint(Input.mousePosition), 2);
        }
    }
}
