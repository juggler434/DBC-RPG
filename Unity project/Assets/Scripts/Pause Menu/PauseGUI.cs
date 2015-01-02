using UnityEngine;
using System.Collections;

public class PauseGUI : MonoBehaviour {

	private bool isPaused = false;
	private GameObject firstPersonControllerCamera;

	// Use this for initialization
	void Start () {
		Debug.Log ("Doge");
	}


	void OnGUI () {
		if (Input.GetKeyUp (KeyCode.P)) {
			isPaused = true;
		}
		
		if (isPaused) {
			Time.timeScale = 0;

			Unpause (false);

			GUI.Box (new Rect(0,0,Screen.width,Screen.height), "Pause");
		}

		if (isPaused && Input.GetKeyUp(KeyCode.Return)) {
			Time.timeScale = 1;

			isPaused = false;

			Unpause (true);
		}
	}

	private void Unpause(bool paused) {
		GameObject FPC = GameObject.FindWithTag("Player");
		GameObject FPCCamera = GameObject.FindWithTag("MainCamera");
		
		FPC.GetComponent<MouseLook>().enabled = paused;
		FPCCamera.GetComponent<MouseLook>().enabled = paused;
	}
}
