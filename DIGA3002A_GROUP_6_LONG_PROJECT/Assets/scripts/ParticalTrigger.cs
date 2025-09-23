using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalTrigger : MonoBehaviour
{
    public MusicManager MusicManager;
    public AudioClip Background;
    
    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.tag == "Player") 
        {
            MusicManager.BackgroundMusic.clip = Background;
        }

        else 
        {
            MusicManager.BackgroundMusic.clip = MusicManager.NormalBackground;
        }
    }
}
