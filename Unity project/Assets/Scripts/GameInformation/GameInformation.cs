using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameInformation : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}

	// LIST OF INFORMATIONS ALWAYS AVAILABLE DURING THE GAME

	// GENERAL
	public static string PlayerName 			 { get; set; }
	public static int PlayerLevel 				 { get; set; }
	public static BaseCharacterClass PlayerClass { get; set; }
	public static bool helloWorldDefeated = false;
	public Slider healthSlider;
	public Text characterLevel;

	// CURRENT POSITION
	public static Vector3 PlayerPosition { get; set; }

	// STATS
	public static int Strength   { get; set; }
	public static int Intellect  { get; set; }
	public static int Stamina 	 { get; set; }
	public static int Speed		 { get; set; }
	public static int Resistance { get; set; }

	// GOLD
	public static int Gold		 { get; set; }

	// XP
	public static int CurrentXP  { get; set; }
	public static int RequiredXP { get; set; }

	// HEALTH (TBD, I DON'T KNOW IF IT MAKES SENSE TO HAVE ONE)
	public static int MaxHealth { get; set; }
	public static int CurrentHealth { get; set; }

	// HEALTH BAR

	void Start(){
		healthSlider.maxValue = GameInformation.MaxHealth;
		healthSlider.value = GameInformation.CurrentHealth;
		characterLevel.text = GameInformation.PlayerLevel.ToString();
	}


}

	
