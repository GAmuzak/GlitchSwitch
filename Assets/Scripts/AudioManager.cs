using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static List<AudioClip> type=new List<AudioClip>();

    private static AudioSource _audioSource;

    private void Start()
    {
        type.Add(Resources.Load<AudioClip>("AudioClips/DoorOpen"));
        type.Add(Resources.Load<AudioClip>("AudioClips/DoorClose"));
        type.Add(Resources.Load<AudioClip>("AudioClips/ButtonPress"));
        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(Sound sound)
    {
        switch (sound)
        {
            case Sound.DoorOpen:
                _audioSource.PlayOneShot(type[0]);
                break;
            case Sound.DoorClose:
                _audioSource.PlayOneShot(type[1]);
                break;
            case Sound.ButtonPress:
                _audioSource.PlayOneShot(type[2]);
                break;
        }
    }
}

public enum Sound
{
    NULL=-1,
    DoorOpen=0,
    DoorClose=1,
    ButtonPress=2
}
