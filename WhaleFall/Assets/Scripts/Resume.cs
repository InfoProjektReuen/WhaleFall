using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject pauseMenu;
    public PauseMenu myPauseMenu;
    
    public void _Resume(){
        myPauseMenu.isPaused = !myPauseMenu.isPaused;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
