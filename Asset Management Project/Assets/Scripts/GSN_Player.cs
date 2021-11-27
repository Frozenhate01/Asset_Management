using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSN_Player : MonoBehaviour
{

    public int level = 3;
    public int health = 40;

    public void SavePlayer()
    {
        GSN_SaveSystem.SavePlayer(this);
    }    

    public void LoadPlayer ()
    {
        GSN_PlayerData data = GSN_SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[3];
        transform.position = position;
    }
}
