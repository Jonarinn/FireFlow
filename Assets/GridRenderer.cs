using UnityEngine;
using UnityEngine.Tilemaps;

public class GridRenderer : MonoBehaviour
{

    public GameController gameController;

    public Tile sprites_Healthy;   // Reference to the green tile named "sprites_0
    public Tile sprites_Burning;
    public Tile sprites_Dead;

    [SerializeField] private Tilemap tilemap;


    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        if (tilemap == null) throw new System.Exception("Could not find Tilemap component on this gameobject");
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
                TileModel tile = tiles[x, y];
                if (tile == null) throw new System.Exception("tile is null");
                tilemap.SetTile(new(x, y), ChooseTileForState(tile.getState()));  // Set the tile at this position to the green tile
            }
        }
    }

    Tile ChooseTileForState(TileState state)
    {
        switch (state)
        {
            case TileState.Healthy: return sprites_Healthy;
            case TileState.Burning: return sprites_Burning;
            case TileState.Dead: return sprites_Dead;
            default: return null;
        }
    }
}
