using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab; // Reference to the tile prefab
    public int width = 100;
    public int height = 100;
    public float tileSpacing = 1.1f; // Slight spacing between tiles

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Instantiate a new tile at the correct position
                GameObject newTile = Instantiate(tilePrefab, new Vector3(x * tileSpacing, y * tileSpacing, 0), Quaternion.identity);
                
                // Randomly set the color (for now, this is just for illustration)
                Color tileColor = GetRandomColor();
                newTile.GetComponent<SpriteRenderer>().color = tileColor;

                // Make the tile a child of the GridManager for better organization in the Hierarchy
                newTile.transform.parent = transform;
            }
        }
    }

    Color GetRandomColor()
    {
        // Randomly assign one of three states: black, green, or red
        int state = Random.Range(0, 3); // Random number between 0 and 2
        switch (state)
        {
            case 0:
                return Color.black;
            case 1:
                return Color.green;
            case 2:
                return Color.red;
            default:
                return Color.white; // Fallback
        }
    }
}

