using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Processes mouse button inputs
/// </summary>
public class MouseButtonProcessor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    public GameObject prefabTeddyBear;

    // first frame input support
    bool spawnInputOnPreviousFrame = false;
	bool explodeInputOnPreviousFrame = false;

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{

        // spawn teddy bear as appropriate
		if (Input.GetAxis ("SpawnTeddyBear") > 0) {
			if (!spawnInputOnPreviousFrame) {
				// getMouseLocation
				Vector3 location = Input.mousePosition;
				location.z = -Camera.main.transform.position.z;
				location = Camera.main.ScreenToWorldPoint (location);

				spawnInputOnPreviousFrame = true;
				Instantiate<GameObject> (prefabTeddyBear, location, Quaternion.identity);
			}
		}
		else {
			spawnInputOnPreviousFrame = false;
		}

		// explode teddy bear as appropriate
		if (Input.GetAxis ("ExplodeTeddyBear") > 0) {
			if (!explodeInputOnPreviousFrame) {
				// getOneTeddyBearToExplode
				GameObject teddy = GameObject.FindGameObjectWithTag("TeddyBear");
				if (teddy != null) {
					Destroy (teddy);
					Instantiate<GameObject> (prefabExplosion, teddy.transform.position, Quaternion.identity);
				}
				explodeInputOnPreviousFrame = true;
			}
		}
		else {
			explodeInputOnPreviousFrame = false;
		}		
	}
}
