using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    [SerializeField] private GameObject glitchedBody;
    private static ResetScene _instance;
    public static Vector3 oldPlayerPosition;
    public ResetScene Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            glitchedBody = Instantiate(glitchedBody, oldPlayerPosition, Quaternion.identity);
            glitchedBody.tag = "GlitchedBody";
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReload();
        }
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
           SwapPositions();
        }
    }
    
    
    public void OnReload()
    {
        CharacterController player = FindObjectOfType<CharacterController>();
        oldPlayerPosition = player.transform.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    
    private void SwapPositions()
    {
        GameObject player = GameObject.FindWithTag("Player");
        CharacterController playerController = player.GetComponent<CharacterController>();
        Transform glitchBody = GameObject.FindWithTag("GlitchedBody").transform;
        playerController.enabled = false;
        (player.transform.position, glitchBody.position) = (glitchBody.position, player.transform.position);
        playerController.enabled = true;
    }
}
