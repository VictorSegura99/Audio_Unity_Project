using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    // Start is called before the first frame update
    AudioManager audioManager;
    public Slider master;
    public Slider music;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        audioManager.SetMasterVolume(master.value);
        audioManager.SetMusicVolume(music.value);

    }
}
