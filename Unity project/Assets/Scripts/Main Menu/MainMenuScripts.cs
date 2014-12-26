using UnityEngine;
using System.Collections;

public class MainMenuScripts {

	// DEFINING THE VARIABLES THAT WE WILL NEED
	private int classSelection;
	private BaseCharacterClass[] classSelectionInstances = new BaseCharacterClass[3] {new FrontEndClass(), new BackEndClass(), new FullStackClass()};
	private string[] classSelectionNames = new string[3] {"Front End Developer", "Back End Developer", "Full Stack Developer"};
	// STAT ALLOCATION MODULE
	private StatAllocationModule statAllocationModule = new StatAllocationModule();

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

		// SELECT THE CLASS AND SEE THE DESCRIPTION
		classSelection = GUI.SelectionGrid(new Rect (50,150,450,50), classSelection, classSelectionNames, 3);
		DisplayClassDescription(classSelection);

		// STORE THE CLASS SELECTION AND GO TO THE NEXT STATE
		if (GUI.Button (new Rect (50,Screen.height - 200,100,50), "Next")) {
			ChooseClass(classSelection);
			MainMenuGUI.currentState = MainMenuGUI.CreateAPlayerStates.STATALLOCATION;
		}
	}

	//THINGS TO DISPLAY ON THE STAT ALLOCATION SCREEN
	public void DisplayStatAllocationItems() {
		GUI.Label (new Rect(50,50,100,100), "Stat Allocation");

		// DISPLAY THE STATS
		statAllocationModule.DisplayStatNames();
		statAllocationModule.DisplayStatValues();

		if (GUI.Button (new Rect (50,Screen.height - 200,100,50), "Next")) {
			MainMenuGUI.currentState = MainMenuGUI.CreateAPlayerStates.FINALSETUP;
		}
	}

	//THINGS TO DISPLAY ON THE FINAL SETUP SCREEN
	public void DisplayFinalSetupItems() {
		GUI.Label (new Rect(50,50,100,100), "Final Setup");

		if (GUI.Button (new Rect (50,Screen.height - 200,100,50), "Play!")) {
			// CHANGE SCENE
			Debug.Log("Doge");
		}
	}

	//====================//
	//  HELPER FUNCTIONS  //
	//====================//

	private void DisplayClassDescription(int classSelection) {
		if (classSelection != null) {
			GUI.Label (new Rect(50,210,450,50), classSelectionInstances[classSelection].CharacterClassDescription);
		}
	}

	private void ChooseClass(int classSelection) {
		if (classSelection == 0) {
			GameInformation.PlayerClass = new FrontEndClass();
		} else if (classSelection == 1) {
			GameInformation.PlayerClass = new BackEndClass();
		} else {
			GameInformation.PlayerClass = new FullStackClass();
		}
	}
}
