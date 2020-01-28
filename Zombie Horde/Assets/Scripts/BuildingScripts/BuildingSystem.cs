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
            if (structuresTilemap.GetTile(structuresTilemap.WorldToCell(position)) == null)
            {
                structuresTilemap.SetTile(structuresTilemap.WorldToCell(position), buildingObject.tile);
                shadowTilemap.SetTile(shadowTilemap.WorldToCell(position + shadowTilemap.transform.position), buildingObject.tile);
            }
        }
    }

    public void DestroyStructure(Vector3 position)
    {
        Debug.LogError(position);
        structuresTilemap.SetTile(structuresTilemap.WorldToCell(position), null);
        shadowTilemap.SetTile(shadowTilemap.WorldToCell(position + shadowTilemap.transform.position), null);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlaceStrucure(Camera.main.ScreenToWorldPoint(Input.mousePosition), tempStructure);
        }
    }
}
