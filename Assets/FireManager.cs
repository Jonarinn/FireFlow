using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public GameController controller;

    [SerializeField] List<TileModel> burningTiles;

    public void SetBurning(TileModel tile, bool burning)
    {
        if (burning) SetIsBurning(tile);
        else burningTiles.Remove(tile);
    }

    private void SetIsBurning(TileModel tile)
    {
        if (burningTiles.Contains(tile)) return;
        burningTiles.Add(tile);
        tile.SetState(TileState.Burning);
    }


    void Update()
    {
        foreach (TileModel tile in burningTiles.ToArray())
        {
            SpreadFireToDelta(tile, new(0, 1));
            SpreadFireToDelta(tile, new(0, -1));
            SpreadFireToDelta(tile, new(1, 0));
            SpreadFireToDelta(tile, new(-1, 0));
        };
    }

    void SpreadFireToDelta(TileModel tile, Vector2Int delta)
    {
        if (tile.ShouldSpread(Time.deltaTime))
        {
            controller.SpreadFireTo(tile.position + delta);
        }
    }
}
