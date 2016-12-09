using UnityEngine;
using System.Collections;

/// <summary>
/// Movement for a platformer
/// </summary>
public class PlayerMovement : MonoBehaviour {

	//Movement variables
	private float speed = 5;
	private float jumpHeight = 10;
	//The movex and Movey variables are to make the code easier to read
	public float movex;
	public float movey;

	//Ground variables
	private bool grounded;
	public float groundCheckRadius = 0.1f;
	public LayerMask whatIsGround;
	public Transform groundCheck;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Calling the functions we make below. Used in here because it's better than fixedUpdate.
		//As long as you use Time.deltaTime when dealing with Physics and movement
		Movement ();
		GroundCheck ();
	}

	/// <summary>
	/// The movement fucntion
	/// </summary>
	void Movement() {

		//Makes the code easier to read by shortening the variables. Also allows for easier changes to be made from outside this script.
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");

		//Makes the movement horisontally. This make the character go right, but if the movex variable is negative, then the character goes left
		//* time.deltaTime is because the player needs to be consistent and not move differently depending on the framerate. 
		transform.position += transform.right * movex * speed * Time.deltaTime;

		//Checks that the player is grounded.
		if (movex == 0 && grounded) {
			//If the player is grounded and they're not being told to move then stop them so that they don't feel like they're on ice. 
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}

		//The code for jumping
		//Checks that the player is grounded
		if (movey > 0.1 && grounded) {
			//Takes the velocity of the player along the x axis (horisontally) so that the player keeps being able to move in that direction independant of the jump.
			//Adds a velocity equal to the jump height. 
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}
	}

	/// <summary>
	/// This function checks to see if the player is grounded
	/// </summary>
	/// <returns>Boolean grounded</returns>
	void GroundCheck() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
}
