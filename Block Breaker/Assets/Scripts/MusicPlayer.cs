using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	
	// Called first in initialization phase.
	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
			//Debug.Log ("Duplicate music player self-destructed.");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			//Debug.Log ("Music player constructed.");
		}
	}

	// Use this for initialization
	//void Start () {

	//}
	
	// Update is called once per frame
	//void Update () {
	
	//}
}
