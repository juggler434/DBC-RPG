using UnityEngine;
using System.Collections;

public class finalLevelScript : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 2.0f && Input.GetKeyUp (KeyCode.E)) {
			AutoFade.LoadLevel("Presentation",1,1,Color.white);
		}
	}
}
