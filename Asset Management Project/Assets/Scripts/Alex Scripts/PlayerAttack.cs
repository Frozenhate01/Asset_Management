using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    bool hasAttacked;
    bool hasRangeAttacked;

    int attackCD;
    int attackDelay;
    float rangedAttackCD;
    float rangedAttackDelay;
    public bool rightFacing;
    public bool leftFacing;
    public GameObject player;
    public GameObject leftSpawner;
    public GameObject rightSpawner;
    public GameObject rangedAttack;
    public GameObject meleeAttack;
    public GameObject superShot;
    public string consumeAbility;
    private PlayerAttack playerAttack;
    public Rigidbody2D playerrb;
    private HealthBar playerHealth;
    private PlayerEnergy playerEnergy;
    public int dashCost;
    public int superShotCost;
    public int superJumpCost;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerrb = player.GetComponent<Rigidbody2D>();
        playerHealth = player.GetComponentInChildren<HealthBar>();
        playerEnergy = player.GetComponent<PlayerEnergy>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position;
        transform.localRotation.Set(0, 0, 0, 0);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (rightFacing == true)
            {
                FindObjectOfType<GSN_AudioManager>().Play("Shoot");
                GameObject PlayerShot = Instantiate(rangedAttack, rightSpawner.transform.position, gameObject.transform.rotation) as GameObject;
            }

            if (leftFacing == true)
            {
                FindObjectOfType<GSN_AudioManager>().Play("Shoot");
                GameObject PlayerShot = Instantiate(rangedAttack, leftSpawner.transform.position, gameObject.transform.rotation) as GameObject;
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(consumeAbility == "superShot"  && playerEnergy.currentEnergy >= superShotCost)
            {
                if (rightFacing == true)
                {
                    FindObjectOfType<GSN_AudioManager>().Play("SuperShoot");
                    GameObject PlayerShot = Instantiate(superShot, rightSpawner.transform.position, gameObject.transform.rotation) as GameObject;
                    playerEnergy.currentEnergy -= superShotCost;
                }

                if (leftFacing == true)
                {
                    FindObjectOfType<GSN_AudioManager>().Play("SuperShoot");
                    GameObject PlayerShot = Instantiate(superShot, leftSpawner.transform.position, gameObject.transform.rotation) as GameObject;
                    playerEnergy.currentEnergy -= superShotCost;
                }
            }
            if(consumeAbility == "superJump" && playerEnergy.currentEnergy >= superJumpCost)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 10f);
                playerEnergy.currentEnergy -= superJumpCost;
            }
            if(consumeAbility == "charge" && playerEnergy.currentEnergy >= dashCost)
            {
                if (rightFacing == true)
                {
                    playerHealth.damageable = false;
                    playerHealth.invulnCount = playerHealth.invulnTimer;
                    playerrb.AddForce(gameObject.transform.right * 50, ForceMode2D.Impulse);
                    playerEnergy.currentEnergy -= dashCost;
                }

                if (leftFacing == true)
                {
                    playerHealth.damageable = false;
                    playerHealth.invulnCount = playerHealth.invulnTimer;
                    playerrb.AddForce(gameObject.transform.right * 50 * -1,  ForceMode2D.Impulse);
                    playerEnergy.currentEnergy -= dashCost;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (rightFacing == true)
            {
                GameObject PlayerHit = Instantiate(meleeAttack, rightSpawner.transform.position, gameObject.transform.rotation) as GameObject;
            }

            if (leftFacing == true)
            {
                GameObject PlayerHit = Instantiate(meleeAttack, leftSpawner.transform.position, gameObject.transform.rotation) as GameObject;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightFacing = true;
            leftFacing = false;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftFacing = true;
            rightFacing = false;
        }
    }
}
