using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTeddyBear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//  quadruple  width  and  height
		Vector3 newVector = transform.localScale;
		newVector.x *= 4;
		newVector.y *= 4;

		transform.localScale = newVector;
	}

}
