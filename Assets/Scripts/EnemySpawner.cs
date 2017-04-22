using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	public float width = 10f;
	public float height = 5f;
	public float padding;
	public float speed;
	public float spawnDelay;

	float xMin;
	float xMax;
	float yMin;
	float yMax;

	private	bool goRight = true;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
		SpawnUntilFull ();
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height) );
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x >= xMax){
			goRight = false;
		}
		if(transform.position.x <= xMin){
			goRight = true;
		}

		if(goRight){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}else{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if(AllMembersDead()){
			SpawnUntilFull();
		}
	}

	void SpawnEnemies ()	{
		foreach (Transform child in transform) {
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, child.transform.position, Quaternion.identity);
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull() {
		string methodName = "SpawnUntilFull";
		Transform freePosition = NextFreePosition();	
		if(freePosition != null){
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
			Invoke(methodName, spawnDelay);
		}

	}

	Transform NextFreePosition() {
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead() {
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount > 0){
				return false;
			}
		}
		return true;
	}
}
