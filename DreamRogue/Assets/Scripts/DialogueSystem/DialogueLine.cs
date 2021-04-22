using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker;
    [TextArea]
    public string dialogue;
    public Speaker.Mood mood;
    public float typeSpeed = 0.05f;
    public float speakingVolume = 0.3f;
}
