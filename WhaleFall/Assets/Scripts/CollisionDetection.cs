using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameManager myGameManager;
    public HealthManager healthManager;
    public normalWhaleSpawnerManager nWSpwnManager;
    public gigaWhaleSpawnerManager gWSpwnManager;


    public int replaceIndex = 0;

    private void gameOverCheck()
    {
        if (healthManager.currentHealth <= 0)
        {
            myGameManager._gameOver = true;
            SceneManager.LoadScene("GameOverScreen");
            healthManager.refreshHealth();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("NormalerWal")) {
            healthManager.TakeDamage(nWSpwnManager.Damage);
            Destroy(other.gameObject);
            gameOverCheck();
        }
        else if (other.gameObject.CompareTag("GigaWal"))
        {
            healthManager.TakeDamage(gWSpwnManager.Damage);
            Destroy(other.gameObject);
            gameOverCheck();
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
