using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fillBar;
    [SerializeField] float health;
    [SerializeField] int livesRemaining;

    public void LoseHealth(float value)
    {
        if (health <= 0)
            return;
        
        health -= value;

        fillBar.fillAmount = health / 100;

        if(health <=0)
        {
            Debug.Log("DEAD");
            FindObjectOfType<LifeCount>().LoseLife();
            livesRemaining--;
            if(livesRemaining > 0)
            {
                RevivePlayer();
                fillBar.fillAmount = health / 100;
            }
        }
    }

    public void RevivePlayer()
    {
        health = 100;
        fillBar.fillAmount = health / 100;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
            LoseHealth(25);
    }
}
