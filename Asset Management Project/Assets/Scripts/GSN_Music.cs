using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSN_Music : MonoBehaviour
{
    private static GSN_Music music;
    private void Awake()
    {
        if(music == null)
        {
            music = this;
            DontDestroyOnLoad(music);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
