using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GSN_MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Loads next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // Quits game and returns to desktop.
        Application.Quit();
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
