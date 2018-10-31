using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackers;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackers) {
			if (isTimeToSpawn (attacker)) {
				Spawn (attacker);
			}
		}
	}

	void Spawn (GameObject attacker) {
		GameObject newAtt = Instantiate (attacker) as GameObject;
		newAtt.transform.parent = transform;
		newAtt.transform.position = transform.position;
	}

	bool isTimeToSpawn (GameObject attacker) {
		Attackers att = attacker.GetComponent<Attackers>();

		float meanSpawnDelay = att.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate.");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		return (Random.value < threshold);
	}
}
