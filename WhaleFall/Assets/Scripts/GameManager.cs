using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject HealthContainer;
    public GameObject Leben;
    public GameObject emptyLivePrefab;
    public HealthManager healthManager;
    public CollisionDetection collisionDetection;
    
    public bool _gameOver;
    public int _score;

    public int emptyLives = -1;

    public GameObject globalLightObject;

    public AudioSource mainMenuMusic;
    public AudioSource gameMusic;

    public bool playingMainMenu = false;
    public bool playingGameMusic = false;

    void Start()
    {
        _score = 0;
        if (SceneManager.GetActiveScene().name == "main Scene") {
            globalLightObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "StartMenu" && !playingMainMenu)
        {
            setFalse(playingGameMusic);
            playMainMenuMusic();
        }
        else if(SceneManager.GetActiveScene().name == "main Scene" && !playingGameMusic)
        {
            setFalse(playingMainMenu);
            playGameMusic();
        }
    }

    public void setHealth(int health)
    {
        for (int i = HealthContainer.transform.childCount - 1; i >= 0; i--)
        {
            var child = HealthContainer.transform.GetChild(i);
            Destroy(child.gameObject);
        }

        for (int i = 0; i < health; i++)
        {
            Instantiate(Leben, HealthContainer.transform);
        }
    }


    //Game-Music
    private void playMainMenuMusic()
    {
        mainMenuMusic.Play();
        playingMainMenu = true;
    }

    private void playGameMusic()
    {
        gameMusic.Play();
        playingGameMusic = true;
    }

    private void setFalse(bool variable)
    {
        variable = false;
    }
}
