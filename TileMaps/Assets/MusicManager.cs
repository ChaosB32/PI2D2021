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
    [SerializeField] AudioClip audioClip;
    

    private void Start()
    {
        Play(audioClip);
    }

    public void Play(AudioClip musicToPlay)
    {
        audioSource.clip = musicToPlay;
        audioSource.Play();
    }
}
