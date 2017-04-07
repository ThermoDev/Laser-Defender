﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform){			
			GameObject enemy = (GameObject)Instantiate(enemyPrefab, child.transform.position, Quaternion.identity );
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
