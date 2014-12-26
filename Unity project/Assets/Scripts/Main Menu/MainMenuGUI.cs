using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	// STATE MACHINE
	public enum CreateAPlayerStates {
		MAINMENU,
		CLASSSELECTION,
		STATALLOCATION,
		FINALSETUP
	}
	// GLOBAL VARIABLE TO KEEP TRACK OF THE CURRENT STATE
	public static CreateAPlayerStates currentState;
	private MainMenuScripts mainMenuScripts = new MainMenuScripts();

	// Use this for initialization
	void Start () {
		currentState = CreateAPlayerStates.MAINMENU;
	}
	
	// KEEPS TRACK OF THE STATE FOR EACH FRAME
	void Update () {
		switch(currentState){
		case(CreateAPlayerStates.MAINMENU):
			break;
		case(CreateAPlayerStates.CLASSSELECTION):
			break;
		case(CreateAPlayerStates.STATALLOCATION):
			break;
		case(CreateAPlayerStates.FINALSETUP):
			break;
		}
	}

	// DECIDES WHICH FUNCTION TO CALL ACCORDING TO THE STATE
	void OnGUI () {
		if (currentState == CreateAPlayerStates.MAINMENU) {
			mainMenuScripts.DisplayMainMenuItems();
		} else if (currentState == CreateAPlayerStates.CLASSSELECTION) {
			mainMenuScripts.DisplayClassSelectionItems();
		} else if (currentState == CreateAPlayerStates.STATALLOCATION) {
			mainMenuScripts.DisplayStatAllocationItems();
		} else {
			mainMenuScripts.DisplayFinalSetupItems();
		}
	}
}
