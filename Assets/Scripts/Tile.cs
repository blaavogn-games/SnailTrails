using UnityEngine;
using System.Collections;

[System.Serializable]
public class Tile : MonoBehaviour {
    public enum Types { WHITE, BLACK, WALL };
    public Material white, black, grey;
    int spriteNumber;

    [SerializeField]
    public Vector2i coordinate;
    [SerializeField]
    private Types type;

    public void setCoordinate(Vector2i coordinate) {
        spriteNumber = (int) (Random.value * 3);
        Debug.Log(spriteNumber);
     
        this.coordinate = coordinate;
    }

    public void setColor(Color c) {
        GetComponent<SpriteRenderer>().color = c;
    }

    public void setType(Types type) {
        this.type = type;
        switch (type) {
            case Types.BLACK:
                renderer.material = black;
                break;
            case Types.WHITE:
                renderer.material = white;
                break;
            case Types.WALL:
                renderer.material = grey;
                break;
        }
    }

    public void toggle() {
        if (type == Types.BLACK) {
            setType(Types.WHITE);
        } else {
            setType(Types.BLACK);
        }
    }

    public Types getType() {
        return type;
    }

	
}
