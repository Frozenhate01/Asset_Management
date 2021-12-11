using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;



public class GSN_AudioManager : MonoBehaviour
{

    public static GSN_AudioManager instance;

    [SerializeField] Image soundOn;
    [SerializeField] Image soundOff;
    [SerializeField] Image musicOn;
    [SerializeField] Image musicOff;

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
        UpdateSound();
        UpdateMusic();

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
        UpdateMusic();

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
        UpdateSound();
        
    }

    private void UpdateSound()
    {
        if(muted==false)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
        }
        else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }

    }

    private void UpdateMusic()
    {
        if (muted == false)
        {
            musicOn.enabled = true;
            musicOff.enabled = false;
        }
        else
        {
            musicOn.enabled = false;
            musicOff.enabled = true;
        }
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
       // s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
       // s.source.pitch = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        if ( s == null)
           {
               Debug.LogWarning("Sound: " + name + " not found!");
               return;

           }

      
        if (GSN_Options.GameIsPaused)
        {
            s.source.pitch = .5f;
            
        }

         
           // FindObjectOfType<GSN_AudioManager>().Play(" ");


           s.source.Play();
       }

    

  


}
