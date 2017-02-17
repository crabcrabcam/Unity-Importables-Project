using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Movement for a platformer
/// </summary>
public class ForcePlayerMovement : MonoBehaviour
{

    //Movement variables
    private float speed = 3f;
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
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the functions we make below. Used in here because it's better than fixedUpdate.
        //As long as you use Time.deltaTime when dealing with Physics and movement
		ForceMovement();
        GroundCheck();
    }

	void ForceMovement()
	{
		//Movement axis
		//Get axis raw for the keyboard players because it's better. 
		movex = Input.GetAxisRaw("Horizontal");
		movey = Input.GetAxisRaw("Vertical");

		//Left and right
		//Moves instantly
		if (movex > 0.1)
		{
			//Adds force instantly
			GetComponent<Rigidbody2D>().AddForce(transform.right * speed, mode: ForceMode2D.Impulse);
		}
		if (movex < -0.1)
		{
			//Adds force instantly
			GetComponent<Rigidbody2D>().AddForce(transform.right * -speed, mode: ForceMode2D.Impulse);
		}

		if (grounded)
		{
			//Checks for grounded and they're not moving left or right then they stop. Friction effect. 
			if (movex == 0)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
			}
		}

		//Setting the max speed (velocity)
		float maxVelocity;
		//Changes the speed based on if they're on the ground or in the air and whether they're crouched or not. 
		{
			if (grounded)
			{
				maxVelocity = 6;
			}
			else
			{
				maxVelocity = 8;
			}
		}



		//Makes sure that the player doesn't go over the max velocity. In either direction. 
		if (GetComponent<Rigidbody2D>().velocity.x > maxVelocity)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(maxVelocity, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (GetComponent<Rigidbody2D>().velocity.x < -maxVelocity)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-maxVelocity, GetComponent<Rigidbody2D>().velocity.y);
		}



		//Code for slowing the player down if they're in the air. Because they can't move. 
		if (!grounded)
		{
			if (GetComponent<Rigidbody2D>().velocity.x > 0)
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f, 0), mode: ForceMode2D.Impulse);
			}
			if (GetComponent<Rigidbody2D>().velocity.x < 0)
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0), mode: ForceMode2D.Impulse);
			}
		}
		
		

		//The code for jumping
		//Checks that the player is grounded
		if (movey > 0.1 && grounded)
		{
			//Takes the velocity of the player along the x axis (horisontally) so that the player keeps being able to move in that direction independant of the jump.
			//Adds a velocity equal to the jump height. 
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

	}
    /// <summary>
    /// This function checks to see if the player is grounded
    /// </summary>
    /// <returns>Boolean grounded</returns>
    void GroundCheck()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}