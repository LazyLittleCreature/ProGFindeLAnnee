using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndSoundsPlayer : MonoBehaviour
{
    public AudioSource srcMusic;
    public AudioClip mainMenuMusic;
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
}
