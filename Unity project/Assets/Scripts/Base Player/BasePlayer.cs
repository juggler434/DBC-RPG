using UnityEngine;
using System.Collections;

public class BasePlayer {

	// NAME
	private string playerName;
	// LEVEL
	private string playerLevel;
	// CLASS
	private BaseCharacterClass playerClass;

	// STATS
	private int strength;
	private int intellect;
	private int stamina;
	private int speed;
	private int resistance;
	// STAT POINTS
	private int statPointsToAllocate;

	// XP
	private int currentXP;
	private int requiredXP;

	// GETTERS AND SETTERS

	public string PlayerName { get; set; }
	public string PlayerLevel { get; set; }
	public BaseCharacterClass PlayerClass { get; set; }

	public int Strength 	{ get; set; }
	public int Intellect 	{ get; set; }
	public int Stamina 		{ get; set; }
	public int Speed 		{ get; set; }
	public int Resistance 	{ get; set; }

	public int StatPointsToAllocate { get; set; }

	public int CurrentXP 	{ get; set; }
	public int RequiredXP 	{ get; set; }
	
}
