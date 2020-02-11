using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField, Range(1, 5)] float gatherRange = 2f;

    InputManager inputManager => InputManager.instance;
    private Player player;
    private Transform playerTrans;

    public class Building
    {
        public Building(Vector3 Position, float StructureHealth, GameObject ParticleEffect)
        {
            position = Position;
            structureHealth = StructureHealth;
            particleEffect = ParticleEffect;
        }

        public Vector3 position;
        public float structureHealth;
        public GameObject particleEffect;
    }

    [HideInInspector] public List<Building> placedBuildings = new List<Building>();

    [SerializeField] private Tilemap structuresTilemap;
    [SerializeField] private Tilemap shadowTilemap;
    [SerializeField] private Tilemap resourcesHighTilemap;
    [SerializeField] private Tilemap resourcesMediumTilemap;
    [SerializeField] private Tilemap resourcesLowTilemap;
    [SerializeField] private Tilemap backgroundTilemap;
    [Space]
    [SerializeField] private LayerMask layerMask;
    public List<BuildingObject> structures = new List<BuildingObject>();

    private void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
        playerTrans = GameManager.playerObject.transform;
    }

    public void PlaceStrucure(BuildingObject buildingObject)
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var distance = Vector2.Distance(playerTrans.position, position);

        if (distance > gatherRange || distance < 0.7f) return;

        foreach (var tileToBuildOn in buildingObject.tilesToBuildOn)
        {
            if (backgroundTilemap.GetTile(backgroundTilemap.WorldToCell(position)).name == tileToBuildOn.name)
            {
                // Checks if the tile doesn't have a resource on the resource tile map
                if (resourcesHighTilemap.GetTile(resourcesHighTilemap.WorldToCell(position)) == null && resourcesMediumTilemap.GetTile(resourcesMediumTilemap.WorldToCell(position)) == null && resourcesLowTilemap.GetTile(resourcesLowTilemap.WorldToCell(position)) == null)
                {
                    Vector3Int gridPosition = structuresTilemap.WorldToCell(position);
                    // Checks if there isn't already a structure on the tile.
                    if (structuresTilemap.GetTile(gridPosition) == null)
                    {
                        //Remove all the items from the player his inventory
                        player.inventory.Remove(buildingObject.item.item.itemId, buildingObject.item.amount);

                        // Changes the tiles in the tilemaps
                        structuresTilemap.SetTile(gridPosition, buildingObject.tile);
                        shadowTilemap.SetTile(shadowTilemap.WorldToCell(position + shadowTilemap.transform.position), buildingObject.tile);
                        // Adds the structure to a list of placedstructures to keep track of hp
                        placedBuildings.Add(new Building(gridPosition, buildingObject.structureHealth, buildingObject.particleEffect));
                    }
                }
                return;
            }
        }
    }

    public void DestroyStructure(Vector3 position, float damage)
    {
        Vector3Int gridPosition = structuresTilemap.WorldToCell(position);
        // Loops through all placed structures to find the tile on the grid position
        for (int i = 0; i < placedBuildings.Count; i++)
        {
            if (placedBuildings[i].position == gridPosition)
            {
                placedBuildings[i].structureHealth -= damage;
                Instantiate(placedBuildings[i].particleEffect, placedBuildings[i].position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                if (placedBuildings[i].structureHealth <= 0)
                {
                    // removes the tile when the structure has 0 hp.
                    structuresTilemap.SetTile(gridPosition, null);
                    shadowTilemap.SetTile(shadowTilemap.WorldToCell(position + shadowTilemap.transform.position), null);
                    placedBuildings.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private void Update()
    {
        if (inputManager.placeStructure)
        {
            var building = GetBuilding();
            if (building == null) return;

            PlaceStrucure(building);
        }
        if (inputManager.pressedAttack)
        {
            RaycastHit2D hit = Physics2D.Raycast(playerTrans.position, Vector2FromAngle(playerTrans.eulerAngles.z + 90), gatherRange, layerMask);
            if (hit.collider)
            {
                Vector3 position = hit.point + Vector2FromAngle(playerTrans.eulerAngles.z + 90) * new Vector2(0.1f, 0.1f);
                DestroyStructure(position, 1000);
            }
        }
    }

    private BuildingObject GetBuilding()
    {
        foreach (var structure in structures)
        {
            var itemData = player.inventory.items[player.inventorySlot];
            if (itemData == null || itemData.item == null) return null;
            var itemId = itemData.item.itemId;
            if (structure.item.item.itemId == itemId && player.inventory.Contains(itemId, structure.item.amount))
            {
                return structure;
            }
        }
        return null;
    }

    private Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}
