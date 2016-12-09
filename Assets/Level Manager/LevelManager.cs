using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//The next level as a string.
	//This should be the exact name of the level file as it appears in the build settings
	public string levelToLoad;
	//This is where the level starts, or where you want your player to go to after they die
	public GameObject startOfLevel;
	//This should be set to the player character game object
	public GameObject player;

	//This is set to false by default. You set this to true in the editor when you want the level to be the last one
	//This can be used to send the player to the home screen or a completion screen
	public bool lastLevel = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/// <summary>
	/// The function that is called when the player needs to be respawned
	/// This isn't used in the "LevelManager" package. I've put it in here because maybe you can work it out ;)
    /// The function needs to be public so it can be called by other scripts from elsewhere in the game
	/// </summary>
	/// <returns>The player.</returns>
	public void RespawnPlayer()
	{
		//Sets the player position in the world to the same as the "startOfLevel" game object
		player.transform.position = startOfLevel.transform.position;
	}

	/// <summary>
	/// Call this function to progress the player to the next level
    /// The function needs to be public so it can be called by other scripts from elsewhere in the game
	/// </summary>
	/// <returns>The level.</returns>
	public void NextLevel() {

		//Checks if the lastLevel variable is true.
		if (lastLevel) {
			//Moves to the completed scene. Change this to be whatever you called your completed scene
			SceneManager.LoadScene("CompletedScene");
		}
		else {
			//Load whatever you put in the "levelToLoad" string variable in the Unity editor
			SceneManager.LoadScene(levelToLoad);
		}
	}
}