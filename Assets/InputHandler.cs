using UnityEngine;
using UnityEngine.Tilemaps;

public class InputHandler : MonoBehaviour
{
    public GameController controller;
    public Tilemap tilemap;
    public float considerClickDelta = 5f;

    // Update is called once per frame
    void Update()
    {
        CheckTileClicked().Let(tile => controller.OnTileClicked(tile));
    }

    Vector3? clickStartPos = null;
    Vector2Int? CheckTileClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickStartPos = Input.mousePosition;
            return null;
        }

        if (clickStartPos != null && Input.GetMouseButtonUp(0))
        {
            var clickDragDelta = Vector3.Distance((Vector3)clickStartPos, Input.mousePosition);
            clickStartPos = null;
            if (clickDragDelta > considerClickDelta) return null;

            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos3 = tilemap.WorldToCell(worldPos);
            Vector2Int gridPos = new(gridPos3.x, gridPos3.y);
            return gridPos;
        }

        return null;
    }
}
