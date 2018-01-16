using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour {

	// timer support fields
	const float TotalResizeSeconds = 1;
	float elapsedResizeSeconds = 0;

	// resize control fields
	const float ScaleFactorPerSecond = 1;
	// will be used to grow the game object if 1 and shrink if -1
	int scaleFactorSignMultiplier = 1;
	
	// Update is called once per frame
	void Update () {
		elapsedResizeSeconds += Time.deltaTime;

		if (elapsedResizeSeconds >= TotalResizeSeconds)
		{
			Vector3 teddyScale = transform.localScale;
			teddyScale.x += scaleFactorSignMultiplier;
			teddyScale.y += scaleFactorSignMultiplier;

			transform.localScale = teddyScale;
			scaleFactorSignMultiplier *= -1;
			elapsedResizeSeconds = 0;
		}
	}
}
