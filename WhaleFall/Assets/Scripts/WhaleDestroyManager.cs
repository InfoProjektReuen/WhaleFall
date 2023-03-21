using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleDestroyManager : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject explosionAnimationPrefab;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (gameObject.CompareTag("GigaWal") || gameObject.CompareTag("NormalerWal"))
            {
                Vector3 collisionPoint = other.contacts[0].point;
                var explosionSound = Instantiate(explosionPrefab, collisionPoint, Quaternion.identity);
                var explosionAnimationObject = new GameObject("ExplosionAnimation");
                explosionAnimationObject.transform.position = collisionPoint;
                explosionAnimationObject.transform.localScale = Vector3.one;
                var explosionAnimation = Instantiate(explosionAnimationPrefab, explosionAnimationObject.transform);
                Destroy(explosionSound, 2);
                Destroy(explosionAnimationObject, 2);
            }
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 30);
    }
}
