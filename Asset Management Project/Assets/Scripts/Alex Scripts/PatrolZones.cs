using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolZones : MonoBehaviour
{
    public GameObject Target;
    public List<GameObject> waypoints = new List<GameObject>();
    private int waypointLayer = 10;
    private int playerLayer = 11;
    public bool pzFull;


    public void Update()
    {
        if (waypoints.Count >= 3)
        {
            pzFull = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // The player's layer is 11. If an object on this layer collides with the patrol zone, it will change the target to that object.
        if (other.gameObject.layer == playerLayer)
        {
            Target = other.gameObject;
        }


        // the Waypoint Layer is 10 currently. All waypoints need to be set to this layer. When they collide with the trigger, they will be added to the AI's waypoint list.
        if (other.gameObject.layer == waypointLayer)
        {
            waypoints.Add(other.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            Target = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        // When an object of the player layer leaves the zone, the target is set to null
        if (collision.gameObject.layer == playerLayer)
        {
            Target = null;
        }
    }
}

