using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float padding;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate;
	public float health;
	
	public AudioClip fireSound;
	
	private float xmin;
	private float xmax;
	
	// Use this for initialization.
	void Start () {
		// Restrict viewport to the game space.
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame.
	void Update () {
		// Projectile controlls
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
		
		// Player controlls.
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position += new Vector3 (-speed * Time.deltaTime, 0f, 0f);
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		// Restrict player to the game space.
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}
	
	// Fire a projectile.
	void Fire () {
		Vector3 offset = new Vector3 (0f, 1f, 0f);
		GameObject laser = Instantiate (projectile, transform.position + offset, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3 (0f, projectileSpeed, 0f);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}
	
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
	
	// Player's death.
	void Die () {
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel ("Win Screen");
		Destroy (gameObject);
	}
}
