using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleDestroyManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        { 
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 30);
    }

    public void WhaleDestroy()
    {
        Destroy(gameObject);
    }
}
