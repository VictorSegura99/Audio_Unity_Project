////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    public MaterialChecker materialChecker;
    public AK.Wwise.Event FootstepSound;

    #region private variables
    private bool inWater;
    #endregion

    [Header("Unity Audio Exercise InEngine")]
    private AudioSource[] m_audio;
    private PlayerAudioClipsManager clipsManager;

    private void Start()
    {
        m_audio = GetComponents<AudioSource>();
        clipsManager = GetComponentInParent<PlayerAudioClipsManager>();

        AudioManager audioManager = FindObjectOfType<AudioManager>();
        foreach (AudioSource source in m_audio)
        {
            source.outputAudioMixerGroup = audioManager.worldGroup;
        }
    }

    public void PlayFootstepSound()
    {
        if (!inWater)
        {
            materialChecker.CheckMaterial(gameObject); //This also sets the material if a SoundMaterial is found!
        }

        FootstepSound.Post(gameObject);

        // * ----------- audio in engine ------
        float vol = 1.0f;
        AudioClip clip = clipsManager.GetFootStepClip(materialChecker.GetMaterial().Name, out vol);
        m_audio[0].PlayOneShot(clip, vol); 

        if(inWater) {
            clip = clipsManager.GetFootStepClip("Surface_Type / Water", out vol);
            m_audio[1].PlayOneShot(clip, vol);
        }
        // * -----------------------------------
    }

    public void EnterWaterZone()
    {
      inWater = true;
    }

    public void ExitWaterZone()
    {
        inWater = false;
    }

}
