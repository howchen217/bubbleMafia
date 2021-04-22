using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SoundBundle", menuName = "Custom Audio/New SoundBundle")]
public class SoundBundle : ScriptableObject
{
    [SerializeField] private AudioClip[] audioClips;

    public AudioClip GetARandomClip() 
    {
        int randomIndex = Random.Range(0, audioClips.Length);
        return audioClips[randomIndex];
    }
}
