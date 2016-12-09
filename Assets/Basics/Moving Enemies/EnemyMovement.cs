using UnityEngine;
using System.Collections;


/// <summary>
/// This is the code to make the enemy move
/// They will move left and right for the amount of time you specify. 
/// They will go through blocks so just make sure they don't. 
/// 
/// </summary>
public class EnemyMovement : MonoBehaviour
{

    //Time to move for
    public float timeToMoveFor;
    public float speed;

    //The time the player has moved for
    private int timeMoved = 0;

    //The direction of movement. True for left and false for right. Better than a string or a number
    public bool movingLeft;


    // Use this for initialization
    void Start()
    {

    }

    /// <summary>
    /// Called as fast as possible so not very good if it's needed to be steady. 
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Called a fixed number of times
    /// </summary>
    void FixedUpdate()
    {
        timeCounter();
        Movement();
    }

    //50 time = 1 unit at 1 speed .:. tickrate = 50
    /// <summary>
    /// The timer to see how long the enemy has been moving for and to change their movement direction
    /// </summary>
    void timeCounter()
    {
        //Adds the clock
        timeMoved += 1;

        //Checks if the time moved is more than the time you want to move for. 
        //Using greater than rather than equals removes the ability for it to break at a slight lag
        if (timeMoved > timeToMoveFor)
        {
            //Changes the direction
            movingLeft = !movingLeft;
            //Sets the moved time to 0 again
            timeMoved = 0;
            //Puts the fact it's changing direction in the log
            print("Distance is distance, changed over");
        }

    }

    /// <summary>
    /// The moving of the enemy
    /// </summary>
    void Movement()
    {
        //Checks what direction to go
        if (movingLeft)
        {
            //When it's moving left
            //Moves the enemy to the left, at the speed specified
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
        else
        {
            //When moving right
            //Moves the enemy to the right, at the speed specified
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }

    }



}