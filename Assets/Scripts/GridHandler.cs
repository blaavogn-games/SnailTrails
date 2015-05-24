using UnityEngine;
using System.Collections;

[System.Serializable]
public class GridHandler : MonoBehaviour {
    public const int gridX = 10, gridY = 7, tileSize = 16;
    [SerializeField]
    GameObject[] grid = new GameObject[gridX * gridY];

    // Use this for initialization
    void Start() {

    }

    public void clearGrid() {
        for (int i = 0; i < grid.Length; i++) {
            if (grid[i] != null) {
                Object.DestroyImmediate(grid[i]);
            }
        }

        grid = new GameObject[gridX * gridY];

        for (int x = 0; x < gridX; x++) {
            for (int y = 0; y < gridY; y++) {
                GameObject tempGO = (GameObject) Instantiate(Resources.Load("grid/Tile"), new Vector3(x * tileSize, y * tileSize, 0), Quaternion.identity);
                tempGO.transform.name = x + "," + y;
                tempGO.transform.parent = transform;
                Tile tile = tempGO.GetComponent<Tile>();
                tile.setCoordinate(new Vector2i(x, y));

                Tile.Types type = (x > 4) ? Tile.Types.WHITE : Tile.Types.BLACK;
                tile.setType(type);

                grid[x + y * gridX] = tempGO;
            }
        }
    }

    public Tile getTile(int x, int y) {
        if (x >= 0 && x < gridX && y >= 0 && y < gridY) {
            return grid[x + y * gridX].GetComponent<Tile>();
        }
        return null;
    }
    public Tile getTile(Vector2i coordinate) {
        return getTile(coordinate.x, coordinate.y);
    }
}
