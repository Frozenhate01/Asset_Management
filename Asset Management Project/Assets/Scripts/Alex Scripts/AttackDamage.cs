using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public PlayerAttack playerAttack;
    private Rigidbody projectileRb;
    public float lifespan;
    public float speed = 5.0f;
    public int damage;
    static int PlayerLayer = 11;
    static int EnemyLayer = 13;
    private bool hasDamaged;

    // Start is called before the first frame update

    private void Awake()
    {
        playerAttack = GameObject.Find("PlayerAttack").GetComponent<PlayerAttack>();
        projectileRb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if(playerAttack.leftFacing == true)
        {
            projectileRb.AddForce(projectileRb.transform.right * speed * -1, ForceMode.Impulse);
        }
        if(playerAttack.rightFacing == true)
        {
            projectileRb.AddForce(projectileRb.transform.right * speed, ForceMode.Impulse);
        }
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != PlayerLayer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.layer == EnemyLayer)
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy && hasDamaged == false)
            {
                hasDamaged = true;
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

}
