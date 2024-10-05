using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameModel model;

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

    public void OnTileClicked(Vector2Int tilePos) { model.OnTileClicked(tilePos); }

}
