using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> type;

    private static AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound()
    {
        
    }
}

public enum Sounds
{
    NULL=-1,
    Footsteps=0,
    DoorOpen=1,
    DoorClose=2,
    ButtonPress=3
}
