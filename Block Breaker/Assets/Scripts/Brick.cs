using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public GameObject smoke;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	
	private int hits;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		hits = 0;
		levelManager = GameObject.FindObjectOfType <LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.25f);
		if (isBreakable) {
			hitManager ();
		}
	}
	
	void hitManager () {
		hits++;
		int maxHits = hitSprites.Length + 1;
		if (hits >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			SmokeEffect ();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}
	
	void SmokeEffect () {
		// Create GameObject and set it with instance as a new GameObject.
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent <SpriteRenderer> ().color;
	}
	
	void LoadSprites () {
		int spriteIndex = hits - 1;
		if (hitSprites[spriteIndex] != null) { // Use default image if null.
			this.GetComponent <SpriteRenderer> ().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing!");
		}
	}
	
	// TODO remove this later...
	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}
