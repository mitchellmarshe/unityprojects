using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage;
	
	// Destroy object.
	public void Hit () {
		Destroy (gameObject);
	}
	
	// Return damage done.
	public float GetDamage () {
		return damage;
	}
}
