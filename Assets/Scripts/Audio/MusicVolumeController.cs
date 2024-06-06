using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider musicSlider;
    private AudioSource src;

    private void Start()
    {
        src = GameObject.FindGameObjectWithTag("MusicMenu").GetComponent<AudioSource>();
        musicSlider.value = PlayerPrefs.GetFloat("musicSlider_value", 0.5f);
        src.volume = musicSlider.value;
    }

    public void UpdateMusicVolume()
    {
        PlayerPrefs.SetFloat("musicSlider_value", musicSlider.value);
        src.volume = musicSlider.value;
    }
}
