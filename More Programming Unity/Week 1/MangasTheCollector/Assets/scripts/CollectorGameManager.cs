using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game manager for the collector game
/// </summary>
public class CollectorGameManager : MonoBehaviour {

	#region Fields

	// List of existing teddies
	List<GameObject> teddyBearList = new List<GameObject>();

	[SerializeField]
	public GameObject teddyBearPrefab;

	// Mouse button state
	bool RightMouseButtonPressed = false;

	#endregion


	#region Properties

	/// <summary>
	/// Returns the next target in the list.
	/// </summary>
	/// <value>Next target</value>
	public GameObject NextTarget {
		get {
			if (teddyBearList.Count > 0) {
				return teddyBearList [0];
			} else {
				return null;
			}
		}
	}

	#endregion


	#region Methods
	
	/// <summary>
	/// Update this instance every frame.
	/// </summary>
	void Update () {
		// Checks if right mouse button was pressed. If yes creates a teddy bear on mouse position
		if (Input.GetMouseButtonDown (1)) {
			if (!RightMouseButtonPressed) {
				RightMouseButtonPressed = true;
				CreateTeddyBear ();
			}
		}
		else {
			RightMouseButtonPressed = false;
		}
	}

	private void CreateTeddyBear () {
		// Get mouse position and get world relative position
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

		GameObject teddyBear = Instantiate<GameObject> (teddyBearPrefab, worldPosition, Quaternion.identity);
		teddyBearList.Add (teddyBear);

	}

	/// <summary>
	/// Destroys the teddy bear.
	/// </summary>
	/// <param name="teddy">Teddy bear</param>
	public void DestroyTeddyBear(GameObject teddy) {
		teddyBearList.Remove (teddy);
		Destroy (teddy);
	}

	#endregion
}
