using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    GridHandler gridHandler;
    SpriteRenderer spriteRenderer;
    public bool white; //the white player is black, because he belongs to the white side
    string left, right, up, down;
    Vector2i coordinate;
    Tile oldTile, curTile;
    public Sprite sprLeft, sprRight, sprDown, sprUp;
    public AudioClip walk;

    void Awake() {
        gridHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (white) {
            left = "p1 left";
            right = "p1 right";
            up = "p1 up";
            down = "p1 down";
        } else {
            left = "p2 left";
            right = "p2 right";
            up = "p2 up";
            down = "p2 down";
        }

        coordinate = Vector2i.toCoord(transform.position);
        curTile = gridHandler.getTile(coordinate);
    }

	void Start () {
    }
	
	void Update () {
        if (Input.GetButtonDown(left)) {
            move(-1,0, sprLeft);
        }
        if (Input.GetButtonDown(right)) {
            move(1, 0, sprRight);
        }
        if (Input.GetButtonDown(up)) {
            move(0, 1, sprUp);
        }
        if (Input.GetButtonDown(down)) {
            move(0, -1, sprDown);
        }
	}

    void move(int x, int y, Sprite newSprite) {
        Tile newTile = gridHandler.getTile(coordinate.x + x, coordinate.y + y);
        if (newTile != null) {
            if ((newTile.getType() == Tile.Types.WHITE && !white) || (newTile.getType() == Tile.Types.BLACK && white)) {
                //CHAOS CODE!
               /* Ray2D ray = new Ray2D(transform.position, new Vector2(x, y));
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 16, 1<<8);

                bool move = false;

                if (hit) {
                    Tile newTile2 = gridHandler.getTile(coordinate.x + x * 2, coordinate.y + y * 2);
                    if (newTile2 != null && newTile2.getType() != Tile.Types.WALL) {

                        Ray2D ray2 = new Ray2D(hit.transform.position, new Vector2(x, y));
                        RaycastHit2D hit2 = Physics2D.Raycast(ray2.origin, ray2.direction, 16, 1 << 4);
                        if (!hit2) {
                            hit.transform.position = newTile2.transform.position;
                            move = true;
                        }
                    }
                } else {
                    move = true;

                }*/

                if (true) {
                    coordinate.x += x;
                    coordinate.y += y;
                    transform.Translate(GridHandler.tileSize * x, GridHandler.tileSize * y, 0);
                    spriteRenderer.sprite = newSprite;

                    curTile.toggle();
                    curTile = newTile;
                    audio.PlayOneShot(walk);
                }                
            }
        }
    }
}
