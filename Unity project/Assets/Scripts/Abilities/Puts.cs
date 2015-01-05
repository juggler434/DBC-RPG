using UnityEngine;
using System.Collections;

[System.Serializable]
public class Puts : BaseAbility {

	public Puts(){
		AbilityName = "puts";
		AbilityDescription = "A basic Ruby based attack";
		AbilityID = 1;
		AbilityPower = 1;
		AbilityCost = 0;
		Stat = GameInformation.Ruby;
	}

}
