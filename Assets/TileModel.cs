using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel : ScriptableObject
{

    [SerializeField] private TileState state = TileState.Healthy;

    public TileState getState() { return this.state; }
    public void SetState(TileState newState) { this.state = newState; }

    public void MoveToNextState()
    {
        if (state == TileState.Healthy) SetState(TileState.Burning);
        else if (state == TileState.Burning) SetState(TileState.Dead);
        else if (state == TileState.Dead) SetState(TileState.Healthy);
    }


}


public enum TileState
{
    Healthy,
    Burning,
    Dead
}