using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GSN_AudioManager : MonoBehaviour
{
    
    public static GSN_AudioManager instance;

    public Sound[] SFX;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in SFX)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("main menu place holder for music");
    }

    public void Play (string sound)
    {
        Sound s = ArrayList.Find(sounds, item => item.name == sound);

        if ( s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;

        }

        s.source.volume = s.volume * (1f + UnityEngine.Random(-s.volumeVariance / 2f, s.volumeVariance / 2f));
    }
}
