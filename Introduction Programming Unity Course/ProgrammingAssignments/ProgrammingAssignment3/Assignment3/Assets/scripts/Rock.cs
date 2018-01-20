using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	// Impulse Force to move the rocks
	const float MinImpulseForce = 1f;
	const float MaxImpulseForce = 2f;

	/// <summary>
	/// Starts the rock object
	/// </summary>
	void Start () {
		
		// apply impulse force to get game object moving
		float angle = Random.Range(0, 2 * Mathf.PI);
		Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
		GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
