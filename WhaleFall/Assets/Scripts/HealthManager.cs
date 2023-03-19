using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maximumHealth = 3;
    public int currentHealth;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        refreshHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void refreshHealth()
    {
        currentHealth = maximumHealth;
        gameManager.setHealth(currentHealth);
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        gameManager.setHealth(currentHealth);
    }

    public void LifeUp()
    {
        if (currentHealth <= 2)
        {
            currentHealth += 1;
            gameManager.setHealth(currentHealth);
        }
    }
}
