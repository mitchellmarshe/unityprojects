using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	
	// Draw a target for positioning a enemy object. Enable Gizmos to see.
	void OnDrawGizmos () {
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}
