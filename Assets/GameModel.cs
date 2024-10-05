using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{

    public Vector2Int size;

    [SerializeField] private TileModel[,] tiles;
    public TileModel[,] GetTiles() { return tiles; }


    private void OnEnable()
    {
        tiles = Utils.Create2DArray(size.x, size.y, () => ScriptableObject.CreateInstance<TileModel>());
    }

    public TileModel? GetTileAtPosition(Vector2Int position)
    {
        if (position.x < 0 || position.x >= tiles.GetLength(0)) return null;
        if (position.y < 0 || position.y >= tiles.GetLength(1)) return null;
        return tiles[position.x, position.y];
    }

    public void OnTileClicked(Vector2Int position)
    {
        var tile = GetTileAtPosition(position);
        if (tile == null) return;
        tile.MoveToNextState();
    }
}
