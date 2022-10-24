using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip coinCollect, coinLeft, gameOverAudio;
    public AudioSource audioSource;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
        
    }
    public void PlayCoinCollectSound()
    {
        audioSource.PlayOneShot(coinCollect);
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverAudio);
    }

    public void PlayCoinLeftSound()
    {
        audioSource.PlayOneShot(coinLeft);
    }
}
