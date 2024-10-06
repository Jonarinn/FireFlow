using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
    
    }
    // Make sure the method is public
    public void ResetGameToStart()
    {
        // Reload the current scene to reset the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("the buttons is working");
    }
}
