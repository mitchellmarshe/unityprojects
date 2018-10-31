using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
	
	// Handle Unity3D's PlayerPref with a wrapper.
	
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_"; // level_unlocked_#
	
	public static void SetMasterVolume (float volume) {
		if (0f <= volume && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume out of range.");
		}
	}
	
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level) {
		if (0 <= level && level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // 1 = true.
		} else {
			Debug.LogError ("Trying to unlock a level not in build.");
		}
	}
	
	public static bool IsLevelUnlocked (int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlocked = (levelValue == 1);
		if (0 <= level && level <= Application.levelCount - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Trying to query a level not in build.");
			return false;
		}	
	}
	
	public static void SetDifficulty (float difficulty) {
		if (1f <= difficulty && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty out of range.");
		}	
	}
	
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
	
}
