using UnityEngine;

[CreateAssetMenu]
public class TileModel : ScriptableObject
{
    [HideInInspector] public Vector2Int position;

    public TreeType treeType = TreeType.Normal;
    public bool _generallyBurnable;
    public float burnTime;
    public float recoveryTime;

    [SerializeField] private TileState state = TileState.Healthy;
    public TileState getState() { return this.state; }
    public void SetState(TileState newState) { this.state = newState; }


    public void MoveToNextState()
    {
        if (state == TileState.Healthy) SetState(TileState.Burning);
        else if (state == TileState.Burning) SetState(TileState.Dead);
        else if (state == TileState.Dead) SetState(TileState.Healthy);
    }


    [Range(0, 1)][InspectorName("Spread Chance/s")] public float spreadChancePerSecond;

    public bool ShouldSpread(float timeDelta)
    {
        return (spreadChancePerSecond * timeDelta) > Random.Range(0f, 1f);
    }

    public bool IsBurnable()
    {
        return _generallyBurnable && state != TileState.Dead;
    }

    public void changeTreeType(TreeType newTreeType)
    {
        treeType = newTreeType;
        switch (newTreeType)
        {
            case TreeType.Normal:
                burnTime = 1;
                recoveryTime = 1;
                spreadChancePerSecond = 0.4f;
                break;
            case TreeType.Jungle:
                burnTime = 5;
                recoveryTime = 5;
                spreadChancePerSecond = 0.3f;
                break;
        }

    }

}

public enum TileState
{
    Healthy,
    Burning,
    Dead,
}

public enum TreeType
{
    Normal,
    Jungle
}