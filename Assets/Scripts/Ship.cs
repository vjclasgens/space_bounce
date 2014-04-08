using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	// How far to rotate the ship in each direction
	private static int MAX_ROTATION_LEFT = 26;
	private static int MAX_ROTATION_RIGHT = 334;

	// Move the ship forward
	void Awake() {
		rigidbody.AddForce(0, 0, 10, ForceMode.Impulse);
		// Increase the velocity at a constant rate
		InvokeRepeating("IncreaseShipVelocity", 1, 0.5f);
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
//		MoveShipZ();c
		MoveShipX();
	}

	// Method to move the ship forward at a constant rate
	void MoveShipZ () {
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
	}

	// Method to detect clicks and move the ship left or right
	// based on the click position
	void MoveShipX () {

		// The current state of rotation
		Vector3 shipRotation = transform.eulerAngles;
		Vector3 shipPosition = transform.position;

		if(Input.GetMouseButton(0))
		{
			Vector3 clickPosition = Input.mousePosition;

			// Case where the click is on the left side of the screen
			if(clickPosition.x < Screen.width/2) {
				shipPosition.x -= 0.125f;
				transform.position = shipPosition;

				// Rotate the Camera and ship when moving left
				shipRotation.z += 1;
				// Max left rotation z = 26

				// Rotation on the ship based on movement
				if(shipRotation.z <= MAX_ROTATION_LEFT || shipRotation.z >= MAX_ROTATION_RIGHT) {
					transform.RotateAround(shipPosition, new Vector3(0, 0, 1), 1);
				}
			}
			// Case where the click is on the right side of the screen
			if(clickPosition.x > Screen.width/2) {
				shipPosition.x += 0.125f;
				transform.position = shipPosition;

				// Rotate the Camera and ship when moving right
				shipRotation.z -= 1;
				// Center ship 2.390294,0.8212909,-320.5756
				// Max Right rotation z = 334

				// Rotation on the ship based on movement
				if(shipRotation.z >= MAX_ROTATION_RIGHT || shipRotation.z <= MAX_ROTATION_LEFT) {
					transform.RotateAround(shipPosition, new Vector3(0, 0, 1), -1);
				}
			}
		}
		// Rotate the ship back to starting position when not moving left or right
		else {
			if(shipRotation.z > 0 && shipRotation.z < MAX_ROTATION_LEFT) {
				transform.RotateAround(shipPosition, new Vector3(0, 0, 1), -1);
			}
			if(shipRotation.z >= MAX_ROTATION_RIGHT && shipRotation.z <= 360) {
				transform.RotateAround(shipPosition, new Vector3(0, 0, 1), 1);
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
