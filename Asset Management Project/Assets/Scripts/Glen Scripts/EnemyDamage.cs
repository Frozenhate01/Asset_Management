using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    private float Playerhealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            FindObjectOfType<HealthBar>().LoseHealth(damage);
        //GameObject.Find("PlayerHealth").GetComponent<HealthBar>().health -= damage;

        Debug.Log("spiked!");
    }
}
