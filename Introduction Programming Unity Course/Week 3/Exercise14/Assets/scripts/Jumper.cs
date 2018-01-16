using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jump class
/// </summary>
public class Jumper : MonoBehaviour {

	// Jump  location  support
	const float minX = -5;
	const float maxX = 5;
	const float minY = -2.5f;
	const float maxY = 2.5f;

	// timer
	float totalJumpDelaySeconds = 0.01f;
	float elapsedJumpDelaySeconds = 0;

	// <summary>
	/// Update  timer
	/// </summary>
	void Update () {
		elapsedJumpDelaySeconds += Time.deltaTime;

		if (elapsedJumpDelaySeconds >= totalJumpDelaySeconds) {
			elapsedJumpDelaySeconds = 0;

			transform.position = new Vector3 (
				Random.Range (minX, maxX), 
				Random.Range (minY, maxY)
			);
		}
	}
}
