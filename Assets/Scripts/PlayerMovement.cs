using UnityEngine;
using System.Collections;

/// <summary>
/// Movement for a platformer
/// </summary>
public class PlayerMovement : MonoBehaviour {

	//Movement variables
	private float speed = 5;
	private float jumpHeight = 10;
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
		Movement ();
		GroundCheck ();
	}

	void Movement() {

		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");


		transform.position += transform.right * movex * speed * Time.deltaTime;

		if (movex == 0 && grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}

//		GetComponent<Rigidbody2D> ().velocity = new Vector2 (movex * speed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);

		if (movey > 0.1 && grounded) {
			print ("jump");
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}
	}

	void GroundCheck() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
}
