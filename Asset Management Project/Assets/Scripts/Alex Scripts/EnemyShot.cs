using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{

    private HealthBar playerHealth;
    private Rigidbody projectileRb;
    public float lifespan;
    public float speed = 5.0f;
    public int damage;
    static int PlayerLayer = 11;
    static int EnemyLayer = 13;
    private bool hasDamaged;
    public string attackType;


    private void Awake()
    {
        projectileRb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
            projectileRb.AddForce(projectileRb.transform.up * speed * -1, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != EnemyLayer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == PlayerLayer)
        {
            HealthBar player = other.GetComponent<HealthBar>();
            if (player && hasDamaged == false)
            {
                hasDamaged = true;
                player.LoseHealth(damage);
                Destroy(gameObject);
            }
        }
    }
}
