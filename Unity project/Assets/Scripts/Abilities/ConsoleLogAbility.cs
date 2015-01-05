using UnityEngine;
using System.Collections;

nhfpublic class ConsoleLogAbility : BaseAbility {

	public void ConsoleLog(){
		AbilityName = "Console.log()";
		AbilityDescription = "A basic JavaScript based attack";
		AbilityPower = 1;
		AbilityCost = 0;
		Stat = GameInformation.JavaScript;
	}

}
