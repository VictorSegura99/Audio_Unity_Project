using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public enum Music_Zone
    {
        VILLAGE,
        FOREST,
        CAVE,
        DESERT,
        VOLCANIC,

        NONE
    }

    [HideInInspector]
    bool is_day = true;
    bool actual_time_day = true;

    [HideInInspector]
    public Music_Zone actual_zone = Music_Zone.NONE;

    Music_Zone zone_sounding = Music_Zone.NONE;

    // Day
    AudioClip village_day;
    AudioClip cave;
    AudioClip forest_day;
    AudioClip volcanic_day;
    AudioClip desert_day;

    // Night
    AudioClip village_night;
    AudioClip forest_night;
    AudioClip volcanic_night;
    AudioClip desert_night;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        village_day = (AudioClip) Resources.Load("Music_Ambient_Mix");
        cave = (AudioClip)Resources.Load("Music_Cave_Mix");
        forest_day = (AudioClip) Resources.Load("Music_Forest_Mix");
        volcanic_day = (AudioClip) Resources.Load("Music_Volcanic_Mix");
        desert_day = (AudioClip) Resources.Load("Music_Desert_Mix");

        village_night = (AudioClip)Resources.Load("Flute");
        forest_night = (AudioClip) Resources.Load("Music_NightTime_Woodlands");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (actual_zone != zone_sounding || is_day != actual_time_day)  
        {
            actual_time_day = is_day;
            zone_sounding = actual_zone;

            switch (zone_sounding)
            {
                case Music_Zone.VILLAGE:
                    {
                        if (is_day)
                        {
                            audioSource.clip = village_day;
                        }
                        else
                        {
                            audioSource.clip = village_night;
                        }

                        break;
                    }
                case Music_Zone.CAVE:
                    {
                        audioSource.clip = cave;
                        break;
                    }
                case Music_Zone.FOREST:
                    {
                        if (is_day)
                        {
                            audioSource.clip = forest_day;
                        }
                        else
                        {
                            audioSource.clip = forest_night;
                        }
                        break;
                    }
                case Music_Zone.VOLCANIC:
                    {
                        audioSource.clip = volcanic_day;
                        break;
                    }
                case Music_Zone.DESERT:
                    {
                        audioSource.clip = desert_day;
                        break;
                    }
            }
           audioSource.Play();
        }
    }

    public void SetDayTime(bool is_day)
    {
        this.is_day = is_day;
    }
}
