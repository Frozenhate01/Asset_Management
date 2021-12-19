using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeCount : MonoBehaviour
{
    [SerializeField] public static int livesRemaining = 5;
    public TextMeshProUGUI lifeText;

    public void LoseLife()
    {
        if (livesRemaining == 0)
            return;
        
        livesRemaining--;

        if (livesRemaining == 0)
        {
            Debug.Log("LOSER");
            FindObjectOfType<GSN_AudioManager>().Play("");
            FindObjectOfType<GSN_GameManager>().GameOver();
        }
    }

    public void GainLife()
    {
        FindObjectOfType<GSN_AudioManager>().Play("LifeGain");
        livesRemaining++;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            LoseLife();
        lifeText.text = livesRemaining.ToString();
    }
}
