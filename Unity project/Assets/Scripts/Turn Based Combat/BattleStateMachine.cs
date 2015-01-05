using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleStateMachine : MonoBehaviour {

	public Slider playerHealthSlider;
	public Slider enemyHealthSlider;
	public Text playerHealthAmounts;
	public Text enemyHealthAmounts;
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
	public static BattleScripts battleScripts = new BattleScripts();

	void Start () {
		// INITIALIZE THE ENEMY WITH THE STATS
//		battleScripts.InitializeEnemy();

		currentState = BattleStates.START;
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentState){
		case(BattleStates.START):
			battleScripts.BattleStart();
			playerHealthSlider.maxValue = battleScripts.playerMaxHealth;
			enemyHealthSlider.maxValue = battleScripts.enemyMaxHealth;
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
		playerHealthSlider.value = battleScripts.playerCurrentHealth;
		enemyHealthSlider.value = battleScripts.enemyCurrentHealth;
		playerHealthAmounts.text = battleScripts.playerCurrentHealth.ToString () + "/" + battleScripts.playerMaxHealth.ToString ();
		enemyHealthAmounts.text = battleScripts.enemyCurrentHealth.ToString () + "/" + battleScripts.enemyMaxHealth.ToString ();
		

	}


}
