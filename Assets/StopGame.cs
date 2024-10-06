using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    // Make sure the method is public
    public void StopGameSimulation()
    {
        // Pause the game by setting the time scale to 0
        Time.timeScale = 0;
        print("Game is paused.");
    }

     // Resets the game and ensures the game time is resumed
    public void ResetGameToStart()
    {
        // Make sure the time scale is reset to 1 before resetting the game
        Time.timeScale = 1;
        
        // Reload the current scene to reset the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        print("The game is reset and resumed.");
    }

}
