using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangasTheCollector : MonoBehaviour {

	#region fields

	// Collector rigid body 2d
	Rigidbody2D rb2d;

	Ted teddyBear;

	bool isCollecting = false;

	#endregion

	#region Methods

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		teddyBear = Camera.main.GetComponent<Ted> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			if (!isCollecting) {
				StartCollecting ();
			}
		}
	}

	private void StartCollecting () {
		float x = transform.position.x - teddyBear.transform.position.x;
		float y = transform.position.y - teddyBear.transform.position.y;
		Vector2 direction = new Vector2 (x, y);

		rb2d.AddForce (direction, ForceMode2D.Impulse);
	}
	#endregion
}
