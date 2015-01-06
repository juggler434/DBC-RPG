using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	public static string battleLog = "Prepare for Battle";
	private BattleScripts battleScripts = new BattleScripts();
	public RawImage explosion; 
	public Image red;

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

	void Update(){

	}

	void OnGUI(){
		BattleMainItems ();
		if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.PLAYERCHOICE) {
				BattlePlayerChoice ();
		} else if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.ENEMYCHOICE) {
			BattleEnemyChoice ();
		} else if (BattleStateMachine.currentState == BattleStateMachine.BattleStates.WIN) {
			battleLog = "You have Won";				
		}

	}

	private IEnumerator playerHitWait(){
		TogglePlayerHit ();
		yield return new WaitForSeconds (0.5f);
		TogglePlayerHit ();
		}

	private IEnumerator Wait(){
		ToggleExplosion();
		yield return new WaitForSeconds(0.5f);
		ToggleExplosion();

	}

	private IEnumerator PlayerAttack(){
		BattleStateMachine.battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveOne);
		StartCoroutine (Wait ());
		yield return new WaitForSeconds (1);
	}

	private IEnumerator EnemyRubyAttack(){
		BattleStateMachine.battleScripts.RubyAttack ();
		yield return new WaitForSeconds (1);
	}

	private IEnumerator SwitchStates(){
		yield return new WaitForSeconds (1.5f);
		BattleStateMachine.currentState = BattleStateMachine.BattleStates.ENEMYCHOICE;
		}


	public void BattleMainItems() {
		// LOG BOX
		GUI.Box (new Rect(10,Screen.height-210,Screen.width-20,200), battleLog);

	}
	public void BattlePlayerChoice() {
		// DISPLAY BUTTONS OF THE ATTACKS
		if (GUI.Button(new Rect(50,200,150,50), GameInformation.PlayerMoveOne.AbilityName)) {
			BattleStateMachine.battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveOne);
			battleLog = "You attack Hello World with " + GameInformation.PlayerMoveOne.AbilityName;
			StartCoroutine(Wait());

			if(BattleStateMachine.battleScripts.enemyCurrentHealth > 0){
				StartCoroutine(SwitchStates());
			}else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
			}
		}
		if (GUI.Button(new Rect(50,260,150,50), GameInformation.PlayerMoveTwo.AbilityName)) {
			BattleStateMachine.battleScripts.enemyCurrentHealth -= battleScripts.CalculateDamage(GameInformation.PlayerMoveTwo);
			battleLog = "You attack Hello World with " + GameInformation.PlayerMoveTwo.AbilityName;
			StartCoroutine(Wait ());
			if(BattleStateMachine.battleScripts.enemyCurrentHealth > 0){
				StartCoroutine(SwitchStates());
			}else {
				BattleStateMachine.currentState = BattleStateMachine.BattleStates.WIN;
			}
		}
		// IF THE PLAYER CLICKS ON ONE BUTTON, FIRE THE CORRESPONDING ATTACK FUNCTION
		// IF THE ENEMY HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO WIN
	}

	public void BattleEnemyChoice() {
		// DISPLAY NON-CLICKABLE BUTTONS OF THE ATTACKS
		GUI.Button(new Rect(Screen.width-250,200,150,50), "Strength Attack");
		GUI.Button(new Rect(Screen.width-250,260,150,50), "Intellect Attack");
		
		if (Random.Range (0,2) == 1) {
			StartCoroutine(playerHitWait());
			BattleStateMachine.battleScripts.RubyAttack ();
			BattleGUI.battleLog = "Hello World Attacks you with wefwef";
	
		} else {
			StartCoroutine(playerHitWait());
			BattleStateMachine.battleScripts.RubyAttack ();
			BattleGUI.battleLog = "Hello World Attacks you with wegewg";


		}
		// DECIDE (RANDOMLY FOR NOW) WHICH ATTACK TO PERFORM AND FIRE THE CORRESPONDING ATTACK FUNCTION
		// IF THE PLAYER HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO LOSE
	}

}
