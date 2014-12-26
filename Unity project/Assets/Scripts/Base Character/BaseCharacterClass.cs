using UnityEngine;
using System.Collections.Generic;

public class BaseCharacterClass {

	// NAME AND DESCRIPTION
	private string characterClassName;
	private string characterClassDescription;

	// STATS
	private int strength;
	private int intellect;
	private int stamina;
	private int speed;
	private int resistance;

	// GETTERS AND SETTERS

	// NAME AND DESCRIPTION
	public string CharacterClassName { get; set; }
	public string CharacterClassDescription { get; set; }
	// STATS
	public int Strength { get; set; }
	public int Intellect { get; set; }
	public int Stamina { get; set; }
	public int Speed { get; set; }
	public int Resistance { get; set; }
	
}