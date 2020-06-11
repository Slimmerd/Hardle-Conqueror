using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [Space(10)]
    public Slider SliderVolume;

    
    //    Volume

    public void SetVolume(float volume) //Volume changer 
    {
        
        audioMixer.SetFloat("volume", volume);
    }
    
    void Start()
    {
        SliderVolume.value = PlayerPrefs.GetFloat("volume", 0);
    }
    
    void OnDisable()
    {
        float volume = 0;
        audioMixer.GetFloat("volume",out volume);
        
        PlayerPrefs.SetFloat("volume",volume);
        PlayerPrefs.Save();
    }


    //    Graphics

    public void SetQuality(int qualityIndex) //Graphics quality changer
    {
        QualitySettings.SetQualityLevel(qualityIndex); 
    }
}