using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSN_AudioManager2 : MonoBehaviour
{
    private static readonly string firstPlay = "First Play";
    private static readonly string backgroundPref = "backgroundPref";
    private static readonly string soundEffectsPref = "soundEffectsPref";

    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;


    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    public AudioSource soundButton;
    public AudioSource musicButton;
    public AudioSource playButton;
    public AudioSource optionsButton;
    public AudioSource creditsButton;
    public AudioSource exitGameButton;
    public AudioSource levelSelectButton;
    public AudioSource backToMenu1;
    public AudioSource backToMenu2;
    public AudioSource backToMenu3;
    public AudioSource level1;
    public AudioSource level2;
    public AudioSource level3;


    // Start is called before the first frame update
    void Start()
    {


        firstPlayInt = PlayerPrefs.GetInt(firstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = 1.25f;
            soundEffectsFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(backgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(backgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(soundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(backgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool infocus)
    {
        if(!infocus)
        {
            SaveSoundSettings(); 
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for ( int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
    public void HoverSound()
    {
        soundButton.PlayOneShot(hoverFx);
        musicButton.PlayOneShot(hoverFx);
        playButton.PlayOneShot(hoverFx);
        optionsButton.PlayOneShot(hoverFx);
        creditsButton.PlayOneShot(hoverFx);
        exitGameButton.PlayOneShot(hoverFx);
        levelSelectButton.PlayOneShot(hoverFx);
        backToMenu1.PlayOneShot(hoverFx);
        backToMenu2.PlayOneShot(hoverFx);
        level1.PlayOneShot(hoverFx);
        level2.PlayOneShot(hoverFx);
        level3.PlayOneShot(hoverFx);

    }

    public void CLickSOund()
    {
        soundButton.PlayOneShot(clickFx);
        musicButton.PlayOneShot(clickFx);
        playButton.PlayOneShot(clickFx);
        optionsButton.PlayOneShot(clickFx);
        creditsButton.PlayOneShot(clickFx);
        exitGameButton.PlayOneShot(clickFx);
        levelSelectButton.PlayOneShot(clickFx);
        backToMenu1.PlayOneShot(clickFx);
        backToMenu2.PlayOneShot(clickFx);
        backToMenu3.PlayOneShot(clickFx);
        level1.PlayOneShot(clickFx);
        level2.PlayOneShot(clickFx);
        level3.PlayOneShot(clickFx);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
