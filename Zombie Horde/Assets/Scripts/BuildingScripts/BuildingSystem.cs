using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public class Building
    {
        public Building(Vector3 Position, float StructureHealth)
        {
            position = Position;
            structureHealth = StructureHealth;
        }

        public Vector3 position;
        public float structureHealth;
    }

    [HideInInspector] public List<Building> placedBuildings = new List<Building>();

    [SerializeField] private Tilemap structuresTilemap;
    [SerializeField] private Tilemap shadowTilemap;
    [SerializeField] private Tilemap resourcesTilemap;
    public BuildingObject tempStructure;

    public void PlaceStrucure(Vector3 position, BuildingObject buildingObject)
    {
        if (resourcesTilemap.GetTile(resourcesTilemap.WorldToCell(position)) == null)
        {
            Vector3Int gridPosition = structuresTilemap.WorldToCell(position);
            if (structuresTilemap.GetTile(gridPosition) == null)
            {
                structuresTilemap.SetTile(gridPosition, buildingObject.tile);
                shadowTilemap.SetTile(shadowTilemap.WorldToCell(position + shadowTilemap.transform.position), buildingObject.tile);
                placedBuildings.Add(new Building(gridPosition, buildingObject.structureHealth));
            }
        }
    }

    public void DestroyStructure(Vector3 position, float damage)
    {
        Vector3Int gridPosition = structuresTilemap.WorldToCell(position);
        for (int i = 0; i < placedBuildings.Count; i++)
        {
            if (placedBuildings[i].position == gridPosition)
            {
                placedBuildings[i].structureHealth -= damage;
                if (placedBuildings[i].structureHealth <= 0)
                {
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlaceStrucure(Camera.main.ScreenToWorldPoint(Input.mousePosition), tempStructure);
        }
    }
}
