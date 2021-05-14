using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject audioSourcePrefab;
    [SerializeField] int audioSourceCount;

    List<AudioSource> audioSources;

    [SerializeField] GameObject audioSourceWalkPrefab;
    [SerializeField] int audioSourceWalkCount;

    List<AudioSource> audioSourcesWalk;

    private void Start()
    {
        Init();
        InitWalk();
    }

    private void Init()
    {
        audioSources = new List<AudioSource>();

        for (int i = 0; i < audioSourceCount; i++)
        {
            GameObject go = Instantiate(audioSourcePrefab, transform);
            go.transform.localPosition = Vector3.zero;
            audioSources.Add(go.GetComponent<AudioSource>());
        }
    }
    private void InitWalk()
    {
        audioSourcesWalk = new List<AudioSource>();

        for (int i = 0; i < audioSourceWalkCount; i++)
        {
            GameObject go = Instantiate(audioSourceWalkPrefab, transform);
            go.transform.localPosition = Vector3.zero;
            audioSourcesWalk.Add(go.GetComponent<AudioSource>());
        }
    }

    public void Play(AudioClip audioClip)
    {
        AudioSource audioSource = GetFreeAudioSource();

        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void Stop(AudioClip audioClip)
    {
        AudioSource audioSource = GetUsedAudioSource();

        audioSource.clip = audioClip;
        audioSource.Stop();
    }
    //walk
    public void PlayWalk(AudioClip audioClip)
    {
        AudioSource audioSourceWalk = GetFreeAudioSourceWalk();

        audioSourceWalk.clip = audioClip;
        audioSourceWalk.Play();
    }

    public void StopWalk(AudioClip audioClip)
    {
        AudioSource audioSourceWalk = GetUsedAudioSourceWalk();

        audioSourceWalk.clip = audioClip;
        audioSourceWalk.Stop();
    }

    private AudioSource GetFreeAudioSource()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (audioSources[i].isPlaying == false)
            {
                return audioSources[i];
            }
        }
        return audioSources[0];
    }
    private AudioSource GetUsedAudioSource()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (audioSources[i].isPlaying == true)
            {
                return audioSources[i];
            }
        }
        return audioSources[0];
    }
    //walk
    private AudioSource GetFreeAudioSourceWalk()
    {
        for (int i = 0; i < audioSourcesWalk.Count; i++)
        {
            if (audioSourcesWalk[i].isPlaying == false)
            {
                return audioSourcesWalk[i];
            }
        }
        return audioSourcesWalk[0];

    }
    private AudioSource GetUsedAudioSourceWalk()
    {
        for (int i = 0; i < audioSourcesWalk.Count; i++)
        {
            if (audioSourcesWalk[i].isPlaying == true)
            {
                return audioSourcesWalk[i];
            }
        }
        return audioSourcesWalk[0];
    }
}
