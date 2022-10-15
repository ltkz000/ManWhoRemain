using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    // [SerializeField] private Audio hitSound;
    // [SerializeField] private Audio throwSound;
    // [SerializeField] private Audio levelUpSound;
    // [SerializeField] private Audio deadSound;
    [SerializeField] private AudioSource loseSound;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource buttonClickSound;

    public void TurnOffSound()
    {
        AudioListener.pause = true;
    }

    public void TurnOnSound()
    {
        AudioListener.pause = false;
    }

    // public Audio GetHitSound()
    // {
    //     return hitSound;
    // }
    // public Audio GetThrowSound()
    // {
    //     return throwSound;
    // }
    // public Audio GetLevelUpSound()
    // {
    //     return levelUpSound;
    // }
    // public Audio GetDeadSound()
    // {
    //      return deadSound;
    // }
    public void PlayLoseSound()
    {
        loseSound.Play();
    }
    public void PlayWinSound()
    {
        winSound.Play();
    }
    public void PlayButtonClickSound()
    {
        buttonClickSound.Play();
    }
}
