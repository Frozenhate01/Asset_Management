using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;



public class GSN_AudioManager : MonoBehaviour
{

    public static GSN_AudioManager instance;

    private float musicVolume = 1f;


    public Sound[] soundEffects;

    public AudioSource audioSource;
    public AudioClip hoverFx;
    public AudioClip clickFx;



    private bool muted = false;

  
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

           foreach (Sound s in soundEffects)
           {
               s.source = gameObject.AddComponent<AudioSource>();
               s.source.clip = s.clip;
               s.source.loop = s.loop;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
           }
       }

    private void Update()
    {
        audioSource.volume = musicVolume;
    }

    private void Start()
       {
          // Play("Theme");
          

        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        AudioListener.pause = muted;
        
       }

    public void volumeScroll(float volume)
    {
        musicVolume = volume;
    }

    public void MusicOnBbuttonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();

    }

    public void SoundOnBbuttonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        
    }

 





    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

        public void HoverSound()
        {
        audioSource.PlayOneShot(hoverFx);
        }
        
        public void CLickSOund()
        {
        audioSource.PlayOneShot(clickFx);
        }

    
       public void Play (string sound)
       {
           Sound s = Array.Find(soundEffects, item => item.name == sound);
        s.source.volume = s.volume;
       s.source.pitch = s.volume;
        if ( s == null)
           {
               Debug.LogWarning("Sound: " + name + " not found!");
               return;

           }

      
        if (GSN_Options.GameIsPaused)
        {
            s.source.pitch = .5f;
            
        }

           s.source.Play();
       }

  /*  public void Stop(string sound)
    {
        Sound s = Array.Find(soundEffects, item => item.name == sound);
        
  
    }
  */




}
