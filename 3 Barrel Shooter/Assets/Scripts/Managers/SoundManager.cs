﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public List<AudioClip> sounds;

    public AudioSource audioSource = new AudioSource();

    public void InitSoundManager()
    {
        sounds = new List<AudioClip>();
        LoadSounds();
    }


    private void LoadSounds()
    {
        TextAsset txt = (TextAsset)Resources.Load("Sounds/loadSounds", typeof(TextAsset));
        string[] lines = Regex.Split(txt.text, "\n|\r|\r\n");

        foreach (string line in lines)
        {
            sounds.Add(Resources.Load<AudioClip>("Sounds/" + line));
           
        }
    }


    // TODO: Implement if needed
    public void PlaySoundsByName(AudioSource s, string name)
    {

    }
    public void PlaySound(int i)
    {
        //Debug.Log(i);

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.clip = sounds[i];
            //s.loop = true;
            audioSource.Play();
        }
        // else { s.Stop(); }
    }

    public void PlaySoundsByID(AudioSource s, int i)
    {
        //Debug.Log(i);

        if (s != null && !s.isPlaying)
        {
            s.clip = sounds[i];
            //s.loop = true;
            s.Play();
        }
       // else { s.Stop(); }
    }
    public void StopSound(AudioSource asource)
    {
        if (asource != null)
        asource.Stop();
    }

}
