using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbient : MonoBehaviour
{
    public bool isSpatial = true;
    public bool randomDelay = true;
    private AudioSource audioSource;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioManager.worldGroup;

        if (isSpatial)
        {
            audioSource.spatialBlend = 1.0f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
        }
        if (randomDelay)
        {
            audioSource.PlayDelayed(Random.Range(0.0f, 4.0f));
        }
        else
        {
            audioSource.Play();
        }
    }
}
