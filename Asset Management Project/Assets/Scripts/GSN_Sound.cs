using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSN_Sound : MonoBehaviour
{
     private static GSN_Sound sound
        ;
    private void Awake()
    {
        if(sound == null)
        {
            sound = this;
            DontDestroyOnLoad(sound);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
