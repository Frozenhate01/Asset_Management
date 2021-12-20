using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GSN_GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public WinScreen WinScreen;

    private static GSN_GameManager instance;
    public static GSN_GameManager Instance { get { return instance; } }

    public int lives;
    public float score;

    private void Awake()
    {
        instance = this;
        //FindObjectOfType<GSN_AudioManager>().Play("PlayTheme");

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

    //public void Delete()
    //{
        //score = 0;
        //PlayerPrefs.SetFloat("Score", score);
    //}


    public void GameOver()
    {
        GameOverScreen.Setup(score);
    }

    public void Win()
    {
        WinScreen.Setup(score);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // FindObjectOfType<GSN_AudioManager>().("GameOver");
    }

    public void Update()
    {

        
        score = CoinPicker.coin;
        lives = LifeCount.livesRemaining;
    }
}
