using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour {

    GoalHandler goalHandler;
    public bool white;

	void Awake () {
        goalHandler = GameObject.FindGameObjectWithTag("GoalHandler").GetComponent<GoalHandler>();
        goalHandler.addFlower(white);
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            if (col.GetComponent<Player>().white == white) {
                goalHandler.removeFlower(white);
                Destroy(this.gameObject);
            }
        }
    }
	
}
