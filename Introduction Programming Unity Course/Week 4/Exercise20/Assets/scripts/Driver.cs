using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Drives the game object based on keyboard input
/// </summary>
public class Driver : MonoBehaviour {
	
	//store how many units your game object moves per second 
	const float MoveUnitsPerSecond = 5;

	// Save the value on the Horizontal input axis
	void Update () {
		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
		Vector3 position = transform.position;

		if (horizontalInput != 0) {
			position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;
		}
		if (verticalInput != 0) {
			position.y += verticalInput * MoveUnitsPerSecond * Time.deltaTime;
		}

		transform.position = position;
	}
}
