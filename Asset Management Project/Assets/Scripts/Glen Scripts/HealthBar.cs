using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fillBar;
    [SerializeField] public float health;
    [SerializeField] int livesRemaining;
    [SerializeField] float value;
    public bool damageable = true;
    public int invulnTimer;
    public int invulnCount;


    public void Start()
    {
        InvokeRepeating("Invulnerability", 1f, 1f);
    }
    public void LoseHealth(float value)
    {
        if(damageable)
        {
            if (health <= 0)
                return;

            health -= value;

            fillBar.fillAmount = health / 100;

            if (health <= 0)
            {
                Debug.Log("DEAD");
                FindObjectOfType<LifeCount>().LoseLife();
                livesRemaining--;
                if (livesRemaining > 0)
                {
                    RevivePlayer();
                    fillBar.fillAmount = health / 100;
                }
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

    public void Invulnerability()
    {
        if(damageable == false)
        {
            invulnCount--;
        }

        if(invulnCount <= 0)
        {
            damageable = true;
        }
    }
}
