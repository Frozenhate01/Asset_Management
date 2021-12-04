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
    private bool rightFacing;
    private bool leftFacing;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation.Set(0, 0, 0, 0);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {

        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(rightFacing == true)
            {

            }

            if(leftFacing == true)
            {

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
