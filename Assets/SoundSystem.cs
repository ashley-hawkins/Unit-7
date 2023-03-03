using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem soundSystem;
    public Dictionary<string, AudioSource> soundSources;
    public Dictionary<SoundInfo.SoundType, List<string>> soundTypeGroups;
    public SoundInfo[] soundInfoArray;

    private void Awake()
    {
        soundTypeGroups = new();
        soundSources = new();
        if (soundSystem != null)
        {
            Destroy(this);
            return;
        }
        soundSystem = this;
        DontDestroyOnLoad(this);
        Init();
    }

    private void Init()
    {
        foreach (var sound in soundInfoArray)
        {
            var source = gameObject.AddComponent<AudioSource>();
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.pitch = sound.pitch;
            source.loop = sound.loop;
            soundSources.Add(sound.id, source);

            soundTypeGroups.TryAdd(sound.type, new List<string>());
            soundTypeGroups[sound.type].Add(sound.id);

            if (sound.instantaneous)
            {
                source.Play();
            }
        }

        foreach (SoundInfo.SoundType type in Enum.GetValues(typeof(SoundInfo.SoundType)))
        {
            var volume = PlayerPrefs.GetFloat(type.ToString() + "Volume", 100f);
            print(type.ToString() + ": " + volume);
            SetVolumeAll(type, volume / 100f);
        }
    }
    public void Play(string id)
    {
        soundSources[id].Play();
    }
    public void SetVolume(string id, float volume)
    {
        soundSources[id].volume = volume;
    }
    public void SetVolumeAll(SoundInfo.SoundType type, float volume)
    {
        if (soundTypeGroups.TryGetValue(type, out List<string> list))
        {
            foreach (string soundId in list)
            {
                print(soundId + ": " + volume);
                SetVolume(soundId, volume);
            }
        }
    }
}
