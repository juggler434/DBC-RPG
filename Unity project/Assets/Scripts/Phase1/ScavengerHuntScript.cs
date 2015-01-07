using UnityEngine;
using System.Collections;

public class ScavengerHuntScript : MonoBehaviour {

	private GameObject player;
	private bool displayText;
	private string text;
	private int gameCounter;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 2.0f && Input.GetKeyUp (KeyCode.E)) {
			++gameCounter;
			
			if (gameCounter == 2) {
				displayText = true;
				if (gameObject.tag == "Cup") {
					text = "You've collected the Cup! +1 SECURITY";
					Phase1Information.cupCollected = true;
					++GameInformation.Security; 
					Debug.Log (GameInformation.Security);
					Invoke ("DestroyObject",0.01f);
					Invoke ("SetTextToFalse",2.0f);
				} else if (gameObject.tag == "Book") {
					text = "You've collected the Book! +1 SQL";
					Phase1Information.bookCollected = true;
					++GameInformation.SQL; 
					Invoke ("DestroyObject",0.01f);
					Invoke ("SetTextToFalse",2.0f);
				} else if (gameObject.tag == "Laptop") {
					text = "You've collected the Laptop! +1 KEYBOARD SHORTCUTS";
					Phase1Information.laptopCollected = true;
					++GameInformation.KeyboardShortcuts; 
					Invoke ("DestroyObject",0.01f);
					Invoke ("SetTextToFalse",2.0f);
				}
			} 
			
		}
		
		if (displayText) {
			GUI.Box (new Rect(10,Screen.height-220,Screen.width-20,200), text);
		}
		
	}

	void DestroyObject() {
		//WE PRETEND TO DESTROY THE OBJECT BECAUSE WE STILL NEED THE SCRIPT ATTACHED TO IT.
		gameObject.transform.position = new Vector3 (0, 100, 0);
	}

	void SetTextToFalse() {
		displayText = false;
		gameCounter = 0;
	}

}
