using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GoalHandler goalHandler;
    public bool white;
    public Sprite solid, notSolid;

    void Awake() {
        goalHandler = transform.parent.GetComponent<GoalHandler>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            if (col.transform.gameObject.GetComponent<Player>().white == white) {
                goalHandler.inGoal(white);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            goalHandler.notInGoal(white);
        }
    }

    public void setSolid(bool isSolid) {
        if (isSolid) {
            GetComponent<SpriteRenderer>().sprite = solid;
        } else {
            GetComponent<SpriteRenderer>().sprite = notSolid;
        }
    }
}
