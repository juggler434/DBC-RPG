using UnityEngine;
using System.Collections;

public class MainMenuScripts {

	// DEFINING THE VARIABLES THAT WE WILL NEED
	private int classSelection;
	private string playerName = "Enter name...";

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
			SaveClass(classSelection);
			MainMenuGUI.currentState = MainMenuGUI.CreateAPlayerStates.STATALLOCATION;
		}
	}

	//THINGS TO DISPLAY ON THE STAT ALLOCATION SCREEN
	public void DisplayStatAllocationItems() {
		GUI.Label (new Rect(50,50,100,100), "Stat Allocation");

		// DISPLAY THE STATS
		statAllocationModule.DisplayStatAllocation();

		if (GUI.Button (new Rect (50,Screen.height - 200,100,50), "Next")) {
			SaveStats ();
			MainMenuGUI.currentState = MainMenuGUI.CreateAPlayerStates.FINALSETUP;
		}
	}

	//THINGS TO DISPLAY ON THE FINAL SETUP SCREEN
	public void DisplayFinalSetupItems() {
		GUI.Label (new Rect(50,50,100,100), "Final Setup");

		playerName = GUI.TextArea(new Rect(50,100,150,50), playerName, 25 );

		if (GUI.Button (new Rect (50,Screen.height - 200,100,50), "Play!")) {
			SaveFinalSetup();
			// CHANGE SCENE
			Debug.Log ("Going to Phase0!");
			Application.LoadLevel("Phase0");
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

	private void SaveClass(int classSelection) {
		// SAVE THE CLASS
		if (classSelection == 0) {
			GameInformation.PlayerClass = new FrontEndClass();
		} else if (classSelection == 1) {
			GameInformation.PlayerClass = new BackEndClass();
		} else {
			GameInformation.PlayerClass = new FullStackClass();
		}
	}

	private void SaveStats() {
		// SAVE ALL THE STATS AFTER THE ALLOCATION
		GameInformation.Strength = statAllocationModule.pointsToAllocate[0];
		GameInformation.Intellect = statAllocationModule.pointsToAllocate[1];
		GameInformation.Stamina = statAllocationModule.pointsToAllocate[2];
		GameInformation.Speed = statAllocationModule.pointsToAllocate[3];
		GameInformation.Resistance = statAllocationModule.pointsToAllocate[4];
		GameInformation.MaxHealth = calculateMaxHealth ();
		GameInformation.CurrentHealth = GameInformation.MaxHealth;
	}

	private void SaveFinalSetup() {
		// SAVE ALL THE OTHER INFO 
		GameInformation.PlayerName = playerName;
		// DEFAULT
		GameInformation.PlayerLevel = 1;
		GameInformation.Gold = 1000;

	}


	public int calculateMaxHealth(){
		return GameInformation.Resistance * 100;
	}
}
