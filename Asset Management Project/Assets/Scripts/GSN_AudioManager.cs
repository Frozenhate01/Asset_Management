using UnityEngine;
using System;
using UnityEngine.Audio;

public class GSN_AudioManager : MonoBehaviour
{
    
    public static GSN_AudioManager instance;

    public Sound[] soundEffects;

    public AudioSource audioSource;
    public AudioClip hoverFx;
    public AudioClip clickFx;

  
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

       private void Start()
       {
           Play("main menu place holder for music");
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

           if ( s == null)
           {
               Debug.LogWarning("Sound: " + name + " not found!");
               return;

           }

          // s.source.volume = s.volume * (1f + UnityEngine.Random(-s.volumeVariance / 2f, s.volumeVariance / 2f));
           //s.source.pitch = s.volume * (1f + UnityEngine.Random(-s.volumeVariance / 2f, s.volumeVariance / 2f));



           s.source.Play();
       }


       
}
