using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	//public GameObject projectileParent;
	public GameObject gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner ();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	void SetMyLaneSpawner () {
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in lane");
	}

	bool IsAttackerAheadInLane () {
		// No attackers...
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		// Checking attackers in lanes...
		foreach (Transform child in myLaneSpawner.transform) {
			if (child.transform.position.x > transform.position.x) {
				return true;
			}
		}

		// Behind...
		return false;
	}

	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
