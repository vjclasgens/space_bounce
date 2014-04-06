using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// Exit game if user wants to escape
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

		// Load the game
		if(Input.GetMouseButton(0)) {
			Application.LoadLevel("MainGame");
		}
	}
}
