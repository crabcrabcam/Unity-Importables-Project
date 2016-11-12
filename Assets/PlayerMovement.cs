using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpHeight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Movement() {
		if (Input.GetAxis("Horizontal") != 0) {
			print ("This worked");
		}
	}
}
