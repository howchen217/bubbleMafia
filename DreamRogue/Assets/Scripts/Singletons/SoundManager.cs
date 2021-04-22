using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; } //you can get the instance, but you can't set the instance

    [SerializeField] private AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }


    public void PlayOneShotRandom(SoundBundle sounds, float volume, float pitch) 
    {
        float randValue = UnityEngine.Random.value; //this gives between 0 and 1
        if (randValue < 1) { //I need to make it always play..I ll still keep it here for future reference.
            source.pitch = pitch;
            source.PlayOneShot(sounds.GetARandomClip(), volume);
        }
    }

    public void PlayOneShot(AudioClip audio) {
        source.PlayOneShot(audio, 1);
    }

}
