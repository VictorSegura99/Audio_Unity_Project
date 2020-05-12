using System.Collections;
using System.Collections.Generic;
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


    // Start is called before the first frame update
    void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
