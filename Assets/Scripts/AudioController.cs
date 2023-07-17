using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class AudioController : SingletonMonoBehaviour<AudioController>
{
    [Header("Main Settings:")] [Range(0, 1)]
    public float musicVolume;

    [Range(0, 1)] public float sfxVolume;
    public AudioSource musicAus;
    public AudioSource sfxAus;

    public AudioClip destroyEnemy;
    public AudioClip spawnBullet;
    
    public AudioClip[] bgmusics;
    [SerializeField] private GameObject[] panelsWinAndLose;

    private void Start()
    {
        /*PlayMusic(bgmusics);*/
    }

    public void PlaySound(AudioClip sound, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }

        if (aus)
        {
            aus.PlayOneShot(sound, sfxVolume);
        }
    }
    
    public void PlaySound(AudioClip sound, AudioSource aus, float volume)
    {
        aus = null;
        if (!aus)
        {
            aus = sfxAus;
        }

        if (aus)
        {
            aus.PlayOneShot(sound, volume);
        }
    }

    public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }

        if (aus)
        {
            int randIdx = Random.Range(0, sounds.Length);
            aus.PlayOneShot(sounds[randIdx], sfxVolume);
        }
    }

    public void PlayMusic(AudioClip music, bool loop = true)
    {
        musicAus.clip = music;
        musicAus.loop = loop;
        musicAus.volume = musicVolume;
        musicAus.Play();
    }

    public void PlayMusic(AudioClip[] musics, bool loop = true, bool isFinish = false)
    {
        int randIdx = Random.Range(0, musics.Length);
        musicAus.clip = musics[randIdx];
        musicAus.loop = loop;
        musicAus.volume = musicVolume;
        musicAus.Play();
        if (isFinish)
        {
            musicAus.Stop();
        }
    }
    
}