using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width;
	public float height;
	public float speed;
	public float spawnDelay;
	
	private bool movingRight = false;
	private float xmin;
	private float xmax;
	
	
	// Use this for initialization.
	void Start () {
		// Restrict formation to viewport.
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, distance));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, distance));
		xmin = leftBoundary.x;
		xmax = rightBoundary.x;
		
		//SpawnEnemies ();
		SpawnUntilFull ();
	}
	
	// Update is called once per frame.
	void Update () {
		// Move formation left to right.
		if (movingRight) {
			//transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
			transform.position += Vector3.right * speed * Time.deltaTime; 
		} else {
			//transform.position += new Vector3 (-speed * Time.deltaTime, 0f, 0f);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		if (leftEdgeOfFormation < xmin) {
			movingRight = true;
		} else if (rightEdgeOfFormation > xmax) {
			movingRight = false;
		}
		
		if (AllMembersDead ()) {
			//SpawnEnemies ();
			SpawnUntilFull ();
		}
	}
	
	// Spawn enemies in formation.
	void SpawnEnemies () {
		/* EnemySpawner
		 *  Position
		 *   Enemy
		 */
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Spawn enemies into formation until all positions are filled.
	void SpawnUntilFull () {
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}
	
	// Return next free position in formation.
	Transform NextFreePosition () {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}
	
	// Determine whether all members are dead. 
	bool AllMembersDead () {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
	
	// Draw a box around enemy formation. Enable Gizmos to see.
	public void OnDrawGizmos () {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0f));
	}
}
