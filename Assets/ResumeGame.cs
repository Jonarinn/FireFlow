using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    // Resumes the game by setting the time scale to 1
    public void ResumeGameSimulation()
    {
        Time.timeScale = 1;
        print("Game is resumed.");
    }
}
