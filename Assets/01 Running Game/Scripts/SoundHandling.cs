using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandling : MonoBehaviour
{

    [SerializeField] private AudioClip[] sounds;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void JumpSound()
    {
        audioSource.clip = sounds[0];
        audioSource.Play();
    }
    
    public void LandingSound()
    {
        if (audioSource.isPlaying) return;
        audioSource.clip = sounds[1];
        audioSource.Play();
    }
    
    public void CrashSound()
    {
        if (audioSource.isPlaying) return;
        audioSource.clip = sounds[2];
        audioSource.Play();
    }
}
