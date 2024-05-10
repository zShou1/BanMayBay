using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [Header("Main Settings: ")] 
    [Range(0, 1)]
    public float musicVolume;

    [Range(0, 1)] 
    public float sfxVolume;

    public AudioSource sfxAus;
    public AudioSource musicAus;

    [Header("Game Sounds: ")] 
    public AudioClip explosionSfx;

    public AudioClip fireSfx;
    
    public AudioClip[] bgmusics;
    
    public static int VolumeOn
    {
        get
        {
            return PlayerPrefs.GetInt("volumeOn", 1);
        }
        set
        {
            PlayerPrefs.SetInt("volumeOn", value);
        }
    }
    public static int VibrateOn
    {
        get
        {
            return PlayerPrefs.GetInt("vibrateOn", 1);
        }
        set
        {
            PlayerPrefs.SetInt("vibrateOn", value);
        }
    }
    private void Start()
    {
        if(bgmusics==null||bgmusics.Length==0)
            return;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayMusic(bgmusics);
        }
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

    private void Update()
    {
        if (VolumeOn == 0)
        {
            sfxAus.volume = 0;
            musicAus.volume = 0;
        }
        else
        {
            sfxAus.volume = 1;
            musicAus.volume = 1;
        }
    }
}
