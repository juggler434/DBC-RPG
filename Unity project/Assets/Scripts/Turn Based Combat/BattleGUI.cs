using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	public static string battleLog = "Prepare for Battle";
	private BattleScripts battleScripts = new BattleScripts();
	public RawImage explosion; 
	public Image red;

	private int battleCounter = 0;

	public void TogglePlayerHit(){
		red.enabled = !red.enabled;
	}

	public void ToggleExplosion(){
		explosion.enabled = !explosion.enabled;
	}


	void Start(){
		ToggleExplosion ();
		TogglePlayerHit ();
	}

	void OnGUI(){
		BattleMainItems ();
		if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.PLAYERCHOICE) {
			BattlePlayerChoice ();
		} else if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.ENEMYCHOICE) {
			BattleEnemyChoice ();
		} else if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.WIN) {
			battleLog = "You won!";	
			GameInformation.helloWorldDefeated = true;
			Application.LoadLevel("Phase0");
		} else if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.LOSE) {
			battleLog = "You lost!";					
		}

	}

	private IEnumerator playerHitWait(){
		TogglePlayerHit ();
		yield return new WaitForSeconds (0.5f);
		TogglePlayerHit ();
	}

	private IEnumerator DisplayExplosion(){
		ToggleExplosion();
		yield return new WaitForSeconds(0.5f);
		ToggleExplosion();

	}

	private IEnumerator SwitchStates(){
		BattleStateMachine.currentState = BattleStateMachine.BattleStates.WAIT;
		yield return new WaitForSeconds (1.0f);
		BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
	}

	private IEnumerator SwitchStatesToPlayer(){
		yield return new WaitForSeconds (1.0f);
		BattleStateMachine.currentState = BattleStateMachine.BattleStates.PLAYERCHOICE;
	}


	public void BattleMainItems() {
		// LOG BOX
		GUI.Box (new Rect(10,Screen.height-210,Screen.width-20,200), battleLog);

	}
	public void BattlePlayerChoice() {

		if (GUI.Button(new Rect(50,200,150,50), GameInformation.PlayerMoveOne.AbilityName)) {
			BattleStateMachine.battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveOne);
			battleLog = "You attack Hello World with " + GameInformation.PlayerMoveOne.AbilityName;
			StartCoroutine(DisplayExplosion());

			if (BattleStateMachine.battleScripts.enemyCurrentHealth > 0){
				StartCoroutine(SwitchStates());
			} else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
			}
		}
		if (GUI.Button(new Rect(50,260,150,50), GameInformation.PlayerMoveTwo.AbilityName)) {
			BattleStateMachine.battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveTwo);
			battleLog = "You attack Hello World with " + GameInformation.PlayerMoveTwo.AbilityName;
			StartCoroutine(DisplayExplosion ());

			if (BattleStateMachine.battleScripts.enemyCurrentHealth > 0){
				StartCoroutine(SwitchStates());
			} else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
			}
		}

		battleCounter = 0;
	}

	public void BattleEnemyChoice() {

		if (battleCounter == 0) {

			if (Random.Range (0,2) == 1) {
				StartCoroutine(playerHitWait());
				BattleStateMachine.battleScripts.RubyAttack ();
				BattleGUI.battleLog = "Hello World Attacks you with Ruby Attack";
			} else {
				StartCoroutine(playerHitWait());
				BattleStateMachine.battleScripts.JavaScriptAttack ();
				BattleGUI.battleLog = "Hello World Attacks you with Javascript Attack";	
			}

			if (BattleStateMachine.battleScripts.playerCurrentHealth > 0){
				StartCoroutine(SwitchStatesToPlayer());
			} else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.LOSE;
			}

			battleCounter = 1;
		}
	}

}
