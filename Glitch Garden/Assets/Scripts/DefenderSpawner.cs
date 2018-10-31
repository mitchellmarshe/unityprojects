using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;
	private StarsDisplay starDisplay;
	
	// Use this for initialization
	void Start () {
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarsDisplay> ();
		if (!parent) {
			parent = new GameObject("Defenders");
		}
	}

	void SpawnDefender (Vector2 roundedPos)
	{
		GameObject defender = Button.selectedDefender;
		GameObject newDef = Instantiate (defender, roundedPos, Quaternion.identity) as GameObject;
		newDef.transform.parent = parent.transform;
	}

	void OnMouseDown () {
		Vector2 rawPos = CalculateWorldPointOfMouseClicked ();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defenders>().starCost;
		if (starDisplay.UseStars (defenderCost) == StarsDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender) {
		GameObject newDef = Instantiate (defender, roundedPos, Quaternion.identity) as GameObject;
		newDef.transform.parent = parent.transform;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClicked () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}
}
