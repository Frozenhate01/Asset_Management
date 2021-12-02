using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GSN_GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public float points;

    public void GameOver()
    {
        GameOverScreen.Setup(points);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
