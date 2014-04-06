using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision) {
//		Destroy(gameObject,0f);
//		Instantiate(sparks, transform.position, transform.rotation);
		MainGame.GameOver();
	}
}
