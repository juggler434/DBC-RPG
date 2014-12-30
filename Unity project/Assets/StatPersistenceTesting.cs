using UnityEngine;
using System.Collections;

public class StatPersistenceTesting : MonoBehaviour {
	
	void OnGUI () {
		// TESTED. IT WORKS IF YOU START FROM THE MAIN MENU
		GUI.Label (new Rect (10, 10, 100, 30), GameInformation.PlayerName);
		GUI.Label (new Rect (10, 40, 100, 30), GameInformation.PlayerClass.CharacterClassName);
		GUI.Label (new Rect (10, 70, 100, 30), GameInformation.PlayerLevel.ToString());

		GUI.Label (new Rect (10, 100, 100, 30), GameInformation.Strength.ToString());
		GUI.Label (new Rect (10, 130, 100, 30), GameInformation.Intellect.ToString());
		GUI.Label (new Rect (10, 160, 100, 30), GameInformation.Stamina.ToString());
		GUI.Label (new Rect (10, 190, 100, 30), GameInformation.Speed.ToString());
		GUI.Label (new Rect (10, 210, 100, 30), GameInformation.Resistance.ToString());
	}
}
