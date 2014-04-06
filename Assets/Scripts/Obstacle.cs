using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Explosion to instantiate on collision
	public GameObject sparks;

	// The ship object
	public GameObject ship;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Remove the object from the field when it is collided with
	// and create a sparks object
	void OnCollisionEnter (Collision collision) {
		Debug.Log("OBSTACLE HIT!");
		Destroy(gameObject,0f);
		Instantiate(sparks, transform.position, Quaternion.identity);
//		ship.rigidbody.velocity *= -2f;
	}
}
