using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : BasicEnemy
{

    // Update is called once per frame
    override public void Update()
    {

        if (patrol != null)
        {
            target = patrol.Target;
        }

        if (target != null)
        {
            SetState(NPCState.pursuit);
        }

        if (target == null)
        {
            if (myStates == NPCState.pursuit)
            {
                SetState(NPCState.patrol);
            }
        }

        if (myStates == NPCState.idle)
        {
            aiAgent.destination = gameObject.transform.position;
        }

        if (myStates == NPCState.pursuit)
        {
            if (attacking)
            {
                RotateTowards();
                aiAgent.destination = transform.position;
                aiAgent.speed = 0;
            }

            else
            {
                gameObject.transform.position = new Vector3(target.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                aiAgent.speed = speed;
            }
        }
    }

    public override void Attack()
    {
        base.Attack();
    }
}
