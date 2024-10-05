using UnityEngine;
using UnityEngine.Tilemaps;

public class InputHandler : MonoBehaviour
{
    public GameController controller;
    public Tilemap tilemap;

    // Update is called once per frame
    void Update()
    {
        CheckTileClicked().Let(tile => controller.OnTileClicked(tile));
    }

    Vector2Int? CheckTileClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos3 = tilemap.WorldToCell(worldPos);
            Vector2Int gridPos = new(gridPos3.x, gridPos3.y);
            return gridPos;
        }
        return null;
    }
}
