using UnityEngine;
using System.Collections;

public class ConsoleLogAbility : BaseAbilitiy {

	public void ConsoleLog(){
		AbilityName = "Console.log()";
		AbilityDescription = "A basic JavaScript based attack";
		AbilityPower = 1;
		AbilityCost = 0;
		Stat = GameInformation.JavaScript;
	}

}
