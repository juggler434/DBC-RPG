using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleScripts {

	private BasePlayer enemy = new BasePlayer();

	public int playerMaxHealth = GameInformation.MaxHealth;
	public int playerCurrentHealth = GameInformation.CurrentHealth;
	private int enemyHealth;
	private string battleLog = "Default value, change it, doge";

	public void InitializeEnemy() {
		// Hardcoded enemy name for now. Maybe we can save the name in GameInformation when we interact with the NPC using the script attached to it.
		enemy.PlayerName = "Your enemy";
		enemy.PlayerLevel = Random.Range (GameInformation.PlayerLevel, GameInformation.PlayerLevel + 2);
		// ENEMY STATS
		enemy.Strength = 10;
		enemy.Intellect = 10;
		enemy.Stamina = 10;
		enemy.Speed = 10;
		enemy.Resistance = 10;
		// ENEMY HP
		enemyHealth = enemy.Stamina * 100;
	}

	public void BattleMainItems() {
		// PLAYER
		GUI.Label (new Rect(50,50,200,50), GameInformation.PlayerName);
		GUI.Label (new Rect(50,100,200,50), "Health: " + playerCurrentHealth.ToString());

		// ENEMY
		GUI.Label (new Rect(Screen.width-250,50,200,50), enemy.PlayerName);
		GUI.Label (new Rect(Screen.width-250,100,200,50), "Health: " + enemyHealth.ToString());

		// LOG BOX
		GUI.Box (new Rect(10,Screen.height-210,Screen.width-20,200), battleLog);

	}

	public void BattleStart() {
		Debug.Log(GameInformation.helloWorldDefeated);
		// DECIDE WHO IS GOING FIRST
		if (GameInformation.Speed >= enemy.Speed) {
			BattleGUI.currentState = BattleGUI.BattleStates.PLAYERCHOICE;
		} else {
			BattleGUI.currentState = BattleGUI.BattleStates.ENEMYCHOICE;
		}
	}

	public void BattlePlayerChoice() {
		// DISPLAY BUTTONS OF THE ATTACKS
		if (GUI.Button(new Rect(50,200,150,50), "Strength Attack")) {
			StrengthAttack();
		}
		if (GUI.Button(new Rect(50,260,150,50), "Intellect Attack")) {
			IntellectAttack();
		}
		// IF THE PLAYER CLICKS ON ONE BUTTON, FIRE THE CORRESPONDING ATTACK FUNCTION
		// IF THE ENEMY HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO WIN
	}

	public void BattleEnemyChoice() {
		// DISPLAY NON-CLICKABLE BUTTONS OF THE ATTACKS
		GUI.Button(new Rect(Screen.width-250,200,150,50), "Strength Attack");
		GUI.Button(new Rect(Screen.width-250,260,150,50), "Intellect Attack");

		if (Random.Range (0,2) == 1) {
			StrengthAttack();
		} else {
			IntellectAttack();
		}
		// DECIDE (RANDOMLY FOR NOW) WHICH ATTACK TO PERFORM AND FIRE THE CORRESPONDING ATTACK FUNCTION
		// IF THE PLAYER HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO LOSE
	}

	public void BattleWin() {
		battleLog = "You Won!";
		GameInformation.helloWorldDefeated = true;
		Debug.Log (GameInformation.helloWorldDefeated);
		Application.LoadLevel("Phase0");
	}

	public void BattleLose() {
		battleLog = "You Lose!";
		Application.LoadLevel("Phase0");
	}

	//==================//
	// HELPER FUNCTIONS //
	//==================//

	private void StrengthAttack() {
		if (BattleGUI.currentState == BattleGUI.BattleStates.PLAYERCHOICE) {
			// CALCULATE DAMAGE AND SUBTRACT HP
			int calcDamage = GameInformation.Strength * Random.Range (8,12);
			enemyHealth -= calcDamage;
			// IF THE ENEMY HEALTH IS 0, WIN, OTHERWISE, ENEMYCHOICE
			if (enemyHealth > 0) {
				BattleGUI.currentState = BattleGUI.BattleStates.ENEMYCHOICE;
			} else {
				BattleGUI.currentState = BattleGUI.BattleStates.WIN;
			}
		} else if (BattleGUI.currentState == BattleGUI.BattleStates.ENEMYCHOICE) {
			// CALCULATE DAMAGE AND SUBTRACT HP
			int calcDamage = enemy.Strength * Random.Range (8,12);
			playerCurrentHealth -= calcDamage;
			// IF THE PLAYER HEALTH IS 0, LOSE, OTHERWISE, PLAYERCHOICE
			if (playerCurrentHealth > 0) {
				BattleGUI.currentState = BattleGUI.BattleStates.PLAYERCHOICE;
			} else {
				BattleGUI.currentState = BattleGUI.BattleStates.LOSE;
			}
		} 
	}

	private void IntellectAttack() {
		if (BattleGUI.currentState == BattleGUI.BattleStates.PLAYERCHOICE) {
			// CALCULATE DAMAGE AND SUBTRACT HP
			int calcDamage = GameInformation.Intellect * Random.Range (7,13);
			enemyHealth -= calcDamage;
			// IF THE ENEMY HEALTH IS 0, WIN, OTHERWISE, ENEMYCHOICE
			if (enemyHealth > 0) {
				BattleGUI.currentState = BattleGUI.BattleStates.ENEMYCHOICE;
			} else {
				BattleGUI.currentState = BattleGUI.BattleStates.WIN;
			}
		} else if (BattleGUI.currentState == BattleGUI.BattleStates.ENEMYCHOICE) {
			// CALCULATE DAMAGE AND SUBTRACT HP
			int calcDamage = enemy.Intellect * Random.Range (7,13);
			playerCurrentHealth -= calcDamage;
			// IF THE PLAYER HEALTH IS 0, LOSE, OTHERWISE, PLAYERCHOICE
			if (playerCurrentHealth > 0) {
				BattleGUI.currentState = BattleGUI.BattleStates.PLAYERCHOICE;
			} else {
				BattleGUI.currentState = BattleGUI.BattleStates.LOSE;
			}
		} 
	}


}
