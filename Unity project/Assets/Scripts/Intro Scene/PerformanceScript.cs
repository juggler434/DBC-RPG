using UnityEngine;
using System.Collections;

public class PerformanceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyTree", 10.0f);
	}
	
	void DestroyTree() {
		Destroy (gameObject);
	}
}
