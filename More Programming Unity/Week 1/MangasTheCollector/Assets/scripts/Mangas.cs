using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mangas class
/// </summary>
public class Mangas : MonoBehaviour {

	#region Fields

	// flag with the mangas state. If is collecting or stopped
	bool IsCapturing = false;

	// Mouse Buttons state
	bool LeftMouseButtonPressed = false;

	// Magnitude of the impulse force on mangas object
	const float ImpulseForceMagnitude = 2.0f;

	// current teddy mangas is chasing
	GameObject currentTarget;

	// fore efficiency
	Rigidbody2D mangasRB2d;
	CollectorGameManager gameManager;

	#endregion


	#region Methods

	/// <summary>
	/// Start the Mangas game object.
	/// </summary>
	void Start () {
		mangasRB2d = GetComponent<Rigidbody2D> ();
		gameManager = Camera.main.GetComponent<CollectorGameManager> ();
	}

	/// <summary>
	/// Called when another object is within a trigger collider
	/// attached to this object
	/// </summary>
	/// <param name="otherCollider">collider info</param>
	void OnTriggerStay2D(Collider2D otherCollider)
	{
		// checks if collision is with the nextTarget teddy bear
		if (otherCollider.gameObject == currentTarget) {
			gameManager.DestroyTeddyBear (currentTarget);
			GoFish ();
		}
	}

	/// <summary>
	/// When mouse is over the game object
	/// </summary>
	void OnMouseOver() {
		if (!IsCapturing && Input.GetMouseButtonDown (0)) {
			if (!LeftMouseButtonPressed) {
				LeftMouseButtonPressed = true;
				GoFish ();
			}
		}
		else {
			LeftMouseButtonPressed = false;
		}
	}

	/// <summary>
	/// Search for the next teddy bear and Start's collecting if any
	/// </summary>
	private void GoFish () {

		currentTarget = gameManager.NextTarget;

		// Set Mangas velocity as zero
		mangasRB2d.velocity = Vector2.zero;

		if (currentTarget != null) {
			IsCapturing = true;
			Vector2 direction = new Vector2 (
				currentTarget.transform.position.x - transform.position.x, 
				currentTarget.transform.position.y - transform.position.y
			);

			// makes the vector with magnitude of 1
			direction.Normalize ();
			mangasRB2d.AddForce (direction * ImpulseForceMagnitude, ForceMode2D.Impulse);
		}
		else {
			IsCapturing = false;
		}
	}

	/// <summary>
	/// When mouse is no longer over the game object
	/// </summary>
	void OnMouseExit() {
		LeftMouseButtonPressed = false;
	}

	/// <summary>
	/// Starts the capturing of targets
	/// </summary>
	void StartCapturing () {
		// Get the direction to move Mangas to

		// Set the impulse force into the Mangas object
	}
	#endregion
}
