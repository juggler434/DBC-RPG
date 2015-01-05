using UnityEngine;
using System.Collections;

public class TerminalInteraction : MonoBehaviour {
	
	// Empty object for player 
	private GameObject player;
	
	public bool displayText; 
	public string text = "git push origin master";
	public int dialogueCounter = 0;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGui() {
		if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 2.0f && Input.GetKey(KeyCode.E)) {
			++dialogueCounter;
			displayText = true;
			text = "DON'T DO IT!!!";
		}
		
		if(displayText) {
			Time.timeScale = 0;
			GUI.Box (new Rect(10, Screen.height-220, Screen.width-20, 200), text);
		}
	}
}
