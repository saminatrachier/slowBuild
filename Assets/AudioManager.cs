using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;


    
    
    void Awake()
    {
        //Prevent destroy on load and also prevent duplicates
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        //Instead of a for each method, we can just use this function to find a sound in the sounds array and match the sound.name to match up with the name placed in the inspector.
       Sound s=  Array.Find(sounds, sound => sound.name == name);

       if (s == null)
       {
           Debug.LogWarning("Sound: " + name + " was not found! Did you mistype it? It happens.");
           return;
       }
       s.source.Play();
        
    }
    
    //Play Background Theme
    private void Start()
    {
        Play("Theme");
    }
}
