using UnityEngine;
using System.Collections;


/// <summary>
/// This is the file that should be attached to all the things you want to use to kill the player
/// Right now it just kills the player instantly
/// </summary>
public class KillPlayer : MonoBehaviour
{
	//Gets the levelmanager so we can use the respawn part from that
	public LevelManager levelManager;

	// Use this for initialization
	void Start()
	{
		//Gets the level manager object in the level
		levelManager = FindObjectOfType<LevelManager>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	/// <summary>
	/// When something enters the trigger zone (Box collider) of the object that this script is attached to
	/// Run this function
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		//Tells you in the debuglog that something entered the collider, just in case something else breaks
		print ("Something entered the collider");
		//Sees what the name of the object that entered is
		if (other.name == "Player")
		{
			//If it's player, then respawn them with the respawn player thing
			print ("Entered the death");
			//Calls the levelmanager script to respawn the player
			//It is done without anything special and fancy but you could add some animation if you wanted to
			levelManager.RespawnPlayer();
		}

		//If an enemy goes onto a death box the enemy gets destroyed
		//This checks the tag of the object rather than the name. This is because you'll have multiple enemies with different names
		//and you'll want them all to be killed with this
		if (other.tag == "Enemy") {

			//Tells you that the enemy has been killed
			print ("Enemy entered collider and was destroyed");
			//Destroys the "other" object. This is the object that entered the collider and is the enemy. 
			//this does it without a fancy show and dance, but you could add an animation
			Destroy (other);

		}


	}
}