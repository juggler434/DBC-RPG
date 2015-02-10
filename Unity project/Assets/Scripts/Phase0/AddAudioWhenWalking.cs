using UnityEngine;
using System.Collections;

public class AddAudioWhenWalking : MonoBehaviour {

	public AudioClip walkSound;

	void Start() {
		  
	}

	void Update() {
		PlaySound();
	}
	
	void PlaySound () {
		if (Input.GetButtonDown ("Vertical")){
			audio.Play();
		} else if (Input.GetButtonUp ("Vertical")){
			audio.Stop();
		}
	}
}
