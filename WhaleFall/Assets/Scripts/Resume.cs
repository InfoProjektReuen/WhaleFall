using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject pauseMenu;
    public PauseMenu myPauseMenu;

    public GameObject GameManager;
    public AudioSource[] audioSources;

    void Start()
    {
        audioSources = GameManager.GetComponents<AudioSource>();
    }

    public void _Resume(){
        myPauseMenu.isPaused = !myPauseMenu.isPaused;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        audioSources[1].UnPause();
    }
}
