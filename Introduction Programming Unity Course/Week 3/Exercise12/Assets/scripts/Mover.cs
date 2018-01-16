using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the object
/// </summary>
public class Mover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Get the game object moving
		GetComponent<Rigidbody2D>().AddForce(
			new Vector2(0 ,5),
			ForceMode2D.Impulse);
	}
}
