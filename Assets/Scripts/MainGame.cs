using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
	// The number of obstacles to generate
	private static int OBSTACLE_NUMBER = 100;
	public GameObject obstacle;
	// Use this for initialization
	void Start () {
		GenerateObstacles();
	}
	
	// Update is called once per frame
	void Update () {
		// Exit game if user wants to escape
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}

	// Generate obstacles randomly throughout the map
	void GenerateObstacles() {
		for(int i = 0; i < OBSTACLE_NUMBER; i++) {
			// Z -340 to 360
			// X -13.3175 to 14.26963
			Vector3 position = new Vector3(Random.Range(-13.0F, 14.0F), 0.5f, Random.Range(-340.0F, 360.0F));
			Instantiate(obstacle, position, Quaternion.identity);
		}
	}

	public static void GameOver() {
		Application.LoadLevel("MenuScene");
	}
}
