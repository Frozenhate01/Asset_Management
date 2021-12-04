using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float damageAmount;
    private BasicEnemy aiAttack;
    private bool didDamage = false;

    private void Start()
    {
        aiAttack = GetComponentInParent<BasicEnemy>();
        damageAmount = aiAttack.enemyDamage;
    }

    private void Update()
    {
        if(aiAttack.canAttack == true)
        {
            didDamage = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        HealthBar health = other.GetComponent<HealthBar>();
        if ((health && aiAttack.attacking && didDamage == false) || (health && aiAttack == null))
        {
            health.LoseHealth(damageAmount);
            Debug.Log("Did" + damageAmount + "damage!");
            didDamage = true;
        }
    }
}
