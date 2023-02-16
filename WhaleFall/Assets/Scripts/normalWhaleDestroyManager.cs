using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalWhaleDestroyManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        { 
            Destroy(gameObject, 0.5f);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 30);
    }

    private void Update()
    {

    }
}
