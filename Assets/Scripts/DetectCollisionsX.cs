using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    //variables utilisé 
    private AudioSource playAudio;
    public AudioClip objectSound;
    void Start()
    {
        //on va chercher l'audio source
        playAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //audio clip
        playAudio.PlayOneShot(objectSound, 1f);
    }
}
