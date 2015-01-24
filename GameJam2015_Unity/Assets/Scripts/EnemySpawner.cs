using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Made by Thomas

public class EnemySpawner : MonoBehaviour {

	public float spawnTime = 2f;
	public GameObject enemy;
	public Vector2 spawnerLocation;
	public Vector2 spawnDirection;

	public int enemyPoolNumber = 5;
	List<GameObject> enemies;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = spawnerLocation;
		enemies =  new List<GameObject>();
		for(int i = 0; i < enemyPoolNumber; i++){
			GameObject obj = (GameObject)Instantiate(enemy);
			enemies.Add(obj);
		}
		
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Spawn(){
		for(int i = 0; i < enemies.Count; i++){
			if(!enemies[i].activeInHierarchy){
				enemies[i].transform.position = transform.position;
				enemies[i].transform.rotation = transform.rotation;
				enemies[i].SetActive(true);
				break;
			}
		}
	}
}
