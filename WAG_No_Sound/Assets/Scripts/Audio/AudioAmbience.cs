using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAmbience : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip audioClip;
    private AudioSource audioSource;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioManager.sfxGroup;
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
