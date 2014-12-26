using UnityEngine;
using System.Collections;

public class StatAllocationModule {
	
	private string[] statNames = new string[5] {"Strength", "Intellect", "Stamina", "Speed", "Resistance"};

	public void DisplayStatNames() {
		for (int i = 0; i < statNames.Length; i++) {
			GUI.Label (new Rect (50,100 + 50*i,100,40), statNames[i]);
		}
	}

	public void DisplayStatValues() {

		// CREATE AN ARRAY OF VALUES CORRESPONDING TO OUR CLASS
		BaseCharacterClass playerClass = GameInformation.PlayerClass;
		int[] statValues = new int[5] { playerClass.Strength, playerClass.Intellect, playerClass.Stamina, playerClass.Speed, playerClass.Resistance };

		for (int i = 0; i < statValues.Length; i++) {
			GUI.Label (new Rect (150,100 + 50*i,100,40), statValues[i].ToString());
		}
	}
}
