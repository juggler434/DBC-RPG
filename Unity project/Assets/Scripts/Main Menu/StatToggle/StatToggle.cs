using UnityEngine;
using System.Collections;

public class StatToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addPointToRuby() {
		if (GameInformation.PointsToAllocate > 0){
			GameInformation.Ruby += 1;
			GameInformation.PointsToAllocate -= 1;
		}
	}

	public void removePointFromRuby(){
		if (GameInformation.Ruby > GameInformation.PlayerClass.Ruby) {
			GameInformation.Ruby -= 1;
			GameInformation.PointsToAllocate +=1;
		}
	}

	public void addPointToJavaScript() {
		if (GameInformation.PointsToAllocate > 0){
			GameInformation.JavaScript += 1;
			GameInformation.PointsToAllocate -= 1;
		}
	}

	public void removePointFromJavaScript(){
		if (GameInformation.JavaScript > GameInformation.PlayerClass.JavaScript) {
			GameInformation.JavaScript -= 1;
			GameInformation.PointsToAllocate +=1;
		}
	}

	public void addPointToSQL() {
		if (GameInformation.PointsToAllocate > 0){
			GameInformation.SQL += 1;
			GameInformation.PointsToAllocate -= 1;
		}
	}
	
	public void removePointFromSQL(){
		if (GameInformation.SQL > GameInformation.PlayerClass.SQL) {
			GameInformation.SQL -= 1;
			GameInformation.PointsToAllocate +=1;
		}
	}

	public void addPointKeyboardShortcuts() {
		if (GameInformation.PointsToAllocate > 0){
			GameInformation.KeyboardShortcuts += 1;
			GameInformation.PointsToAllocate -= 1;
		}
	}
	
	public void removePointFromKeyboardShortcuts(){
		if (GameInformation.KeyboardShortcuts > GameInformation.PlayerClass.KeyboardShortcuts) {
			GameInformation.KeyboardShortcuts -= 1;
			GameInformation.PointsToAllocate +=1;
		}
	}

	public void addPointToSecurity() {
		if (GameInformation.PointsToAllocate > 0){
			GameInformation.Security += 1;
			GameInformation.PointsToAllocate -= 1;
		}
	}
	
	public void removePointFromSecurity(){
		if (GameInformation.Security > GameInformation.PlayerClass.Security) {
			GameInformation.Security -= 1;
			GameInformation.PointsToAllocate +=1;
		}
	}

}
