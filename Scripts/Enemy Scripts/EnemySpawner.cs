using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public float min_Y = -4.45f, max_Y =4.45f;

	public GameObject[] asteroid_Prefabs;
	public GameObject enemyPrefab;

	public float timer =2f;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemies", timer);
	}
	
	void SpawnEnemies(){
		float pos_Y = Random.Range (min_Y, max_Y);
		Vector3 temp = transform.position;
		temp.y = pos_Y;

		//This is to randomly choose between asteroid 1 and asteroid 2
		if (Random.Range (0, 2) > 0) {
			Instantiate (asteroid_Prefabs [Random.Range (0, asteroid_Prefabs.Length)],
				temp, Quaternion.identity);
			
			//This is to spawn the enemy spaceship
		} else {
			Instantiate (enemyPrefab, temp, Quaternion.Euler (0f, 0f, 90f));
		}

		Invoke ("SpawnEnemies", timer);
	}

}//class
