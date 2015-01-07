using UnityEngine;
using System.Collections;

public class ConsoleLog : BaseAbility {

	public ConsoleLog(){
		AbilityName = "console.log()";
		AbilityDescription = "A basic JavaScript based attack.";
		AbilityID = 2;
		AbilityPower = 1;
		AbilityCost = 0;
		Stat = GameInformation.JavaScript;
	}

}
