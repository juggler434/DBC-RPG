using UnityEngine;
using System.Collections;

public class ColorTest : MonoBehaviour {


	public Texture2D myTexture; 
	// Use this for initialization
	void Start () {
		gameObject.renderer.material.mainTexture = myTexture;

		gameObject.renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
