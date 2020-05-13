using System.Collections;
using System.Collections.Generic;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioClipsManager : MonoBehaviour
{
    private PlayerMovement m_playerMovement;

    // WALK
    [SerializeField] private AudioClip[] m_ClipFootStepsDirtWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsGrassWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsRubbleWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsSandWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsStoneWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsWaterWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsWoodWalk;
    // RUN
    [SerializeField] private AudioClip[] m_ClipFootStepsDirtRun;
    [SerializeField] private AudioClip[] m_ClipFootStepsGrassRun;
    [SerializeField] private AudioClip[] m_ClipFootStepsRubbleRun;
    [SerializeField] private AudioClip[] m_ClipFootStepsSandRun;
    [SerializeField] private AudioClip[] m_ClipFootStepsStoneRun;
    [SerializeField] private AudioClip[] m_ClipFootStepsWaterRun;
    [SerializeField] private AudioClip[] m_ClipFootStepsWoodRun;

    // WEAPONS
    [SerializeField] private AudioClip[] m_WeaponDagger;
    [SerializeField] private AudioClip[] m_WeaponSword;
    [SerializeField] private AudioClip[] m_WeaponAxe;
    [SerializeField] private AudioClip[] m_WeaponPickAxe;
    [SerializeField] private AudioClip[] m_WeaponHammer;

    // GENERAL IMPACT ON ENEMIES
    [SerializeField] private AudioClip[] m_EnemyEvilSpitPlantHurt;
    [SerializeField] private AudioClip[] m_EnemyEvilHeadHurt;
    [SerializeField] private AudioClip[] m_EnemyEvilCrawlerHurt;

    //[SerializeField] private AudioClip[][] m_WeaponClips;
    private Dictionary<WeaponTypes, Dictionary<string, AudioClip>> weaponClips;

    // audio source from player root
    //private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
      
        // create dictionary entries
        weaponClips = new Dictionary<WeaponTypes, Dictionary<string, AudioClip>>();
        // DAGGER
        weaponClips[WeaponTypes.Dagger] = new Dictionary<string, AudioClip>();
        weaponClips[WeaponTypes.Dagger]["Surface_Type / Dirt"] = m_WeaponDagger[0];
        weaponClips[WeaponTypes.Dagger]["Surface_Type / Grass"] = m_WeaponDagger[1];
        weaponClips[WeaponTypes.Dagger]["Surface_Type / Leaves"] = m_WeaponDagger[2];
        weaponClips[WeaponTypes.Dagger]["Surface_Type / Stone"] = m_WeaponDagger[3];
        weaponClips[WeaponTypes.Dagger]["Surface_Type / Wood"] = m_WeaponDagger[4];
        weaponClips[WeaponTypes.Dagger]["Surface_Type / Barrel"] = m_WeaponDagger[5]; // TODO: barrel and crate maybe additive and not exclusive
        weaponClips[WeaponTypes.Dagger]["Surface_Type / Crate"] = m_WeaponDagger[6];
        // SWORD
        weaponClips[WeaponTypes.Sword] = new Dictionary<string, AudioClip>();
        weaponClips[WeaponTypes.Sword]["Surface_Type / Dirt"] =     m_WeaponSword[0];
        weaponClips[WeaponTypes.Sword]["Surface_Type / Grass"] =    m_WeaponSword[1];
        weaponClips[WeaponTypes.Sword]["Surface_Type / Leaves"] =   m_WeaponSword[2];
        weaponClips[WeaponTypes.Sword]["Surface_Type / Stone"] =    m_WeaponSword[3];
        weaponClips[WeaponTypes.Sword]["Surface_Type / Wood"] =     m_WeaponSword[4];
        weaponClips[WeaponTypes.Sword]["Surface_Type / Barrel"] =   m_WeaponSword[5]; 
        weaponClips[WeaponTypes.Sword]["Surface_Type / Crate"] =    m_WeaponSword[6];
        // AXE
        weaponClips[WeaponTypes.Axe] = new Dictionary<string, AudioClip>();
        weaponClips[WeaponTypes.Axe]["Surface_Type / Dirt"] =   m_WeaponAxe[0];
        weaponClips[WeaponTypes.Axe]["Surface_Type / Grass"] =  m_WeaponAxe[1];
        weaponClips[WeaponTypes.Axe]["Surface_Type / Leaves"] = m_WeaponAxe[2];
        weaponClips[WeaponTypes.Axe]["Surface_Type / Stone"] =  m_WeaponAxe[3];
        weaponClips[WeaponTypes.Axe]["Surface_Type / Wood"] =   m_WeaponAxe[4];
        weaponClips[WeaponTypes.Axe]["Surface_Type / Barrel"] = m_WeaponAxe[5]; 
        weaponClips[WeaponTypes.Axe]["Surface_Type / Crate"] =  m_WeaponAxe[6];
        // PICKAXE
        weaponClips[WeaponTypes.PickAxe] = new Dictionary<string, AudioClip>();
        weaponClips[WeaponTypes.PickAxe]["Surface_Type / Dirt"] =   m_WeaponPickAxe[0];
        weaponClips[WeaponTypes.PickAxe]["Surface_Type / Grass"] =  m_WeaponPickAxe[1];
        weaponClips[WeaponTypes.PickAxe]["Surface_Type / Leaves"] = m_WeaponPickAxe[2];
        weaponClips[WeaponTypes.PickAxe]["Surface_Type / Stone"] =  m_WeaponPickAxe[3];
        weaponClips[WeaponTypes.PickAxe]["Surface_Type / Wood"] =   m_WeaponPickAxe[4];
        weaponClips[WeaponTypes.PickAxe]["Surface_Type / Barrel"] = m_WeaponPickAxe[5]; 
        weaponClips[WeaponTypes.PickAxe]["Surface_Type / Crate"] =  m_WeaponPickAxe[6];
        // HAMMER
        weaponClips[WeaponTypes.Hammer] = new Dictionary<string, AudioClip>();
        weaponClips[WeaponTypes.Hammer]["Surface_Type / Dirt"] =    m_WeaponHammer[0];
        weaponClips[WeaponTypes.Hammer]["Surface_Type / Grass"] =   m_WeaponHammer[1];
        weaponClips[WeaponTypes.Hammer]["Surface_Type / Leaves"] =  m_WeaponHammer[2];
        weaponClips[WeaponTypes.Hammer]["Surface_Type / Stone"] =   m_WeaponHammer[3];
        weaponClips[WeaponTypes.Hammer]["Surface_Type / Wood"] =    m_WeaponHammer[4];
        weaponClips[WeaponTypes.Hammer]["Surface_Type / Barrel"] =  m_WeaponHammer[5];
        weaponClips[WeaponTypes.Hammer]["Surface_Type / Crate"] =   m_WeaponHammer[6];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip GetWeaponImpact(string materialName, WeaponTypes weaponType)
    {
        Debug.Log(materialName + "," + weaponType);

        // check impact on enemies first
        switch (materialName)
        {
            case "Surface_Type / Enemy_EvilSpitPlant":
                return m_EnemyEvilSpitPlantHurt[Random.Range(0, m_EnemyEvilSpitPlantHurt.Length)];
            case "Surface_Type / Enemy_HeadBite":
                return m_EnemyEvilHeadHurt[Random.Range(0, m_EnemyEvilHeadHurt.Length)];
            case "Surface_Type / Enemy_EvilCrawler":
                return m_EnemyEvilCrawlerHurt[Random.Range(0, m_EnemyEvilCrawlerHurt.Length)];
        }

        return weaponClips[weaponType][materialName];
    }

    public AudioClip GetFootStepClip(string materialName, out float out_volume)
    {
        float speed = m_playerMovement.GetSpeed();
        float maxSpeed = m_playerMovement.maxSpeed;
        bool isRunning = speed > maxSpeed;

        // picks max possible current and normalize based on it (results in max vol when walk for walk and same for run)
        float max_v = isRunning ? m_playerMovement.sprintSpeed : maxSpeed; 
        out_volume =  Mathf.Min(speed * (1.0f / max_v), 1.0f);

        switch (materialName)
        {
            case "Surface_Type / Dirt":
                return isRunning ? m_ClipFootStepsDirtRun[Random.Range(0, m_ClipFootStepsDirtRun.Length)] : m_ClipFootStepsDirtWalk[Random.Range(0, m_ClipFootStepsDirtWalk.Length)];
            case "Surface_Type / Grass":
                return isRunning ? m_ClipFootStepsGrassRun[Random.Range(0, m_ClipFootStepsGrassRun.Length)] : m_ClipFootStepsGrassWalk[Random.Range(0, m_ClipFootStepsGrassWalk.Length)];
            case "Surface_Type / Rubble":
                return isRunning ? m_ClipFootStepsRubbleRun[Random.Range(0, m_ClipFootStepsRubbleRun.Length)] : m_ClipFootStepsRubbleWalk[Random.Range(0, m_ClipFootStepsRubbleWalk.Length)];
            case "Surface_Type / Sand":
                return isRunning ? m_ClipFootStepsSandRun[Random.Range(0, m_ClipFootStepsSandRun.Length)] : m_ClipFootStepsSandWalk[Random.Range(0, m_ClipFootStepsSandWalk.Length)];
            case "Surface_Type / Stone":
                return isRunning ? m_ClipFootStepsStoneRun[Random.Range(0, m_ClipFootStepsStoneRun.Length)] : m_ClipFootStepsStoneWalk[Random.Range(0, m_ClipFootStepsStoneWalk.Length)];
            case "Surface_Type / Water":
                return isRunning ? m_ClipFootStepsWaterRun[Random.Range(0, m_ClipFootStepsWaterRun.Length)] : m_ClipFootStepsWaterWalk[Random.Range(0, m_ClipFootStepsWaterWalk.Length)];
            case "Surface_Type / Wood":
                return isRunning ? m_ClipFootStepsWoodRun[Random.Range(0, m_ClipFootStepsWoodRun.Length)] : m_ClipFootStepsWoodWalk[Random.Range(0, m_ClipFootStepsWoodWalk.Length)];
        }

        return null;
    }
}
