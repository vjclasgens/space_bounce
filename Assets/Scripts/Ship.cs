using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	// Move the ship forward
	void Awake() {
		rigidbody.AddForce(0, 0, 10, ForceMode.Impulse);
		InvokeRepeating("IncreaseShipVelocity", 1, 0.5f);
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
//		MoveShipZ();
		MoveShipX();
	}

	// Method to move the ship forward at a constant rate
	void MoveShipZ () {
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
	}

	// Method to detect clicks and move the ship left or right
	// based on the click position
	void MoveShipX () {
		if(Input.GetMouseButton(0))
		{
			Vector3 clickPosition = Input.mousePosition;
			Vector3 shipPosition = transform.position;

			// Case where the click is on the left side of the screen
			if(clickPosition.x < Screen.width/2) {
				shipPosition.x -= 0.125f;
				transform.position = shipPosition;
			}
			// Case where the click is on the right side of the screen
			if(clickPosition.x > Screen.width/2) {
				shipPosition.x += 0.125f;
				transform.position = shipPosition;
			}
		}
	}

	// Increase the ships velocity up to max speed
	void IncreaseShipVelocity () {
		Vector3 velocity = rigidbody.velocity;
		velocity.z += 1.5f;
		rigidbody.velocity = velocity;
	}

	// Handle velocity when the ship hits a velocity object
	void OnCollisionEnter (Collision collision) {
		Debug.Log("SHIP HIT!");
		rigidbody.velocity *= -2f;
	}

//	void OnTriggerEnter (Collider collider) {
//		Debug.Log("EXIT HIT");
//		rigidbody.velocity *= -2f;
//	}
}
