using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandling : MonoBehaviour
{
    // Stores the sound effects, ordered as follows: jumping, landing and crashing sound.
    [SerializeField] private AudioClip[] sounds;

    private AudioSource audioSource;

    // Assign the audioSource the sound effect Audio Source.
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays the jump sound effect, overwrites current playing sound effect.
    /// </summary>
    public void JumpSound()
    {
        audioSource.clip = sounds[0];
        audioSource.Play();
    }

    /// <summary>
    /// Plays the landing sound effect, does not play if another sound plays.
    /// </summary>
    public void LandingSound()
    {
        if (audioSource.isPlaying) return;
        audioSource.clip = sounds[1];
        audioSource.Play();
    }

    /// <summary>
    /// Plays the crashing sound effect when the player hits a high Tile, does not play if another sound plays.
    /// </summary>
    public void CrashSound()
    {
        if (audioSource.isPlaying) return;
        audioSource.clip = sounds[2];
        audioSource.Play();
    }
}