using UnityEngine;
using System.Collections;

public class ProximityTest : MonoBehaviour {

	// INITIALIZE EMPTY VARIABLES
	private GameObject player;
	private Color initialColor;

	public bool displayText;
	public string text = "Greetings, I'm a vase";
	public int dialogCounter = 0;

	// FIND THE OBJECT WITH THE NAME PLAYER AND STORE THE INITIAL COLOR OF THE VASE
	void Start () {
		player = GameObject.FindWithTag("Player");
		initialColor = gameObject.renderer.material.color;
	}

	// IF THE OBJECTS ARE CLOSE AND WE PRESS M, WE START THE DIALOGUE.
	void OnGUI () {
		if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 2.0f && Input.GetKeyUp (KeyCode.E)) {
			++dialogCounter;

			if (dialogCounter == 2) {
				displayText = true;
				text = "Yes I'm a vase";
			} else if (dialogCounter == 4) {
				text = "Fuck vases";
			} else if (dialogCounter == 6) {
				if (!GameInformation.helloWorldDefeated) {
					text = "Prepare to Battle!";
				} else {
					text = "You already defeated me :(";
				}
			} else if (dialogCounter >= 8) {
				Time.timeScale = 1;
				displayText = false;
				if (!GameInformation.helloWorldDefeated) {
					Application.LoadLevel("Battle");
				}
			}

		}

		if (displayText) {
			Time.timeScale = 0;
			GUI.Box (new Rect(10,Screen.height-220,Screen.width-20,200), text);
		}

	}


	//===========//
	// HIGHLIGHT //
	//===========//

	// ON MOUSE OVER, IF THE PLAYER AND THE VASE ARE CLOSE, CHANGE THE COLOR OF THE VASE
	//void OnMouseOver() {
	//	if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 1.0f) {
	//		gameObject.renderer.material.color = new Color(255,255,0);
	//		Debug.Log ("We are close <3");
	//	} else {
	//		Debug.Log ("We are far");
	//	}
	//}

	// ON MOUSE EXIT, RETURN TO THE ORIGINAL COLOR OF THE VASE TO SIMULATE A HIGHLIGHTING SYSTEM
	//void OnMouseExit() {
	//	gameObject.renderer.material.color = initialColor;
	//}
}
