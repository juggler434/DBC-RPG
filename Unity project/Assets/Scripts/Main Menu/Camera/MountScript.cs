using UnityEngine;
using System.Collections;

public class MountScript : MonoBehaviour {

	public Transform currentMount;
	public float speedFactor = 0.1f;
	public GameObject perspectiveCanvas;


	private Vector3 lastPosition;

	
	// Use this for initialization
	void Start () {
		lastPosition = transform.position;
		perspectiveCanvas = GameObject.FindWithTag("NewGameCanvas");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, currentMount.position, speedFactor);
		transform.rotation = Quaternion.Slerp (transform.rotation, currentMount.rotation, speedFactor);
	}

	public void setMount(Transform newMount) {
		perspectiveCanvas.SetActive (false);
		currentMount = newMount;
	}
	

}
