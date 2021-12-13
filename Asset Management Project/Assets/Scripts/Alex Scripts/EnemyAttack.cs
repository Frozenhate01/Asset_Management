using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float damageAmount;
    private BasicEnemy aiAttack;
    private bool didDamage = false;
    public GameObject attack;
    public GameObject attackPoint;
    private GameObject PlayerHit;
    public bool hasAttacked;
    private int attackCD;
    public int attackDelay;

    private void Start()
    {
        aiAttack = GetComponentInParent<BasicEnemy>();
        damageAmount = aiAttack.enemyDamage;
        InvokeRepeating("AttackCooldown", 1f, 1f);
    }

    private void Update()
    {
        if(aiAttack.canAttack == true)
        {
            didDamage = false;
        }

        if (aiAttack.isFlying == true && aiAttack.attacking == true && hasAttacked == false)
        {
            GameObject PlayerHit = Instantiate(attack, attackPoint.transform.position, gameObject.transform.rotation) as GameObject;
            hasAttacked = true;
            attackCD = attackDelay;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        HealthBar health = other.GetComponent<HealthBar>();
        if ((health && aiAttack.attacking && didDamage == false && aiAttack.isFlying == false) || (health && aiAttack == null))
        {
            health.LoseHealth(damageAmount);
            Debug.Log("Did" + damageAmount + "damage!");
            didDamage = true;
        }
    }

    public void AttackCooldown()
    {
        if (attackCD > 0)
        {
            hasAttacked = true;
            attackCD--;
        }

        else
        {
            hasAttacked = false;
        }
    }
}
