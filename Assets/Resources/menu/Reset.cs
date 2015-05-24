using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Input.mousePosition;
            Debug.Log(mousePos);
            if (mousePos.x > 338 && mousePos.x < 462 && mousePos.y < 85) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
}
