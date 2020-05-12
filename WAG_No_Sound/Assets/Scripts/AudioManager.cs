using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    [HideInInspector]public AudioMixerGroup masterGroup;
    [HideInInspector]public AudioMixerGroup musicGroup;
    [HideInInspector] public AudioMixerGroup sfxGroup;
    [HideInInspector]public AudioMixerGroup uiGroup;
    [HideInInspector]public AudioMixerGroup worldGroup;
    [HideInInspector]public AudioMixerSnapshot indoorSnapshot;
    [HideInInspector]public AudioMixerSnapshot outdoorSnapshot;

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
        
    }
    public void PlayerIndoor() // When player enter ReverbZone
    {
        indoorSnapshot.TransitionTo(1.0f);
    }
    public void PlayerOutdoor() // When player exit ReverbZone
    {
        outdoorSnapshot.TransitionTo(1.0f);
    }
}