////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneTrigger : MonoBehaviour
{
    public bool RuneReady = false;
    public bool PlayerInside = false;

    [Header("Text to change")]
    public Text holdText;
    public Text toChargeText;
    public GameObject helpTextCanvas;

    DefaultSpellcraft SpellScript;

    void Start()
    {
        SpellScript = FindObjectOfType<DefaultSpellcraft>(); 
        StartCoroutine(RuneSpellGiver());
        PlayerInside = false;
        RuneReady = false;

        EventManager.OnSpellReady += spellReady;
        EventManager.OnSpellNotReady += spellNotReady;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerInside = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerInside = false;
        }
    }

    public void SetHelptextVisibility(bool show)
    {
        helpTextCanvas.SetActive(show);
        SpellScript.Spellcraft[SpellScript.SpellSelect].IsAvailable = show;
    }

    public void RuneStatus(bool state)
    {
        RuneReady = state;
    }

    void spellReady()
    {
        holdText.text = LanguageManager.GetText("UI_release");
        toChargeText.text = LanguageManager.GetText("UI_toShootSpell");
    }

    void spellNotReady()
    {
        holdText.text = LanguageManager.GetText("UI_hold");
        toChargeText.text = LanguageManager.GetText("UI_toChargeSpell");
    }

    IEnumerator RuneSpellGiver()
    {
        while (true)
        {
            if (PlayerInside && RuneReady)
            {
                SpellScript.Spellcraft[SpellScript.SpellSelect].IsAvailable = true;
            }
            else
            {
                SpellScript.Spellcraft[SpellScript.SpellSelect].IsAvailable = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
