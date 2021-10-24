using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private float nextScene;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene($"Level{nextScene}");
    }
}
