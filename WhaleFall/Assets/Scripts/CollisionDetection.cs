using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameManager myGameManager;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("NormalerWal")) {
            myGameManager._gameOver = true;
            SceneManager.LoadScene("GameOverScreen");
        }
        if (other.gameObject.CompareTag("GigaWal"))
        {
            myGameManager._gameOver = true;
            SceneManager.LoadScene("GameOverScreen");
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
