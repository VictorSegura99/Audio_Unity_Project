////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSequence : MonoBehaviour
{
    [System.Serializable]
    public struct CameraBlock
    {
        public Camera cam;
        public float transitionTime;
        public float holdTime;
        public List<GameObject> UIObjectsToFadeIn;
        public List<GameObject> UIObjectsToFadeOut;
    }

    [Header("Sequence Settings")]
    public List<CameraBlock> CameraSequence;
    public float delayBeforeFadeIn = 3f;

    [Header("Other")]
    public GameObject FadeCanvas;

    AudioSource audioSource;

    public AK.Wwise.Event MusicEvent;
    #region private variables
    private Animator canvAnim;
    private PlayerCamera camScript;
    private readonly int fadeOutHash = Animator.StringToHash("FadeOut");
    #endregion

    private void Awake()
    {
    }

    void Start()
    {
        InputManager.OnMenuDown += SkipCredits;
        camScript = Camera.main.GetComponent<PlayerCamera>();

        if (FadeCanvas == null)
        {
            FadeCanvas = GameObject.Find("FadeCanvas");
        }

        FadeCanvas.SetActive(true);
        canvAnim = FadeCanvas.GetComponent<Animator>();

        StartCoroutine(CreditsCameraSequence());

        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator CreditsCameraSequence()
    {
        for (int i = 0; i < CameraSequence.Count; i++)
        {
            CameraBlock c = CameraSequence[i];
            camScript.ChangeCamera(new PlayerCamera.CameraEvent(c.cam.GetComponent<Camera>(), c.transitionTime, c.holdTime, false));

            //fade in objects
            for (int j = 0; j < c.UIObjectsToFadeIn.Count; j++)
            {
                CanvasGroup g = c.UIObjectsToFadeIn[j].GetComponent<CanvasGroup>();
                StartCoroutine(FadeInUIElement(g));
                yield return new WaitForSeconds(0.5f);
            }

            //fade out objects
            for (int j = 0; j < c.UIObjectsToFadeOut.Count; j++)
            {
                CanvasGroup g = c.UIObjectsToFadeOut[j].GetComponent<CanvasGroup>();
                StartCoroutine(FadeOutUIElement(g));
            }

            yield return new WaitForSeconds(c.holdTime + c.transitionTime);

            if (i == CameraSequence.Count - 2)
            {
                canvAnim.SetTrigger(fadeOutHash);
            }
        }
    }

    IEnumerator FadeInUIElement(CanvasGroup g)
    {
        yield return new WaitForSeconds(delayBeforeFadeIn);
        for (float i = 0; i < 1; i += Time.deltaTime / 4f)
        {
            g.alpha = i;
            yield return null;
        }
        g.alpha = 1f;
    }

    IEnumerator FadeOutUIElement(CanvasGroup g)
    {
        for (float i = 1; i > 0; i -= Time.deltaTime / 3f)
        {
            g.alpha = i;
            yield return null;
        }
        g.alpha = 0f;
    }

    public void SkipCredits()
    {
        canvAnim.speed = 5f;
        canvAnim.SetTrigger(fadeOutHash);

        // To DO: Start Fade
        StartCoroutine(audio_waiting_to_end());
    }

    private void OnDestroy()
    {
        InputManager.OnMenuDown -= SkipCredits;
    }

    IEnumerator audio_waiting_to_end()
    {
        while (audioSource.volume > 0.0f)
        {
            audioSource.volume -= audioSource.volume * (Time.deltaTime);
            Debug.Log("Volume: " + audioSource.volume.ToString());
            yield return new WaitForEndOfFrame();
        }
    }
}
