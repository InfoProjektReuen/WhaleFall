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
    public GameObject globalLightObject;

    public bool sceneLoaded = false;

    public AudioSource hitSFX;
    public AudioSource deadSFX;


    private void gameOverCheck()
    {
        if (healthManager.currentHealth <= 0)
        {
            myGameManager._gameOver = true;
            SceneManager.LoadScene("GameOverScreen");
           /* while (!sceneLoaded)
            {
                if(SceneManager.GetActiveScene().name == "GameOverScreen")
                {
                    sceneLoaded = true;
                    deadSFX.Play();
                }
            }*/
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("NormalerWal")) {
            healthManager.TakeDamage(nWSpwnManager.Damage);
            Destroy(other.gameObject);
            StartCoroutine(deactivateLight());
            if(healthManager.currentHealth >= 1)
            {
                hitSFX.Play();
            }
            gameOverCheck();
        }
        else if (other.gameObject.CompareTag("GigaWal"))
        {
            healthManager.TakeDamage(gWSpwnManager.Damage);
            Destroy(other.gameObject);
            StartCoroutine(deactivateLight());
            if (healthManager.currentHealth >= 1)
            {
                hitSFX.Play();
            }
            gameOverCheck();
        }
        else if (other.gameObject.CompareTag("LifeUp"))
        {
            healthManager.LifeUp();
            Destroy(other.gameObject);
        }
        
    }

    private IEnumerator deactivateLight()
    {
        globalLightObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        globalLightObject.SetActive(false);
    }
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
