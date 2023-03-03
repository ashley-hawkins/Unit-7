using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundInfo
{
    [System.Serializable]
    public enum SoundType
    {
        Music,
        SFX
    }
    public bool instantaneous;
    public bool loop;
    public string id;
    public SoundType type;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 2f)]
    public float pitch;
}
