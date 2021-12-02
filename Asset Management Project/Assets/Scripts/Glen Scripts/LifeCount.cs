using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeCount : MonoBehaviour
{
    [SerializeField] int livesRemaining;
    public TextMeshProUGUI lifeText;

    public void LoseLife()
    {
        if (livesRemaining == 0)
            return;
        
        livesRemaining--;

        lifeText.text = livesRemaining.ToString();

        if (livesRemaining == 0)
        {
            Debug.Log("LOSER");
            FindObjectOfType<GSN_GameManager>().GameOver();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            LoseLife();
    }
}
