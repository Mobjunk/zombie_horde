using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomLevelGenerator : MonoBehaviour
{
    public enum MapSizes
    {
        Tiny = 50,
        Small = 100,
        Medium = 150,
        Large = 200,
        Giant = 400,
        Extreme = 1000,
        RipPC = 2000
    }

    public enum TileTypes
    {
        NotSet,
        Grass,
        Water,
        Sand
    }

    public enum Direction4
    {
        North,
        East,
        South,
        West
    }

    [System.Serializable]
    public struct SpawnResourceData
    {
        public string name;
        public Tile[] tileVariants;
        public float chance;
        public TileTypes[] placedOn;
    }

    [System.Serializable]
    public struct TileData
    {
        public Tile[] fulltileVariants;
        public Tile[] straighttileVariants;
        public Tile[] outerCornertileVariants;
        public Tile[] innerCornertileVariants;
    }

    [Header("Map Settings")]
    [SerializeField] private MapSizes mapSize;
    [SerializeField] private int maxLakeSize;
    [SerializeField] private int minLakeSize;
    [Space]
    [Header("Generation Settings")]
    [SerializeField] private int lakeFixDirectionTries = 10;
    [Space]
    [Header("References")]
    [SerializeField] private Tilemap backgroundTilemap;
    [SerializeField] private ResourceSystem resourceSystem;
    [SerializeField] private Tilemap fogTilemap;
    [SerializeField] private SetMapSizeScript setMapSizeScript;
    [Space]
    [Header("Tiles")]
    [SerializeField] private TileData grassTiles;
    [SerializeField] private TileData waterTiles;
    [SerializeField] private TileData sandTiles;
    [SerializeField] private Tile fogTile;
    [Space]
    [Header("Resource Tiles")]
    [SerializeField] private SpawnResourceData[] resourcesData;

    private TileTypes[,] mapTypes;

    // Start is called before the first frame update
    void Start()
    {
        if (setMapSizeScript)
        {
            mapSize = setMapSizeScript.SetMapSize(mapSize);
        }
        GenerateMap();
    }

    public void GenerateMap()
    {
        mapTypes = new TileTypes[(int)mapSize, (int)mapSize];

        for (int y = 0; y < (int)mapSize; y++)
        {
            for (int x = 0; x < (int)mapSize; x++)
            {
                mapTypes[y, x] = TileTypes.NotSet;
            }
        }

        GenerateLakes();
        GenerateSands();
        GenerateGrass();
        GenerateTiles();
        GenerateResources();
        GenerateFog();
    }

    private void GenerateLakes()
    {
        int numberOfLakes = Mathf.RoundToInt(Random.Range((((int)mapSize * (int)mapSize) / (maxLakeSize * 12f)), ((int)mapSize * (int)mapSize) / (maxLakeSize * 24f)));

        for (int lake = 0; lake < numberOfLakes; lake++)
        {
            int lakeSize = Random.Range(minLakeSize, maxLakeSize);
            Vector2Int lakeTilePosition = new Vector2Int(Random.Range(0, (int)mapSize), Random.Range(0, (int)mapSize));

            for (int i = 0; i < lakeSize; i++)
            {
                mapTypes[lakeTilePosition.y, lakeTilePosition.x] = TileTypes.Water;

                bool newPosFound = false;
                int tries = 0;
                while (!newPosFound && tries < lakeFixDirectionTries)
                {
                    tries++;
                    Direction4 direction = (Direction4)Random.Range(0, 4);
                    switch (direction)
                    {
                        case Direction4.North:
                            if (lakeTilePosition.y != (int)mapSize - 1)
                            {
                                if (mapTypes[lakeTilePosition.y + 1, lakeTilePosition.x] == TileTypes.NotSet)
                                {
                                    lakeTilePosition += new Vector2Int(0, 1);
                                    newPosFound = true;
                                }
                            }
                            break;
                        case Direction4.East:
                            if (lakeTilePosition.x != (int)mapSize - 1)
                            {
                                if (mapTypes[lakeTilePosition.y, lakeTilePosition.x + 1] == TileTypes.NotSet)
                                {
                                    lakeTilePosition += new Vector2Int(1, 0);
                                    newPosFound = true;
                                }
                            }
                            break;
                        case Direction4.South:
                            if (lakeTilePosition.y != 0)
                            {
                                if (mapTypes[lakeTilePosition.y - 1, lakeTilePosition.x] == TileTypes.NotSet)
                                {
                                    lakeTilePosition -= new Vector2Int(0, 1);
                                    newPosFound = true;
                                }
                            }
                            break;
                        case Direction4.West:
                            if (lakeTilePosition.x != 0)
                            {
                                if (mapTypes[lakeTilePosition.y, lakeTilePosition.x - 1] == TileTypes.NotSet)
                                {
                                    lakeTilePosition -= new Vector2Int(1, 0);
                                    newPosFound = true;
                                }
                            }
                            break;
                        default:
                            newPosFound = true;
                            break;
                    }
                }
            }
        }

        FixLakes();
    }

    private void FixLakes()
    {
        for (int y = 1; y < (int)mapSize - 1; y++)
        {
            for (int x = 1; x < (int)mapSize - 1; x++)
            {
                fixWaterTile(y, x);
            }
        }
    }

    private void fixWaterTile(int y, int x)
    {
        if (mapTypes[y + 1, x] == TileTypes.Water && mapTypes[y - 1, x] == TileTypes.Water)
        {
            mapTypes[y, x] = TileTypes.Water;
            return;
        }
        else if (mapTypes[y, x + 1] == TileTypes.Water && mapTypes[y, x - 1] == TileTypes.Water)
        {
            mapTypes[y, x] = TileTypes.Water;
            return;
        }
        if (y > 1 && y < (int)mapSize - 2)
        {
            if (mapTypes[y + 2, x] == TileTypes.Water && mapTypes[y - 1, x] == TileTypes.Water)
            {
                mapTypes[y, x] = TileTypes.Water;
                return;
            }
            else if (mapTypes[y + 1, x] == TileTypes.Water && mapTypes[y - 2, x] == TileTypes.Water)
            {
                mapTypes[y, x] = TileTypes.Water;
                return;
            }
        }
        if (x > 1 && x < (int)mapSize - 2)
        {
            if (mapTypes[y, x + 2] == TileTypes.Water && mapTypes[y, x - 1] == TileTypes.Water)
            {
                mapTypes[y, x] = TileTypes.Water;
                return;
            }
            else if (mapTypes[y, x + 1] == TileTypes.Water && mapTypes[y, x - 2] == TileTypes.Water)
            {
                mapTypes[y, x] = TileTypes.Water;
                return;
            }
        }
    }

    private void GenerateSands()
    {
        for (int y = 0; y < (int)mapSize; y++)
        {
            for (int x = 0; x < (int)mapSize; x++)
            {
                GenereateSand(y, x);
            }
        }
    }

    private void GenereateSand(int y, int x)
    {
        if (mapTypes[y, x] == TileTypes.NotSet)
        {
            if (y < (int)mapSize - 1)
            {
                if (mapTypes[y + 1, x] == TileTypes.Water)
                {
                    mapTypes[y, x] = TileTypes.Sand;
                }
            }
            if (x < (int)mapSize - 1)
            {
                if (mapTypes[y, x + 1] == TileTypes.Water)
                {
                    mapTypes[y, x] = TileTypes.Sand;
                }
            }
            if (y > 0)
            {
                if (mapTypes[y - 1, x] == TileTypes.Water)
                {
                    mapTypes[y, x] = TileTypes.Sand;
                }
            }
            if (x > 0)
            {
                if (mapTypes[y, x - 1] == TileTypes.Water)
                {
                    mapTypes[y, x] = TileTypes.Sand;
                }
            }
            if (y > 0 && x > 0)
            {
                if (mapTypes[y - 1, x - 1] == TileTypes.Water)
                {
                    mapTypes[y, x] = TileTypes.Sand;
                }
            }
            if (x < (int)mapSize - 1 && y < (int)mapSize - 1)
            {
                if (mapTypes[y + 1, x + 1] == TileTypes.Water)
                {
                    mapTypes[y, x] = TileTypes.Sand;
                }
            }
            if (x > 0 && y < (int)mapSize - 1)
            {
                if (mapTypes[y + 1, x - 1] == TileTypes.Water)
                {
                    mapTypes[y, x] = TileTypes.Sand;
                }
            }
            if (x < (int)mapSize - 1 && y > 0)
            {
                if (mapTypes[y - 1, x + 1] == TileTypes.Water)
                {
                    mapTypes[y, x] = TileTypes.Sand;
                }
            }
        }
    }

    private void GenerateGrass()
    {
        for (int y = 0; y < (int)mapSize; y++)
        {
            for (int x = 0; x < (int)mapSize; x++)
            {
                if (mapTypes[y, x] == TileTypes.NotSet)
                {
                    mapTypes[y, x] = TileTypes.Grass;
                }
            }
        }
    }

    private void GenerateTiles()
    {
        for (int y = 0; y < (int)mapSize; y++)
        {
            for (int x = 0; x < (int)mapSize; x++)
            {
                switch (mapTypes[y, x])
                {
                    case TileTypes.Grass:
                        GenerateTile(x, y, TileTypes.Grass, TileTypes.NotSet, TileTypes.NotSet, grassTiles);
                        break;
                    case TileTypes.Water:
                        GenerateTile(x, y, TileTypes.Water, TileTypes.NotSet, TileTypes.NotSet, waterTiles);
                        break;
                    case TileTypes.Sand:
                        GenerateTile(x, y, TileTypes.Sand, TileTypes.Water, TileTypes.Grass, sandTiles);
                        break;
                    case TileTypes.NotSet:
                        Debug.LogError("Error");
                        break;
                    default:
                        Debug.LogError("Error");
                        break;
                }
            }
        }
    }

    private void GenerateResources()
    {
        for (int y = 0; y < (int)mapSize; y++)
        {
            for (int x = 0; x < (int)mapSize; x++)
            {
                GenerateResource(y, x);
            }
        }
    }

    private void GenerateResource(int y, int x)
    {
        float change = Random.Range(0, 1000);
        float currentChange = 0;

        foreach (var resourceData in resourcesData)
        {
            bool canPlaceOnTile = false;
            foreach (var tile in resourceData.placedOn)
            {
                if (tile == mapTypes[y, x])
                {
                    canPlaceOnTile = true;
                    break;
                }
            }

            if (canPlaceOnTile)
            {
                if (change < resourceData.chance * 10 + currentChange)
                {
                    resourceSystem.SpawnResource(new Vector3(x - (int)mapSize / 2, y - (int)mapSize / 2, 0), resourceData.tileVariants[Random.Range(0, resourceData.tileVariants.Length)]);
                    return;
                }
                else
                {
                    currentChange += resourceData.chance * 10;
                }
            }
        }
    }

    private void GenerateFog()
    {
        for (int y = -15; y < (int)mapSize + 15; y++)
        {
            for (int x = -15; x < (int)mapSize + 15; x++)
            {
                if ((x < 0 || x >= (int)mapSize) || (y < 0 || y >= (int)mapSize))
                {
                    fogTilemap.SetTile(new Vector3Int(x - (int)mapSize / 2, y - (int)mapSize / 2, 0), fogTile);
                }
            }
        }
    }

    private void GenerateTile(int x, int y, TileTypes thisTileType, TileTypes checkinnerTileType, TileTypes checkOuterTileType, TileData tileData)
    {
        if (checkinnerTileType != TileTypes.NotSet && checkOuterTileType != TileTypes.NotSet)
        {
            if (y > 0 && y < (int)mapSize - 1 && x > 0 && x < (int)mapSize - 1)
            {
                if (
                mapTypes[y + 1, x] == checkOuterTileType &&
                mapTypes[y, x - 1] == checkOuterTileType &&
                mapTypes[y - 1, x + 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.outerCornertileVariants[Random.Range(0, tileData.outerCornertileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
                if (
                mapTypes[y - 1, x] == checkOuterTileType &&
                mapTypes[y, x + 1] == checkOuterTileType &&
                mapTypes[y + 1, x - 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.outerCornertileVariants[Random.Range(0, tileData.outerCornertileVariants.Length)], Quaternion.Euler(0, 0, 180));
                    return;
                }
                if (
                mapTypes[y - 1, x] == checkOuterTileType &&
                mapTypes[y, x - 1] == checkOuterTileType &&
                mapTypes[y + 1, x + 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.outerCornertileVariants[Random.Range(0, tileData.outerCornertileVariants.Length)], Quaternion.Euler(0, 0, 90));
                    return;
                }
                if (
                mapTypes[y + 1, x] == checkOuterTileType &&
                mapTypes[y, x + 1] == checkOuterTileType &&
                mapTypes[y - 1, x - 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.outerCornertileVariants[Random.Range(0, tileData.outerCornertileVariants.Length)], Quaternion.Euler(0, 0, -90));
                    return;
                }

                if (
                mapTypes[y + 1, x] == checkinnerTileType &&
                mapTypes[y, x - 1] == checkinnerTileType &&
                mapTypes[y - 1, x + 1] == checkOuterTileType
                )
                {
                    PlaceTile(x, y, tileData.innerCornertileVariants[Random.Range(0, tileData.innerCornertileVariants.Length)], Quaternion.Euler(0, 0, 180));
                    return;
                }
                if (
                mapTypes[y - 1, x] == checkinnerTileType &&
                mapTypes[y, x + 1] == checkinnerTileType &&
                mapTypes[y + 1, x - 1] == checkOuterTileType
                )
                {
                    PlaceTile(x, y, tileData.innerCornertileVariants[Random.Range(0, tileData.innerCornertileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
                if (
                mapTypes[y - 1, x] == checkinnerTileType &&
                mapTypes[y, x - 1] == checkinnerTileType &&
                mapTypes[y + 1, x + 1] == checkOuterTileType
                )
                {
                    PlaceTile(x, y, tileData.innerCornertileVariants[Random.Range(0, tileData.innerCornertileVariants.Length)], Quaternion.Euler(0, 0, -90));
                    return;
                }
                if (
                mapTypes[y + 1, x] == checkinnerTileType &&
                mapTypes[y, x + 1] == checkinnerTileType &&
                mapTypes[y - 1, x - 1] == checkOuterTileType
                )
                {
                    PlaceTile(x, y, tileData.innerCornertileVariants[Random.Range(0, tileData.innerCornertileVariants.Length)], Quaternion.Euler(0, 0, 90));
                    return;
                }

                if (
                mapTypes[y - 1, x] == checkOuterTileType &&
                mapTypes[y + 1, x] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 180));
                    return;
                }
                if (
                mapTypes[y + 1, x] == checkOuterTileType &&
                mapTypes[y - 1, x] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }

                if (
                mapTypes[y, x - 1] == checkOuterTileType &&
                mapTypes[y, x + 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 90));
                    return;
                }
                if (
                mapTypes[y, x + 1] == checkOuterTileType &&
                mapTypes[y, x - 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, -90));
                    return;
                }
                {
                    PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
            }
            if (y > 0 && y < (int)mapSize - 1)
            {
                if (
                mapTypes[y - 1, x] == checkOuterTileType &&
                mapTypes[y + 1, x] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 180));
                    return;
                }
                if (
                mapTypes[y + 1, x] == checkOuterTileType &&
                mapTypes[y - 1, x] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
                {
                    PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
            }
            if (x > 0 && x < (int)mapSize - 1)
            {
                if (
                mapTypes[y, x - 1] == checkOuterTileType &&
                mapTypes[y, x + 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 90));
                    return;
                }
                if (
                mapTypes[y, x + 1] == checkOuterTileType &&
                mapTypes[y, x - 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, -90));
                    return;
                }
                {
                    PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
            }

            if (y > 0)
            {
                if (
                mapTypes[y - 1, x] == checkOuterTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 180));
                    return;
                }
                if (
                mapTypes[y - 1, x] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
                {
                    PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
            }
            if (x > 0)
            {
                if (
                mapTypes[y, x - 1] == checkOuterTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 90));
                    return;
                }
                if (
                mapTypes[y, x - 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, -90));
                    return;
                }
                {
                    PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
            }
            if (y < (int)mapSize - 1)
            {
                if (
                mapTypes[y + 1, x] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 180));
                    return;
                }
                if (
                mapTypes[y + 1, x] == checkOuterTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
                {
                    PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
            }
            if (x < (int)mapSize - 1)
            {
                if (
                mapTypes[y, x + 1] == checkinnerTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, 90));
                    return;
                }
                if (
                mapTypes[y, x + 1] == checkOuterTileType
                )
                {
                    PlaceTile(x, y, tileData.straighttileVariants[Random.Range(0, tileData.straighttileVariants.Length)], Quaternion.Euler(0, 0, -90));
                    return;
                }
                {
                    PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
                    return;
                }
            }
            else
            {
                PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
                return;
            }
        }
        else
        {
            PlaceTile(x, y, tileData.fulltileVariants[Random.Range(0, tileData.fulltileVariants.Length)], Quaternion.Euler(0, 0, 0));
            return;
        }
    }

    private void PlaceTile(int x, int y, Tile tile, Quaternion rotation)
    {
        tile.transform = Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one);
        backgroundTilemap.SetTile(new Vector3Int(x - (int)mapSize / 2, y - (int)mapSize / 2, 0), tile);
    }
}