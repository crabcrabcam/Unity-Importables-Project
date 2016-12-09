using UnityEngine;
using System.Collections;

/// <summary>
/// This gets attached to the finish flag of the level
/// It calls the NextLevel() function on the LevelManager
/// </summary>
public class LevelUp : MonoBehaviour 
{

    public LevelManager levelManager;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    /// <summary>
    /// Called when something enters the collider of the levelFlag
    /// </summary>
    /// The "Collider2D" part means that it must be 2D colliders.
    /// "other" is the object of whatever entered
    void OnTriggerEnter2D(Collider2D other) 
    {
        //Checks the name of the object that entered. If the player isn't called "Player" then you'll need to change this
        if (other.name == "Player")
        {
            Debug.Log("LevelUp");
            //Calls the function from the LevelManager to move to the next level
            levelManager.NextLevel();
        }
    }
}
