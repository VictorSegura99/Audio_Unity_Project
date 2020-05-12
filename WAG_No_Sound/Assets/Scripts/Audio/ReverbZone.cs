using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZone : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            audioManager.PlayerIndoor();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            audioManager.PlayerOutdoor();
    }
}
