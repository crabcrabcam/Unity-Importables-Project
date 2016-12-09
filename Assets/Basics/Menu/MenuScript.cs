using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
///This is the script for the main menu
/// It controlls all the buttons over there. 
/// </summary>
public class MenuScript : MonoBehaviour
{
    
    public string levelToLoad;

    /// <summary>
    /// What happens when you load this scene
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// This is the function called when the player presses the "Start" button
    /// It loads whatever level you set as "levelToLoad"
    /// </summary>
    public void OnStart()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    /// <summary>
    /// This quits the game when the player presses the "Quit button". There isn't a check to ask if they want to do it
    /// Add that yourself if you want to :)
    /// </summary>
    public void Quit()
    {
        //Quits the application
        Application.Quit();
        //Prints "Quit the game" to the debug log because the Unity Editor doesn't do anything if you do Application.Quit()
        Debug.Log("Quit the game.");
    }

    /// <summary>
    /// This function isn't currently used. It's for if you want to add a continue button
    /// You can do that by setting a player prefs integer and updating that every level. 
    /// You do have to call your levels "Level1" and "Level2" and so on to do this
    /// However you can also use a string for the level name.
    /// I've decided to leave this out because it makes the LevelManager very confusing but I'll leave it here for anyone who wants to give it a go. 
    /// Take a look at "https://github.com/crabcrabcam/Primitive-Game-Jam-MiniLD-70" < that project. It's got the whole of this code in it. 
    /// Good luck :) 
    /// 
    /// It does technically work. it's just it will always have the "PlayerLevel" as 0 unless you make some changes somewhere else
    /// It will then load the first level and basically be the same as the "Start" button
    /// </summary>
    public void Continue()
    {
        //Sees if the player level is 0. If it's 0 the player hasn't started yet
        if (PlayerPrefs.GetInt("PlayerLevel") == 0)
        {
            //So it loads the first level
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            //If there is a level, then it gets the level number and adds it to the end of "Level". If the PlayerLevel == 3 then it will be "Level3"
            SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("PlayerLevel"));
            //It instantly loads this level, then prints the level string that it loaded for debugging. 
            print("Level" + PlayerPrefs.GetInt("PlayerLevel"));
        }
    }

}