using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioClipsManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] m_ClipFootStepsDirtWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsGrassWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsRubbleWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsSandWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsStoneWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsWaterWalk;
    [SerializeField] private AudioClip[] m_ClipFootStepsWoodWalk;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip GetFootStepClip(string materialName)
    {

        Debug.Log(materialName);

        switch(materialName)
        {
            case "Surface_Type / Dirt":
                return m_ClipFootStepsDirtWalk[Random.Range(0, m_ClipFootStepsDirtWalk.Length)];
            case "Surface_Type / Grass":
                return m_ClipFootStepsGrassWalk[Random.Range(0, m_ClipFootStepsGrassWalk.Length)];
            case "Surface_Type / Rubble":
                return m_ClipFootStepsRubbleWalk[Random.Range(0, m_ClipFootStepsRubbleWalk.Length)];
            case "Surface_Type / Sand":
                return m_ClipFootStepsSandWalk[Random.Range(0, m_ClipFootStepsSandWalk.Length)];
            case "Surface_Type / Stone":
                return m_ClipFootStepsStoneWalk[Random.Range(0, m_ClipFootStepsStoneWalk.Length)];
            case "Surface_Type / Water":
                return m_ClipFootStepsWaterWalk[Random.Range(0, m_ClipFootStepsWaterWalk.Length)];
            case "Surface_Type / Wood":
                return m_ClipFootStepsWoodWalk[Random.Range(0, m_ClipFootStepsWoodWalk.Length)];
        }

        return null;
    }
}
