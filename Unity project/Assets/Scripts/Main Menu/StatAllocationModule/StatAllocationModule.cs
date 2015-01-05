using UnityEngine;
using System.Collections;

public class StatAllocationModule {
	
	private string[] statNames = new string[5] {"Ruby", "JavaScript", "SQL", "Keyboard Shortcuts", "Security"};
	private int statPointsToAllocate = 5;

	public int[] pointsToAllocate = new int[5];
	private int[] baseStatPoints = new int[5];
	
	public bool didRunOnce = false;

	public void DisplayStatAllocation() {
		if (!didRunOnce) {
			RetrieveStatBasePoints();
			didRunOnce = true;
		}
		DisplayStatValues();
		DisplayStatIncreaseDecreaseButtons();
	}

	// NEEDS REFACTORING
	private void RetrieveStatBasePoints() {
		// WE CAN CALL PLAYERCLASS BECAUSE WE STORED THE INFORMATION IN THE PREVIOUS STATE
		BaseCharacterClass cClass = GameInformation.PlayerClass;
		
		pointsToAllocate[0] = cClass.Ruby;
		baseStatPoints[0] = cClass.Ruby;
		
		pointsToAllocate[1] = cClass.JavaScript;
		baseStatPoints[1] = cClass.JavaScript;
		
		pointsToAllocate[2] = cClass.SQL;
		baseStatPoints[2] = cClass.SQL;
		
		pointsToAllocate[3] = cClass.KeyboardShortcuts;
		baseStatPoints[3] = cClass.KeyboardShortcuts;

		pointsToAllocate[4] = cClass.Security;
		baseStatPoints[4] = cClass.Security;
	}

	private void DisplayStatValues() {
		for (int i = 0; i < statNames.Length; i++) {
			GUI.Label (new Rect (50,100 + 50*i,100,40), statNames[i]);
			GUI.Label (new Rect (150,100 + 50*i,100,40), pointsToAllocate[i].ToString());
		}
	}

	// TODO
	// CREATE A FUNCTION THAT DISPLAYS THE BUTTONS TO INCREASE/DECREASE STATS
	// BUTTONS ARE ACTIVE ONLY IF IT IS POSSIBLE TO ALLOCATE POINTS
	// PUT A LIVE COUNT OF THE AVAILABLE POINTS TO ALLOCATE
	private void DisplayStatIncreaseDecreaseButtons() {
		for(int i = 0; i < pointsToAllocate.Length; i++) {
			if (pointsToAllocate[i] >= baseStatPoints[i] && statPointsToAllocate > 0) {
				if(GUI.Button (new Rect(200,90 + 50*i,50,50), "+")) {
					pointsToAllocate[i] += 1;
					--statPointsToAllocate;
				}
			}
			if (pointsToAllocate[i] > baseStatPoints[i]) {
				if(GUI.Button (new Rect(260,90 + 50*i,50,50), "-")) {
					pointsToAllocate[i] -= 1;
					++statPointsToAllocate;
				}
			}
		}
	}
}
