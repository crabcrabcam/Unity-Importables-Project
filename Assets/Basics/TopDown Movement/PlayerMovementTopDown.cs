using UnityEngine;
using System.Collections;

/// <summary>
/// This is the playermovement script for top down movement. It's based on turning rather than flipping.
/// This can also be used for top down racing games if you tune the sensitivity
/// </summary>
public class PlayerMovementTopDown : MonoBehaviour
{

    //The x and y axis. This is for reading things. 
    public float axisx;
    public float axisy;
    //The turn speed and movement speed. This is for how fast or slow to turn and move the player. 
    public float speed;
    public float turnSpeed;

    /// <summary>
    /// What to do when the script loads
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once a frame. It's called as fast as possible and isn't a stable rate of calling. 
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Called at a fixed rate interval meaning it's steady. This is the tickrate
    /// </summary>
    void FixedUpdate()
    {
        //Calls the movement function. 
        Movement();
    }

    /// <summary>
    /// The function that controlls the movement
    /// </summary>
    void Movement()
    {

        //The axis inputs. From 1 -> 0 -> -1
        //Buttons will be either 1, 0, or -1 whilst joysticks can be anywhere in between
        axisx = Input.GetAxis("Horizontal");
        axisy = Input.GetAxis("Vertical");

        //Turns the player right
        if (axisx > 0.1)
        {
            transform.Rotate(Vector3.back * turnSpeed * axisx);
        }
        //Turns the player left
        if (axisx < -0.1)
        {
            transform.Rotate(Vector3.forward * turnSpeed * -axisx);
        }
        //Moves the player forward
        if (axisy > 0.1)
        {
            transform.position += transform.up * speed * axisy;
        }
        //Moves the player backwards
        else if (axisy < -0.1)
        {
            //moves the player backwards at half speed because they're going backwards
            transform.position += transform.up * (speed / 2) * axisy;
        }
    }
}