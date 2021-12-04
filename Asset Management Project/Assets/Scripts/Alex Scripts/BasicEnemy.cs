using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCState { patrol, idle, pursuit };

public class BasicEnemy : MonoBehaviour
{
    public float minStateTime;
    public float maxStateTime;
    private float currentStateTime;
    public GameObject target = null;
    protected NPCState myStates;

    public List<GameObject> navWaypoints = new List<GameObject>();
    protected NavMeshAgent aiAgent;
    private int patrolDest;
    public int speed = 5;

    //public int randomStart;

    public PatrolZones patrol = null;
    private GameObject currentWaypoint;
    private GameObject nextWaypoint;
    private bool pzSet = false;


    public int attackDelay; // the value set in the inspector.
    protected int attackCD; // the value set in the code, based off of attackDelay. This number is decremented automatically after attacking.
    public bool attacking;
    protected bool canAttack;
    protected int playerLayer = 11;
    public int rotateAmount; //the speed that the enemy will rotate with to face the player
    public int enemyDamage; // the damage value for all the normal enemy attacks
    public int specialDamage; // the damage value for special attacks like the Orc smash
    public int enemyMaxHealth; // the enemy's max health that is called in their health script

    protected bool attackAnimCD;

    // Start is called before the first frame update
    public virtual void Start()
    {
        aiAgent = GetComponent<NavMeshAgent>();
        myStates = NPCState.idle;
        currentStateTime = UnityEngine.Random.Range(minStateTime, maxStateTime);
        aiAgent.speed = speed;

        // invokes the attack cooldown and state swapping every second
        InvokeRepeating("StateTimePassage", 1f, 1f);
        InvokeRepeating("AttackCooldown", 1f, 1f);

        aiAgent.autoBraking = false;

        switch (myStates)
        {
            case NPCState.idle:
                break;

            case NPCState.patrol:
                break;

            // if we decide we want the random start back in
            /*  case NPCState.random:
                  randomstart = Random.Range(0, 3);
                  if (randomstart > 0 && randomstart < 1.1)
                  {
                      SetState(NPCState.idle);
                  }
                  else if(randomstart > 1.1)
                  {
                      SetState(NPCState.patrol);
                  }
                  break;*/

            case NPCState.pursuit:
                break;
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {

        NavMeshHit closestHit;

        if (NavMesh.SamplePosition(gameObject.transform.position, out closestHit, 500f, NavMesh.AllAreas))
        {
            gameObject.transform.position = closestHit.position;
        }

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


        if (currentStateTime < 1)
        {
            if (myStates == NPCState.idle)
            {
                SetState(NPCState.patrol);
                aiAgent.speed = speed;

            }

            else if (myStates == NPCState.patrol)
            {
                SetState(NPCState.idle);
                aiAgent.speed = 0;
            }
        }

        if (myStates == NPCState.patrol)
        {
            if (!aiAgent.pathPending && aiAgent.remainingDistance < 1f)
            {
                NextPatrolPoint();
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
                aiAgent.destination = target.transform.position;
                aiAgent.speed = speed;
            }
        }

        if (patrol.pzFull == true && pzSet == false)
        {
            navWaypoints = patrol.waypoints;
            Shuffle(navWaypoints);
            pzSet = true;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        PatrolZones pz = other.gameObject.GetComponent<PatrolZones>();
        if (pz)
        {
            if (patrol == null)
            {
                patrol = pz;
            }
        }
    }

    public static void Shuffle<T>(IList<T> navWaypoints)
    {
        for (int i = 0; i < navWaypoints.Count; i++)
        {
            T temp = navWaypoints[i];
            int randomIndex = UnityEngine.Random.Range(i, navWaypoints.Count);
            navWaypoints[i] = navWaypoints[randomIndex];
            navWaypoints[randomIndex] = temp;
        }
    }

    public virtual void SetState(NPCState newState)
    {

        myStates = newState;

        switch (newState)
        {
            case NPCState.idle:
                currentStateTime = UnityEngine.Random.Range(minStateTime, maxStateTime);
                break;

            case NPCState.patrol:
                CurrentPatrolPoint();
                currentStateTime = UnityEngine.Random.Range(minStateTime, maxStateTime);
                break;

            case NPCState.pursuit:
                break;
        }
    }


    // This decrements 1 second from current state time every second. At 0 seconds, current state will swap.
    void StateTimePassage()
    {
        currentStateTime--;
    }


    // determines what the next waypoint is by selecting the next patrol point in the list of waypoints
    void NextPatrolPoint()
    {
        currentWaypoint = nextWaypoint;
        patrolDest = (patrolDest + 1) % navWaypoints.Count;
        aiAgent.destination = navWaypoints[patrolDest].transform.position;
        nextWaypoint = navWaypoints[patrolDest];
        if (nextWaypoint == currentWaypoint)
        {
            aiAgent.destination = navWaypoints[patrolDest].transform.position;
            patrolDest = (patrolDest + 1) % navWaypoints.Count;
            nextWaypoint = navWaypoints[patrolDest];
        }
    }

    //when the ai switches back to patrol from pursuit, gets its current patrol point so it can progress normally
    void CurrentPatrolPoint()
    {
        aiAgent.destination = navWaypoints[patrolDest].transform.position;
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.gameObject == target)
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        if (canAttack == true)
        {   // do normal attack
            attacking = true;
            attackAnimCD = true;
            attackCD = attackDelay;
            canAttack = false;
            Debug.Log("Attacked the Player!");
        }
    }

    public virtual void AttackCooldown()
    {
        if (attackCD > 0)
        {
            attackAnimCD = false;
            attackCD--;
        }

        else
        {
            canAttack = true;
            attacking = false;
        }
    }

    public void RotateTowards()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateAmount);
    }

    public bool idling()
    {
        if (myStates == NPCState.idle || attacking)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public virtual bool AttackAnim()
    {
        if (attackAnimCD)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
