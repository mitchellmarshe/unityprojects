using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	
	// Destroy projectile.
	void OnTriggerEnter2D (Collider2D collider) {
		Destroy (collider.gameObject);
	}
}
