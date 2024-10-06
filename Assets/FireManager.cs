using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using TileQueue = System.Collections.Generic.SortedDictionary<float, System.Collections.Generic.List<TileModel>>;

public class FireManager : MonoBehaviour
{
    public GameController controller;

    [SerializeField] List<TileModel> burningTiles = new();
    [SerializeField] TileQueue deathQueue = new();
    [SerializeField] TileQueue recoveryQueue = new();


    public void SetBurning(TileModel tile, bool burning)
    {
        if (burning) TileIsBurning(tile);
        else if (burningTiles.Contains(tile)) burningTiles.Remove(tile);
    }

    private void TileIsBurning(TileModel tile)
    {
        if (!tile.IsBurnable()) return;
        if (burningTiles.Contains(tile)) return;
        burningTiles.Add(tile);
        AddToQueue(deathQueue, tile, Time.time + tile.burnTime);
        tile.SetState(TileState.Burning);
    }

    private void TileDied(TileModel tile)
    {
        tile.SetState(TileState.Dead);
        SetBurning(tile, false);
        AddToQueue(recoveryQueue, tile, Time.time + tile.recoveryTime);
    }

    private void TileRecovered(TileModel tile)
    {
        tile.SetState(TileState.Healthy);
        SetBurning(tile, false);
    }


    void Update()
    {
        UpdateBurningTiles();
        UpdateDeadTiles();
    }

    void UpdateBurningTiles()
    {
        ProcessQueue(deathQueue, TileDied);
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

    void UpdateDeadTiles()
    {
        ProcessQueue(recoveryQueue, TileRecovered);
    }

    void ProcessQueue(TileQueue queue, Action<TileModel> onActionDue)
    {
        var affectedTiles = PopUntil(queue, Time.time);
        affectedTiles.ForEach(onActionDue);
    }


    static void AddToQueue(TileQueue queue, TileModel tile, float atTime)
    {
        atTime = Mathf.Round(atTime * 10) / 10;
        if (!queue.ContainsKey(atTime)) queue[atTime] = new List<TileModel>();
        queue[atTime].Add(tile);
    }

    static List<TileModel> PopUntil(TileQueue queue, float timestamp)
    {
        List<TileModel> poppedValues = new();

        while (queue.Count > 0 && queue.Keys.First() <= timestamp)
        {
            poppedValues.AddRange(queue.First().Value);
            queue.Remove(queue.First().Key);
        }

        return poppedValues;
    }
}
