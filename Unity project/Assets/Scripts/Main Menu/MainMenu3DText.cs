using UnityEngine;
using System.Collections;

// TEST. NOT WORKING

public class MainMenu3DText : MonoBehaviour {

	private GameObject mainMenuText;
	private Vector3 vektor = new Vector3 (0, 40, 0);

	// Use this for initialization
	void Start () {
		mainMenuText = GameObject.FindWithTag("MainText");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0))StartCoroutine(LerpMyGuy());
	}

	void OnMouseOver() {
		Debug.Log ("Over");
		mainMenuText.renderer.material.color = new Color(255,0,0);
	}

	void OnMouseExit() {
		Debug.Log ("Exit");
		mainMenuText.renderer.material.color = new Color(255,255,255);
	}

	IEnumerator LerpMyGuy(){
		// Start a while loop to run 
		// as long as object is not at target
		int lerpfactor = 0;
		while(lerpfactor < 1.0f)
		{
			// Do the movement
			Camera.main.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(-10f, 10f, lerpfactor), 0);
			//Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, vektor, Time.deltaTime * 2.0f);
			// Leave the coroutine at this point
			// It will start from there next frame
			yield return null;
			// Then it gets back on top of the loop for the check
		}
	}

}
