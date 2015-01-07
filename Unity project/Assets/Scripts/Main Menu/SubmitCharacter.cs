using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubmitCharacter : MonoBehaviour {

	public InputField name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private int calcHealth() {
		return GameInformation.Security * 10;
		}

	public void sumbit() {
		GameInformation.MaxHealth = calcHealth();
		GameInformation.PlayerName = name.text;
		Application.LoadLevel ("Phase0");

		}
}
