using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().AddForce(
			new Vector2(3,0),
			ForceMode2D.Impulse);
	}

	/// <summary>
	/// Perform actions on collision detection
	/// </summary>
	/// <param name="coll">Collision</param>
	void OnCollisionEnter2D(Collision2D coll) {
		print ("Ouch");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
