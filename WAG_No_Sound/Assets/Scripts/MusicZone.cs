using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    MusicManager music_manager;

    public MusicManager.Music_Zone zone;

    // Start is called before the first frame update
    void Start()
    {
        music_manager = transform.parent.GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            music_manager.actual_zone = zone;
        }
    }
}
