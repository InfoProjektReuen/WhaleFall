using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float BulletSpeed;

    public GameManager myGameManager;

    public GameObject explosionPrefab;
    public GameObject explosionAnimationPrefab;

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
            PlayExplosion(other, gameObject);

            Destroy(other.gameObject); //Wal

            Destroy(gameObject); //Laser

            myGameManager._score += 5;
            PlayerPrefs.SetInt("Score", myGameManager._score);
            PlayerPrefs.Save();
        }
        else if (other.CompareTag("GigaWal"))
        {
            PlayExplosion(other, gameObject);

            Destroy(other.gameObject); //Wal

            Destroy(gameObject); //Laser

            myGameManager._score += 10;
            PlayerPrefs.SetInt("Score", myGameManager._score);
            PlayerPrefs.Save();
        }
    }
    
    public void PlayExplosion(Collider2D whale, GameObject bullet)
    {
        Vector3 collisionPoint = gameObject.transform.position;
        var explosionSound = Instantiate(explosionPrefab, collisionPoint, Quaternion.identity);
        var explosionAnimationObject = new GameObject("ExplosionAnimation");
        explosionAnimationObject.transform.position = collisionPoint;
        explosionAnimationObject.transform.localScale = Vector3.one;
        var explosionAnimation = Instantiate(explosionAnimationPrefab, explosionAnimationObject.transform);
        Destroy(explosionSound, 2);
        Destroy(explosionAnimationObject, 2);
    }
}
