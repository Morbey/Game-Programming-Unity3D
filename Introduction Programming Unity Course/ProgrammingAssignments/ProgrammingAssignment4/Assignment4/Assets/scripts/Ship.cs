using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ship object class
/// </summary>
public class Ship : MonoBehaviour
{

	// Ship Rigidbody2D
	Rigidbody2D rb2d;
	// Ship thrust direction
	Vector2 thrustDirection;
	// Ship thrust force
	const float ThrustForce = 3f;
	// Ship circle collider radius
	float circleColliderRadius;

	// Rotation
	const float RotateDegreesPerSecond = 100f;

	/// <summary>
	/// Starts the Ship game object
	/// </summary>
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		CircleCollider2D collider = GetComponent<CircleCollider2D> ();
		if (collider != null)
		{
			circleColliderRadius = collider.radius;
		}
	}

	/// <summary>
	/// Apply the force every fixed frame, instead of every frame inside Update method
	/// </summary>
	void FixedUpdate()
	{
		// Handle Thrust
		if (Input.GetAxis ("Thrust") != 0) 
		{
			float rotationAngle = Mathf.Deg2Rad * transform.eulerAngles.z;
			thrustDirection.x = Mathf.Cos(rotationAngle);
			thrustDirection.y = Mathf.Sin(rotationAngle);

			rb2d.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
		}

		// Handle rotation
		float rotationInput = Input.GetAxis ("Rotate");
		if (rotationInput != 0) {
			// calculate rotation amount and apply rotation
			float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
			if (rotationInput < 0) { 
				rotationAmount *= -1;
			}
			transform.Rotate(Vector3.forward, rotationAmount);
		}
	}

	/// <summary>
	/// When the renderer is no longer visible by any camera
	/// </summary>
	void OnBecameInvisible () {
		Vector3 shipPosition = transform.position;

		// left clamp
		if (shipPosition.x - circleColliderRadius < ScreenUtils.ScreenLeft) {
			shipPosition.x *= -1;
		}
		// right clamp
		else if (shipPosition.x + circleColliderRadius > ScreenUtils.ScreenRight) {
			shipPosition.x *= -1;
		}

		// top clamp
		if (shipPosition.y + circleColliderRadius > ScreenUtils.ScreenTop) {
			shipPosition.y *= -1;
		}
		// bottom clamp
		else if (shipPosition.y - circleColliderRadius < ScreenUtils.ScreenBottom) {
			shipPosition.y *= -1;
		}

		transform.position = shipPosition;
	}

}
