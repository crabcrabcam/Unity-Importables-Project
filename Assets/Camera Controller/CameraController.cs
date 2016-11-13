using UnityEngine;
using System.Collections;

/// <summary>
/// This is a camera controller that is built to work well with platformers
/// You can use this on any object, but it's made for the camera.
/// </summary>
public class CameraController : MonoBehaviour {

	//Set the follow target to what you want the camera to follow
	public GameObject followTarget;
	//The targetPos is what we use internally to tell the camera where to go
	private Vector3 targetPos;
	//The offset lets you change if you want the target infront or behind the camera
	public Vector3 offset;
	//The speed can be set to 0 to stop the camera
	//To do this you need to set the float to public (to change it from outside of this script.)
	private float speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveCamera ();
	}

	void MoveCamera() {

		//This sets the target position (where to go to) to where the followTarget is.
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		//This sets the camera (or the object this is attached to really) to move (Lerp) towards the position of the target + the offset. 
		//The offset lets you say I want the character to be behind the centre of the camera, or infront of it. Change this in code depending on what you want
		//Or the direction of the character.
		transform.position = Vector3.Lerp (transform.position, targetPos + offset, speed);
	}

}
