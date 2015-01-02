using UnityEngine;
using System.Collections;

public class BattleScripts {

	private BasePlayer enemy = new BasePlayer();

	private int playerHealth = GameInformation.Stamina * 100;
	private int enemyHealth;

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
		GUI.Label (new Rect(50,100,200,50), "Health: " + playerHealth.ToString());

		// ENEMY
		GUI.Label (new Rect(Screen.width-250,50,200,50), enemy.PlayerName);
		GUI.Label (new Rect(Screen.width-250,100,200,50), "Health: " + enemyHealth.ToString());

		// LOG BOX
		GUI.Box (new Rect(10,Screen.height-210,Screen.width-20,200), "Store this text into a variable to change it in the future.");

	}

	public void BattleStart() {
		// DECIDE WHO IS GOING FIRST
		if (GameInformation.Speed >= enemy.Speed) {
			BattleGUI.currentState = BattleGUI.BattleStates.PLAYERCHOICE;
		} else {
			BattleGUI.currentState = BattleGUI.BattleStates.ENEMYCHOICE;
		}
	}

	public void BattlePlayerChoice() {
		// DISPLAY BUTTONS OF THE ATTACKS
		GUI.Button(new Rect(50,200,150,50), "Strength Attack");
		GUI.Button(new Rect(50,260,150,50), "Intellect Attack");
		// IF THE PLAYER CLICKS ON ONE BUTTON, FIRE THE CORRESPONDING ATTACK FUNCTION
		// IF THE ENEMY HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO WIN
	}

	public void BattleEnemyChoice() {
		// DISPLAY NON-CLICKABLE BUTTONS OF THE ATTACKS
		GUI.Button(new Rect(Screen.width-250,200,150,50), "Strength Attack");
		GUI.Button(new Rect(Screen.width-250,260,150,50), "Intellect Attack");
		// DECIDE (RANDOMLY FOR NOW) WHICH ATTACK TO PERFORM AND FIRE THE CORRESPONDING ATTACK FUNCTION
		// IF THE PLAYER HAS ENOUGH HP THEN SWITCH STATE TO ENEMY CHOICE, ELSE SWITCH TO LOSE
	}

}
