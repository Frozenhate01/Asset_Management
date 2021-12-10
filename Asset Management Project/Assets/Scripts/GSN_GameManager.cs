using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GSN_GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;

    private static GSN_GameManager instance;
    public static GSN_GameManager Instance { get { return instance; } }

    public int lives;
    public float score;

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetFloat("Score");
        }
        else if (PlayerPrefs.HasKey("Lives"))
        {
            lives = PlayerPrefs.GetInt("Lives");
        }
        else
        {
            Save();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.SetInt("Lives", lives);
    }


    public void GameOver()
    {
        GameOverScreen.Setup(score);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Update()
    {
        score = CoinPicker.coin;
        lives = LifeCount.livesRemaining;
    }
}
