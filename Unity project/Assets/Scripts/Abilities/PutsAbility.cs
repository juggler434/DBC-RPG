using UnityEngine;
using System.Collections;

public class PutsAbility : BaseAbilitiy {

	public void RubyAttack(){
		AbilityName = "Puts";
		AbilityDescription = "A basic Ruby based attack.";
		AbilityID = 1;
		AbilityPower = 1;
		AbilityCost = 0;
		Stat = GameInformation.Ruby;
	}
}
