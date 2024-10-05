using UnityEngine;
using UnityEngine.Tilemaps;

public class GridCreator : MonoBehaviour
{
    public Tilemap tilemap;  // Reference to the Tilemap
    public Tile sprites_0;   // Reference to the green tile named "sprites_0"

    void Start()
    {
        CreateGrid();
    }

    // Function to create a 100x100 grid with the green tile
    void CreateGrid()
    {
        for (int x = 0; x < 100; x++)  // Loop through each X position
        {
            for (int y = 0; y < 100; y++)  // Loop through each Y position
            {
                Vector3Int position = new Vector3Int(x, y, 0);  // Position for each tile
                tilemap.SetTile(position, sprites_0);  // Set the tile at this position to the green tile
            }
        }
    }
}
