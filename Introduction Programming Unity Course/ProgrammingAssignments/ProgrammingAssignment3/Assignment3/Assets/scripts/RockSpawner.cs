using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{

	GameObject[] existingPrefabRocks;

	[SerializeField]
	public GameObject prefabRock;

	[SerializeField]
	public Sprite spriteRock0;
	[SerializeField]
	public Sprite spriteRock1;
	[SerializeField]
	public Sprite spriteRock2;

	// Times the rock spawning
	Timer spawnTimer;
	float totalTimePassed = 0;
	const float SpawnTimeCooldown = 1f;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{		
		spawnTimer = gameObject.AddComponent<Timer> ();
		spawnTimer.Duration = 1;
		spawnTimer.Run ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		totalTimePassed += Time.deltaTime;

		existingPrefabRocks = GameObject.FindGameObjectsWithTag ("Rock");

		if (existingPrefabRocks.Length < 3 && totalTimePassed >= SpawnTimeCooldown) {
			// if timer is not running it means the rock creation is again ready
			if (spawnTimer != null && !spawnTimer.Running) {
				SpawnRock ();
				spawnTimer.Run ();
			}
			totalTimePassed = 0;
		}
	}

	/// <summary>
	/// Spawns a new Rock at the center of the window
	/// </summary>
	void SpawnRock ()
	{
		// Set location on the center of the screen
		Vector3 location = new Vector3 (Screen.width / 2, Screen.height / 2, -Camera.main.transform.position.z);
		Vector3 worldLocation = Camera.main.ScreenToWorldPoint (location);
		GameObject rock = Instantiate<GameObject>(prefabRock, worldLocation, Quaternion.identity);

		// Set random sprite for new teddy bear
		SpriteRenderer spriteRenderer = rock.GetComponent<SpriteRenderer> ();
		int spriteNumber = Random.Range (0, 3);

		switch (spriteNumber) {
		case 0:
			spriteRenderer.sprite = spriteRock0;
			break;
		case 1:
			spriteRenderer.sprite = spriteRock1;
			break;
		default:
			spriteRenderer.sprite = spriteRock2;
			break;
		}
	}
}
