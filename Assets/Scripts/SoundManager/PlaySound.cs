using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip musicToPlay;
    [SerializeField] private bool shouldPlayMusic = false;

    private void Start()
    {
        //Joue de la musique au lancement
        SoundManager.Instance.PlayMusic(musicToPlay);
    }

    public void PlayOnClick(AudioClip soundToPlay)
    {
        SoundManager.Instance.PlaySound(soundToPlay);
    }

}
