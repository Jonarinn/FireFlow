using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameModel model;
    public FireManager fireManager;

    // Start is called before the first frame update
    void Start()
    {
        model = GetComponent<GameModel>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public TileModel[,] GetAllTiles() { return model.GetTiles(); }

    public void OnTileClicked(Vector2Int tilePos) { SpreadFireTo(tilePos); }

    public void SpreadFireTo(Vector2Int position)
    {
        var tileToBurn = model.GetTileAtPosition(position);
        if (tileToBurn != null) fireManager.SetBurning(tileToBurn, true);
    }

}
