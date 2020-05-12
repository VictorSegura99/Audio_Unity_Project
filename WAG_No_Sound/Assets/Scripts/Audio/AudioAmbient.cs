using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbient : MonoBehaviour
{
    public AudioClip audioClip;
    public float minDistance = 0.8f;
    public float maxDistance = 2.9f;

    private AudioSource audioSource;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioManager.sfxGroup;
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.minDistance = minDistance;
        audioSource.maxDistance = maxDistance;
        audioSource.spatialBlend = 1.0f;
        audioSource.volume = 0.8f;
        audioSource.PlayDelayed(Random.Range(0.0f, 4.0f));
    }
}
