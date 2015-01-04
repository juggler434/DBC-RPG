using UnityEngine;
using System.Collections;

public class BasePlayer {

	// NAME
	private string playerName;
	// LEVEL
	private int playerLevel;
	// CLASS
	private BaseCharacterClass playerClass;

	// STATS
	private int ruby;
	private int javaScript;
	private int sQL;
	private int keboardShortcuts;
	private int security;
	// STAT POINTS
	private int statPointsToAllocate;

	// XP
	private int currentXP;
	private int requiredXP;

	// GETTERS AND SETTERS

	public string PlayerName { get; set; }
	public int PlayerLevel { get; set; }
	public BaseCharacterClass PlayerClass { get; set; }

	public int Ruby 	{ get; set; }
	public int JavaScript 	{ get; set; }
	public int SQL 		{ get; set; }
	public int KeyboardShortCuts 		{ get; set; }
	public int Security 	{ get; set; }

	public int StatPointsToAllocate { get; set; }

	public int CurrentXP 	{ get; set; }
	public int RequiredXP 	{ get; set; }
	
}
