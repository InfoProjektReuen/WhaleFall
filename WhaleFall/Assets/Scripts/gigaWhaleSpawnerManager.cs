using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gigaWhaleSpawnerManager : MonoBehaviour
{
    public Camera Camera;
    public GameObject Player;
    public GameObject[] gigaWhalePrefabs;

    [SerializeField]
    private float SpawnRateMinimumGW = 2.2f;

    [SerializeField]
    private float SpawnRateMaximumGW = 6.2f;

    [SerializeField]
    private float gigaWhaleSpeedMinGW = 0.0001f;

    [SerializeField]
    private float gigaWhaleSpeedMaxGW = 0.001f;

    private float _nextSpawnTimeGW;

    private void DetermineNextSpawnTimeGW()
    {
        _nextSpawnTimeGW = Time.time + UnityEngine.Random.Range(SpawnRateMinimumGW, SpawnRateMaximumGW);
    }

    private void SpawnGigaWhale()
    {
        var prefabIndexToSpawn = Random.Range(0, gigaWhalePrefabs.Length);
        var prefabToSpawn = gigaWhalePrefabs[prefabIndexToSpawn];

        var gigaWhale = Instantiate(prefabToSpawn, transform);

        float yPosition;
        float xPosition;

        var halfWidth = Camera.orthographicSize + Camera.aspect; // halbe Breite von Spielfeld
        xPosition = Random.Range(-halfWidth - 4, halfWidth - 0.5f); // Wal spawnt auf ganzer Spielfeldbreite
        yPosition = (Camera.orthographicSize + 1); // Wal spawnt über Kamera

        var position = new Vector3(xPosition, yPosition, 0);
        gigaWhale.transform.position = position;

        // unterschiedliche Geschwindigkeit
        var direction = new Vector3(0, 1, 0);
        var speed = Random.Range(gigaWhaleSpeedMinGW, gigaWhaleSpeedMaxGW);

        var rigidbody = gigaWhale.GetComponent<Rigidbody2D>();

        rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);


    }
    private void Start()
    {
        DetermineNextSpawnTimeGW();
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTimeGW)
        {
            SpawnGigaWhale();
            DetermineNextSpawnTimeGW();
        }
    }
}
