using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
	
	void Start () {
		if (autoLoadNextLevelAfter == 0) {
			Debug.Log ("Level auto load disabled.");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	
	// Load this level into game.
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}
	
	// Load the next level into game.
	public void LoadNextLevel () {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	// Quit game. Supports Windows, Mac, and Linux ONLY!
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
