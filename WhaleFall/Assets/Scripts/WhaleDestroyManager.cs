using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleDestroyManager : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (gameObject.CompareTag("GigaWal") || gameObject.CompareTag("NormalerWal")){
                var test = Instantiate(explosionPrefab, transform);
                test.transform.SetParent(null);
                Destroy(test, 2);
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
