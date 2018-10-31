using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	
	public int maxGuessesAllowed = 10;
	public Text number;

	// Use this for initialization
	void Start () {
		StartGame ();
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
		NextGuess ();
	}
	
	public void GuessHigher () {
		min = guess;
		NextGuess ();
	}
	
	public void GuessLower () {
		max = guess;
		NextGuess ();
	}
	
	void NextGuess () {
		guess = Random.Range (min, max + 1); // Rounding error.
		number.text = guess.ToString ();
		maxGuessesAllowed--;
		if (maxGuessesAllowed <= 0) {
			Application.LoadLevel ("Win");
		}
	}
}
