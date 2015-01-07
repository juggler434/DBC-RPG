using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatDisplay : MonoBehaviour {

	public Text rubyStat;
	public Text javaStat;
	public Text sQLStat;
	public Text keyboardShortStat;
	public Text securityStat;
	public Text pointsToAllocate;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		rubyStat.text = GameInformation.Ruby.ToString();
		javaStat.text = GameInformation.JavaScript.ToString();
		sQLStat.text = GameInformation.SQL.ToString();
		keyboardShortStat.text = GameInformation.KeyboardShortcuts.ToString();
		securityStat.text = GameInformation.Security.ToString();
		pointsToAllocate.text = GameInformation.PointsToAllocate.ToString ();
	}


}
