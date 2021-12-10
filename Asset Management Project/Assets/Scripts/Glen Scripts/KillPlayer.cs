using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] public Transform spawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            collision.transform.position = spawnPoint.position;
            FindObjectOfType<LifeCount>().LoseLife(); 
            FindObjectOfType<HealthBar>().RevivePlayer();
    }

}
