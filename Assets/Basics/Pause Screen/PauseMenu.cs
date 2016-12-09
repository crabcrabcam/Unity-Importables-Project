using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// The script for controlling the pausemenu and the buttons
/// </summary>
public class PauseMenu : MonoBehaviour
{

	//Sets whether the game is paused
	//This is automatically set to false so the game isn't paused
	public bool isPaused;
	//The canvas that the buttons are on
	public GameObject pauseMenuCanvas;
	//This should be set to the same as the name of the level in unity that your main menu is.
	public string mainMenu;

	/// <summary>
	/// Called a lot of times a seccond. As fast as the game will allow
	/// </summary>
	void Update()
	{

		//Waits for the player to press escape to pause the game
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//Sets pause to whatever it's not (If it's on, now it's off and the other way round)
			//this is done so we don't need 2 scripts for turing to paused and turning to play again
			isPaused = !isPaused;
		}

		//Checks if the game is paused or not
		if (isPaused)
		{
			//If the game is paused it sets the canvas to on to show it
			pauseMenuCanvas.SetActive(true);
			//Sets the time scale to 0 so that the game pauses and no movements happen
			Time.timeScale = 0f;
		}
		else
		{
			//Sets the canvas to inactive and hides it
			pauseMenuCanvas.SetActive(false);
			//Sets the time scale back to 1 so that the game runs at full speed again
			Time.timeScale = 1f;
		}

	}

	/// <summary>
	/// The function for the resume button
	/// </summary>
	public void Resume()
	{
		//Sets "isPaused" to false and the game continues because of what's happening inside the update function
		isPaused = false;
	}

	/// <summary>
	/// The function for the MainMenu button
	/// </summary>
	public void MainMenu()
	{
		//Loads the mainmenu scene. This will need to be changed to be whatever you've called your menu screen
		//It just goes to the menu. You might want to set a message box or somethign here to make sure they want to do that
		SceneManager.LoadScene(mainMenu);
	}

	/// <summary>
	/// The function for the Restart button
	/// </summary>
	public void RestartLevel()
	{
		//Reloads the active scene (The level you're currently on)
		//It just reloads. You might want to set a message box or something here to make sure they want to do that
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	/// <summary>
	/// The function for the quit button
	/// </summary>
	public void Quit()
	{
		//Quits the game
		//It just quits. You might want to set a message box or something here to make sure they want to do that
		Application.Quit();
		//Prints "Quit the game." to the console so you can tell if this button has been pressed correctly in the editor
		//This is because the game doesn't quit or stop or do anything if you're trying to quit it inside the editor. 
		//You can always just build and run the game to test this though. 
		Debug.Log("Quit the game.");
	}
}