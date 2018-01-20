using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jumps the game object to the mouse location when the left mouse button is pressed.
/// </summary>
public class Jumper : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// If the left mouse button is clicked do stuff
		if (Input.GetMouseButtonDown (0)) {
			// Get the mouse position
			Vector3 position = Input.mousePosition;
			position.z = -Camera.main.transform.position.z;
			position = Camera.main.ScreenToWorldPoint(position);

			// Move the game object to the mouse position

			transform.position = position;
		}
	}
}
