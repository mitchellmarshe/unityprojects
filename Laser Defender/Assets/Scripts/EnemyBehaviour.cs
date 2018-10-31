using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float health;
	public GameObject projectile;
	public float projectileSpeed;
	public float shotsPerSeconds;
	public int scoreValue;
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start () {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper> ();
	}
	
	void Update () {
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Fire ();
		}
	}
	
	// Fire laser.
	void Fire () {
		Vector3 startPosition = transform.position + new Vector3(0f, -1f, 0f);
		GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector3 (0f, -projectileSpeed, 0f);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}

	// Collision trigger.
	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent <Projectile> ();
		if (missile) {
			health -= missile.GetDamage ();
			missile.Hit ();
			if (health <= 0) {
				Die ();
			}
		}
	}
	
	// Enemy's death.
	void Die () {
		scoreKeeper.Score(scoreValue);
		AudioSource.PlayClipAtPoint (deathSound, transform.position);
		Destroy (gameObject);
	}
}
