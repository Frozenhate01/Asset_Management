using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI textPoints;
    public void Setup(float score)
    {
        gameObject.SetActive(true);
        textPoints.text = score.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        FindObjectOfType<GSN_GameManager>().Restart();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
