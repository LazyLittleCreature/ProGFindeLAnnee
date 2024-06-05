using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndSoundsPlayer : MonoBehaviour
{
    public AudioSource srcMusic;
    public AudioSource srcSFX;
    public AudioClip mainMenuMusic;
    public AudioClip settingsButton;
    public AudioClip returnButton;
    public AudioClip quitButton;
    public AudioClip playButton;
    public static MusicAndSoundsPlayer instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        srcMusic.clip = mainMenuMusic;
    }

    private void Update()
    {
        if (!srcMusic.isPlaying)
        {
            srcMusic.Play();
        }
    }

    public void SettingsButtonClick()
    {
        srcSFX.clip = settingsButton;
        srcSFX.Play();
    }
    
    public void ReturnButtonClick()
    {
        srcSFX.clip = returnButton;
        srcSFX.Play();
    }
    
    public void QuitButtonClick()
    {
        srcSFX.clip = quitButton;
        srcSFX.Play();
    }
    
    public void PlayButtonClick()
    {
        srcSFX.clip = playButton;
        srcSFX.Play();
    }
}
