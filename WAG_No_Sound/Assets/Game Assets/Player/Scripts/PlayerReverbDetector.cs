using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerReverbDetector : MonoBehaviour
{
    private AudioManager audioManager;
    private bool isInDoor = false;
    private bool detectedZone = false;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (!detectedZone && isInDoor)
        {
            audioManager.PlayerOutdoor();
            isInDoor = false;
        }
            
        if (detectedZone && !isInDoor)
        {
            isInDoor = true;
            audioManager.PlayerIndoor();
        }
        
        detectedZone = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("ReverbZone"))
            detectedZone = true;
    }

}
