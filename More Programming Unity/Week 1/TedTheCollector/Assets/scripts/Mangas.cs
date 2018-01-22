using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mangas object
/// </summary>
public class Mangas : MonoBehaviour {
	
	#region fields
	// teddy bear
	[SerializeField]
	GameObject prefabTeddy;

	List<GameObject> teddyList = new List<GameObject>();

	bool leftButtonClicked = false;
	#endregion

	#region properties

	/// <summary>
	/// Gets the next target pickup for the ted the collector to collect
	/// </summary>
	/// <value>target pickup</value>
	public GameObject GetTargetPickup {
		get {
			if (teddyList.Count > 0) {
				return teddyList [0];
			}
			else {
				return null;
			}
		}
	}

	#endregion

	#region Methods
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// if left mouse button clicked
		if (Input.GetMouseButtonDown (0) && !leftButtonClicked) {
			SpawnTeddy ();
			leftButtonClicked = true;
		}
		else {
			leftButtonClicked = false;
		}
	}

	private void SpawnTeddy() {
		// create a teddy bear
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = -Camera.main.transform.position.z;
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint (mousePosition);

		GameObject newTeddy = Instantiate (prefabTeddy) as GameObject;
		newTeddy.transform.position = worldPosition;
		teddyList.Add (newTeddy);
	}
	#endregion
}
