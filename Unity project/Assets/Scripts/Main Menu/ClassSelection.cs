using UnityEngine;
using System.Collections;

public class ClassSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChooseFrontEnd(){
		GameInformation.PlayerClass = new FrontEndClass ();
	}

	public void ChooseBackEnd(){
		GameInformation.PlayerClass = new BackEndClass ();
	}

	public void ChooseFullStack(){
		GameInformation.PlayerClass = new FullStackClass ();
	}

	public void SetBaseStats(){
		GameInformation.Ruby = GameInformation.PlayerClass.Ruby;
		GameInformation.JavaScript = GameInformation.PlayerClass.JavaScript;
		GameInformation.SQL = GameInformation.PlayerClass.SQL;
		GameInformation.KeyboardShortcuts = GameInformation.PlayerClass.KeyboardShortcuts;
		GameInformation.Security = GameInformation.PlayerClass.Security;
		
	}

}
