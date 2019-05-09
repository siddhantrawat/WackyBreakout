using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner: MonoBehaviour {
		// Use this for initialization

	Timer timer;
	[SerializeField]
	GameObject prefabBall;

	bool retrySpawn = false;
	Vector2 spawnLocationMin;
	Vector2 spawnLocationMax;


	void Start () {
		
		gameObject.AddComponent<Timer> ();
		timer = GetComponent<Timer> ();
		timer.Duration = Random.Range (ConfigurationUtils.MinBallSpawnTime, ConfigurationUtils.MaxBallSpawnTime);
		timer.Run ();

        EventManager.AddBallSpawnListener(SpawnBall);
       
		//spawn check support

		GameObject tempBall = Instantiate<GameObject>(prefabBall);
		BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
		float ballColliderHalfWidth = collider.size.x / 2;
		float ballColliderHalfHeight = collider.size.y / 2;
		spawnLocationMin = new Vector2(
			tempBall.transform.position.x - ballColliderHalfWidth,
			tempBall.transform.position.y - ballColliderHalfHeight);
		spawnLocationMax = new Vector2(
			tempBall.transform.position.x + ballColliderHalfWidth,
			tempBall.transform.position.y + ballColliderHalfHeight);
		Destroy(tempBall);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer.Finished) {
			SpawnBall ();
			if (retrySpawn) {
				SpawnBall ();
			}
			timer.Duration = Random.Range (ConfigurationUtils.MinBallSpawnTime, ConfigurationUtils.MaxBallSpawnTime);
			timer.Run ();
		}

	}
	public void SpawnBall () {
		if (Physics2D.OverlapArea (spawnLocationMin, spawnLocationMax) == null) {
			retrySpawn = false;
			Instantiate (prefabBall);
		} else
			retrySpawn = true;
	}

}
