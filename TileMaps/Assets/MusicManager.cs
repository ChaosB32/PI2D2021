using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSourceP;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip audioClipNight;


    private void Start()
    {
        Play(audioClip);
        PlayP(audioClipNight);
    }

    public void Play(AudioClip musicToPlay)
    {
        audioSource.clip = musicToPlay;
        audioSource.volume = 0.2f;
        audioSource.Play();
    }
    public void PlayP(AudioClip musicToPlay)
    {
        audioSourceP.clip = musicToPlay;
        audioSourceP.volume = 1f;
        audioSourceP.Play();
    }
}
