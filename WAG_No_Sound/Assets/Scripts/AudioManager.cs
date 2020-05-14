using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    [HideInInspector] public AudioMixerGroup masterGroup;
    [HideInInspector] public AudioMixerGroup musicGroup;
    [HideInInspector] public AudioMixerGroup sfxGroup;
    [HideInInspector] public AudioMixerGroup uiGroup;
    [HideInInspector] public AudioMixerGroup worldGroup;
    [HideInInspector] public AudioMixerSnapshot indoorSnapshot;
    [HideInInspector] public AudioMixerSnapshot outdoorSnapshot;
    [HideInInspector] public float maxMasterVol;
    [HideInInspector] public float maxMusicVol;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        masterGroup = audioMixer.FindMatchingGroups("Master")[0];
        musicGroup = audioMixer.FindMatchingGroups("Music")[0];
        sfxGroup = audioMixer.FindMatchingGroups("Sfx")[0];
        worldGroup = audioMixer.FindMatchingGroups("World")[0];
        uiGroup = audioMixer.FindMatchingGroups("Ui")[0];
        indoorSnapshot = audioMixer.FindSnapshot("Indoor");
        outdoorSnapshot = audioMixer.FindSnapshot("Outdoor");
        audioMixer.GetFloat("MasterVol", out maxMasterVol);
        audioMixer.GetFloat("MusicVol", out maxMusicVol);
    }
    public void PlayerIndoor() // When player enter ReverbZone
    {
        indoorSnapshot.TransitionTo(1.0f);
    }
    public void PlayerOutdoor() // When player exit ReverbZone
    {
        outdoorSnapshot.TransitionTo(1.0f);
    }

    public void SetMasterVolume(float vol)
    {
       audioMixer.SetFloat("MasterVol", map (vol, 0, 100, -40 , maxMasterVol));
    }

    public void SetMusicVolume(float vol)
    {
        audioMixer.SetFloat("MusicVol", map(vol, 0, 100, -40, maxMusicVol));
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

}