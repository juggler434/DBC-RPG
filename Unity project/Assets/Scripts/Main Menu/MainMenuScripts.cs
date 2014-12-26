using UnityEngine;
using System.Collections;

public class MainMenuScripts {

	// DEFINING THE VARIABLES THAT WE WILL NEED

	// THINGS TO DISPLAY ON THE MAIN MENU
	public void DisplayMainMenuItems() {
		GUI.Label (new Rect(50,50,100,100), "Main Menu");

		if (GUI.Button (new Rect (50,150,100,50), "New Game")) {
			MainMenuGUI.currentState = MainMenuGUI.CreateAPlayerStates.CLASSSELECTION;
		}
	}

	//THINGS TO DISPLAY ON THE CLASS SELECTION SCREEN
	public void DisplayClassSelectionItems() {
		GUI.Label (new Rect(50,50,100,100), "Class Selection");

		if (GUI.Button (new Rect (50,150,100,50), "Next")) {
			MainMenuGUI.currentState = MainMenuGUI.CreateAPlayerStates.STATALLOCATION;
		}
	}

	//THINGS TO DISPLAY ON THE STAT ALLOCATION SCREEN
	public void DisplayStatAllocationItems() {
		GUI.Label (new Rect(50,50,100,100), "Stat Allocation");

		if (GUI.Button (new Rect (50,150,100,50), "Next")) {
			MainMenuGUI.currentState = MainMenuGUI.CreateAPlayerStates.FINALSETUP;
		}
	}

	//THINGS TO DISPLAY ON THE FINAL SETUP SCREEN
	public void DisplayFinalSetupItems() {
		GUI.Label (new Rect(50,50,100,100), "Final Setup");

		if (GUI.Button (new Rect (50,150,100,50), "Play!")) {
			// CHANGE SCENE
			Debug.Log("Doge");
		}
	}
}
