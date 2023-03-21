using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    public GameObject GameManager;
    public AudioSource[] audioSources;

    void Start()
    {
        audioSources = GameManager.GetComponents<AudioSource>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;

            if (isPaused)
            {
                audioSources[1].Pause();
            }
            else
            {
                audioSources[1].UnPause();
            }
        }
    }

    
}
