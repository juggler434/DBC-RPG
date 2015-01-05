using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	private string battleLog = "Prepare for Battle";
	private BattleScripts battleScripts = new BattleScripts();
	public RawImage explosion; 

	public void ToggleExplosionOn(){
		explosion.enabled = explosion.enabled;
		}

	public void ToggleExplosionOff(){
		explosion.enabled = !explosion.enabled;
	}
	
	void Start(){
		ToggleExplosionOff ();
	}

	void Update(){

	}

	void OnGUI(){
		BattleMainItems ();
		if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.PLAYERCHOICE) {
			BattlePlayerChoice ();
		}else if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.ENEMYCHOICE){
			BattleStateMachine.battleScripts.BattleEnemyChoice ();
		}

	}

	private IEnumerator Wait(){
		ToggleExplosionOff();
		yield return new WaitForSeconds(2);
		ToggleExplosionOff();
	}



	public void BattleMainItems() {
		// LOG BOX
		GUI.Box (new Rect(10,Screen.height-210,Screen.width-20,200), battleLog);

	}
	public void BattlePlayerChoice() {
		// DISPLAY BUTTONS OF THE ATTACKS
		if (GUI.Button(new Rect(50,200,150,50), GameInformation.PlayerMoveOne.AbilityName)) {
//			battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveOne);

//			ToggleExplosionOn();
			BattleStateMachine.battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveOne);
			StartCoroutine(Wait());
//			System.Threading.Thread.Sleep(1000);
//			ToggleExplosionOff();
			if(BattleStateMachine.battleScripts.enemyCurrentHealth > 0){
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
			}else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
			}
		}
		if (GUI.Button(new Rect(50,260,150,50), GameInformation.PlayerMoveTwo.AbilityName)) {
			BattleStateMachine.battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveTwo);
			if(BattleStateMachine.battleScripts.enemyCurrentHealth > 0){
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
			}else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
			}
		}
		// IF THE PLAYER CLICKS ON ONE BUTTON, FIRE THE CORRESPONDING ATTACK FUNCTION
		// IF THE ENEMY HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO WIN
	}

}
