using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	public int starCost = 100;

	private StarsDisplay starDisplay;

	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarsDisplay> ();
	}

	public void AddStars (int amount) {
		starDisplay.AddStars (amount);
	}
}
