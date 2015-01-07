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

}
