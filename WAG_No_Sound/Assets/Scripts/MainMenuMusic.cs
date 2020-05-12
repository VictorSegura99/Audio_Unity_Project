using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    AudioSource ac;
    AudioSource pre_intro;
    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioSource>();
        pre_intro = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        pre_intro.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pre_intro.isPlaying && !ac.isPlaying) 
        {
            ac.Play();
        }
    }
}
