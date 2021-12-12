using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private BasicEnemy enemyScript;
    private int maxHealth;
    public int currentHealth;
    private GameObject player;
    private PlayerAttack playerAttack;
    public string consumeAbility;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponentInParent<BasicEnemy>();
        maxHealth = enemyScript.enemyMaxHealth;
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
        consumeAbility = enemyScript.consumeAbility;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage, string attackType)
    {
        if (currentHealth - damage <= 0)
        {
            currentHealth -= damage;
            Debug.Log("Dead!");
            Destroy(gameObject);
        }
        else
        {
            currentHealth -= damage;
            Debug.Log("Took damage!");
        }
    }
}
