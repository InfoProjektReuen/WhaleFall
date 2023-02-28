using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float BulletSpeed;

    public GameManager myGameManager;

    private void Start()
    {
        myGameManager = FindObjectOfType<GameManager>();
        Rigidbody.AddRelativeForce(new Vector2(0, BulletSpeed), ForceMode2D.Impulse);
        Rigidbody.gravityScale = 0;
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NormalerWal"))
        {
            Destroy(other.gameObject); //Wal

            Destroy(gameObject); //Laser

            myGameManager._score += 5;
            PlayerPrefs.SetInt("Score", myGameManager._score);
            PlayerPrefs.Save();
        }
        else if (other.CompareTag("GigaWal"))
        {
            Destroy(other.gameObject); //Wal

            Destroy(gameObject); //Laser

            myGameManager._score += 10;
            PlayerPrefs.SetInt("Score", myGameManager._score);
            PlayerPrefs.Save();
        }
    }
}
