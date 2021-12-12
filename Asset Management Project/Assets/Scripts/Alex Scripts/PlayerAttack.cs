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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
                GameObject PlayerShot = Instantiate(rangedAttack, rightSpawner.transform.position, gameObject.transform.rotation) as GameObject;
            }

            if (leftFacing == true)
            {
                GameObject PlayerShot = Instantiate(rangedAttack, leftSpawner.transform.position, gameObject.transform.rotation) as GameObject;
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && consumeAbility == "superShot")
        {
            if (rightFacing == true)
            {
                GameObject PlayerShot = Instantiate(superShot, rightSpawner.transform.position, gameObject.transform.rotation) as GameObject;
            }

            if (leftFacing == true)
            {
                GameObject PlayerShot = Instantiate(superShot, leftSpawner.transform.position, gameObject.transform.rotation) as GameObject;
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
