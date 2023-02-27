using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float BulletSpeed;

    private void Start()
    {
        Rigidbody.AddRelativeForce(new Vector2(0, BulletSpeed), ForceMode2D.Impulse);
        Rigidbody.gravityScale = 0;
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NormalerWal") || other.CompareTag("GigaWal"))
        {
            Destroy(other.gameObject); //Wal

            Destroy(gameObject); //Laser
        }
    }
}
