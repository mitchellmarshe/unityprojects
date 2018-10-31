using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score;
	
	private Text text;
	
	void Start () {
		Reset ();
		text = GetComponent<Text>();
		text.text = score.ToString ();
	}

	public void Score (int points) {
		score += points;
		text.text = score.ToString ();
	}
	
	public static void Reset () {
		score = 0;
	}
}
