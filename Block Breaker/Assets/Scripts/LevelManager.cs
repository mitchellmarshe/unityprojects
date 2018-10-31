using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Load this level into game.
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel (name);
	}
	
	// Load the next level into game.
	public void LoadNextLevel () {
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	// All bricks destroyed.
	public void BrickDestroyed () {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}

	// Quit game. Supports Windows, Mac, and Linux ONLY!
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
