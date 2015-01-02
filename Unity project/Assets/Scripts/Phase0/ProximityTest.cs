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
		if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 1.0f && Input.GetKeyUp (KeyCode.M)) {
			displayText = true;
		}

		if (displayText) {
			Time.timeScale = 0;
			GUI.Box (new Rect(10,Screen.height-220,Screen.width-20,200), text);
		}

		// BUGBUG: THE COUNTER IS GOING UP BY TWO INSTEAD OF ONE.
		if (displayText && Input.GetKeyUp(KeyCode.Return)) {
			++dialogCounter;
			if (dialogCounter == 2) {
				text = "Yes I'm a vase";
			} else if (dialogCounter == 4) {
				text = "Fuck vases";
			} else if (dialogCounter == 6) {
				text = "Prepare to Battle!";
			} else if (dialogCounter >= 8) {
				Time.timeScale = 1;
				displayText = false;
				Application.LoadLevel("Battle");
			}
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
