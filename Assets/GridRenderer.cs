using System.Threading;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridRenderer : MonoBehaviour
{

    public GameController gameController;

    public Tile sprites_Healthy;   // Reference to the green tile named "sprites_0
    public Tile sprites_Burning;
    public Tile sprites_Dead;
    public Tile sprites_Jungle;
    public Tile sprites_House;
    public Vector2Int gridSize = new(40, 40);

    public static Vector3Int housePosition;


    [SerializeField] private Tilemap tilemap;

    public static TreeGamemode treeGamemode = TreeGamemode.Normal;


    void Start()
    {
        housePosition = new(Random.Range(0, gridSize[0]), Random.Range(0, gridSize[1]));
        tilemap = GetComponent<Tilemap>();
        if (tilemap == null) throw new System.Exception("Could not find Tilemap component on this gameobject");
        RenderHouse(housePosition.x, housePosition.y);
    }

    private void Update()
    {
        var tiles = gameController.GetAllTiles();
        RenderGrip(tiles);
    }

    // Function to create a 100x100 grid with the green tile
    void RenderGrip(TileModel[,] tiles)
    {
        for (int x = 0; x < tiles.GetLength(0); x++)  // Loop through each X position
        {
            for (int y = 0; y < tiles.GetLength(1); y++)  // Loop through each Y position
            {
                if (x == housePosition.x && y == housePosition.y) continue;
                TileModel tile = tiles[x, y];

                tile.tileType = (TileType)treeGamemode;

                switch (tile.tileType)
                {
                    case TileType.Normal:
                        {
                            tile.burnTime = 4;
                            tile.recoveryTime = 7;
                            tile.spreadChancePerSecond = 0.3f;
                            break;
                        }
                    case TileType.Jungle:
                        tile.burnTime = 7;
                        tile.recoveryTime = 12;
                        tile.spreadChancePerSecond = 0.2f;
                        break;
                }
                if (tile == null) throw new System.Exception("tile is null");
                tilemap.SetTile(new(x, y), ChooseTileForState(tile));  // Set the tile at this position to the green tile
            }
        }
    }

    public static void ChangeGamemode(TreeGamemode newGamemode)
    {
        treeGamemode = newGamemode;
    }


    private void RenderHouse(int x, int y)
    {

        TileModel house = new TileModel();
        house.tileType = TileType.House;
        tilemap.SetTile(new(x, y), ChooseTileForState(house));
    }

    Tile ChooseTileForState(TileModel tile)
    {
        switch (tile.getState())
        {
            case TileState.Healthy:
                {
                    if (tile.tileType == TileType.Normal) return sprites_Healthy;
                    else if (tile.tileType == TileType.Jungle) return sprites_Jungle;
                    else if (tile.tileType == TileType.House) return sprites_House;
                    else return null;
                }
            case TileState.Burning: return sprites_Burning;
            case TileState.Dead: return sprites_Dead;
            default: return null;
        }
    }
}

public enum TreeGamemode
{
    Normal,
    Jungle,
}
