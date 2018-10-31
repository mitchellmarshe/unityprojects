using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for: " + name);
		Application.LoadLevel(name);
	}
	
	// Supports Windows, Linux, and OS.
	public void QuitRequest() {
		Debug.Log("Quit requested.");
		Application.Quit();
	}
}
