using UnityEngine;
using System.Collections;

public class LevelingScripts {

	private bool displayText;
	private string text;

	public void AddExperience(int experience) {
		// ADD EXPERIENCE TO OUR CURRENT EXPERIENCE
		GameInformation.CurrentXP += experience;

		// IF WE LEVEL UP, ADD POINTS TO ALLOCATE AND DISPLAY SOME TEXT
		if (GameInformation.CurrentXP >= GameInformation.RequiredXP) {
			++GameInformation.PlayerLevel;
			Debug.Log (GameInformation.PlayerLevel);
			GameInformation.PointsToAllocate += 3;

			text = "LEVEL UP! You have 3 Stat Points to allocate. Press P to allocate them or press E to continue with the game";
			displayText = true;
		}

		if (displayText) {
			GUI.Box (new Rect(10,Screen.height-220,Screen.width-20,200), text);
		}

		if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.P)) {
			displayText = false;
		}
	}

}
