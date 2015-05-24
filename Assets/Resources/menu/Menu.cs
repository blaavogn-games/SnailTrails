using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject GO = GameObject.Find("MusicPlayer");

        if (GO == null) {
            GO = (GameObject)Instantiate(Resources.Load("env/MusicPlayer"));
            GO.transform.name = "MusicPlayer";
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) {
            Application.LoadLevel(1);
        }

	}
}
