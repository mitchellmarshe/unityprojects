using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttons;
	private Text costText;

	// Use this for initialization
	void Start () {
		buttons = GameObject.FindObjectsOfType<Button> ();
		costText = GetComponentInChildren<Text> ();
		if (!costText) {
			Debug.LogWarning (name + " has no cost text");
		}
		costText.text = defenderPrefab.GetComponent<Defenders> ().starCost.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		foreach (Button button in buttons) {
			button.GetComponent<SpriteRenderer> ().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
