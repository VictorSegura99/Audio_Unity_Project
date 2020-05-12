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
    }

    public void PlayFootstepSound()
    {
        if (!inWater)
        {
            materialChecker.CheckMaterial(gameObject); //This also sets the material if a SoundMaterial is found!
        }

        FootstepSound.Post(gameObject);

        // audio in engine
        m_audio[0].PlayOneShot(clipsManager.GetFootStepClip(materialChecker.GetMaterial().Name));

        if(inWater)
            m_audio[1].PlayOneShot(clipsManager.GetFootStepClip("Surface_Type / Water"));
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
