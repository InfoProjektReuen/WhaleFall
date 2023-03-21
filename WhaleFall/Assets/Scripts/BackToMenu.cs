using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public PauseMenu myPauseMenu;
    
    public void _BackToMenu(){
        myPauseMenu.isPaused = ! myPauseMenu.isPaused;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("StartMenu");

    }
}
