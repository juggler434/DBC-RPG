using UnityEngine;
using System.Collections;

public class Phase1Information : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}

	// CHALLENGE 1: SCAVENGER HUNT
	public static bool laptopCollected = false;
	public static bool bookCollected = false;
	public static bool cupCollected = false;

}
