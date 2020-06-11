using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)] //Range of volume from 0 to 1
    public float volume = 0.7f; //Default volume
    [Range(0f,2f)] //Pitch range
    public float pitch = 1f; //Default Pitch

    public bool loop = false; //Loop the sound
    public bool PlayOnAwake = false; // Play sound on awake

    public AudioMixerGroup AudioMixerGroup;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.playOnAwake = PlayOnAwake;
        source.loop = loop;
        source.outputAudioMixerGroup = AudioMixerGroup;

    }

    public void Play()
    {
        source.Play();
    }
}



public class SoundManagement : MonoBehaviour
{
    public static SoundManagement instance;
    
  
   public Sound[] sounds;

     void Awake() //Function that checks that one scene have only one SoundManager
    {
        if (instance != null)
        {
            Debug.LogError("More than one SoundManager in the scene ");
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_"+i+"_"+sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
            
        }
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        
        //No sound with that name
        Debug.LogWarning("Sound not found" +_name);
    }
    
}
