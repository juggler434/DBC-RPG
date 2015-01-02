using UnityEngine;
using System.Collections;

public class BattleGUI : MonoBehaviour {

	// STATE MACHINE
	public enum BattleStates {
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		CALCDAMAGE,
		LOSE,
		WIN
	}

	public static BattleStates currentState;
	private BattleScripts battleScripts = new BattleScripts();

	void Start () {
		// INITIALIZE THE ENEMY WITH THE STATS
		battleScripts.InitializeEnemy();

		currentState = BattleStates.START;
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentState){
		case(BattleStates.START):
			break;
		case(BattleStates.PLAYERCHOICE):
			break;
		case(BattleStates.ENEMYCHOICE):
			break;
		case(BattleStates.CALCDAMAGE):
			break;
		case(BattleStates.LOSE):
			break;
		case(BattleStates.WIN):
			break;
		}
	}

	void OnGUI() {
		// DISPLAY ITEMS THAT WILL BE FIXED DURING THE BATTLE
		battleScripts.BattleMainItems();

		// DISPLAY CUSTOM ITEMS THAT WILL CHANGE DEPENDING ON THE BATTLE STATE
		if (currentState == BattleStates.START) {
			battleScripts.BattleStart();
		} else if (currentState == BattleStates.PLAYERCHOICE) {
			battleScripts.BattlePlayerChoice();
		} else if (currentState == BattleStates.ENEMYCHOICE) {
			battleScripts.BattleEnemyChoice();
		} else if (currentState == BattleStates.CALCDAMAGE) {

		} else if (currentState == BattleStates.LOSE) {
			battleScripts.BattleLose();
		} else if (currentState == BattleStates.WIN) {
			battleScripts.BattleWin();
		}
	}
}
