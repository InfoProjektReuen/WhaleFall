using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalWhaleSpawnerManager : MonoBehaviour
{
    public Camera Camera;
    public GameObject Player;
    public GameObject[] NormalWhalePrefabs;

    public float SpawnRateMinimum = 0.5f;
    public float SpawnRateMaximum = 1.5f;

    public float normalWhaleSpeedMin = 0.5f;
    public float normalWhaleSpeedMax = 3;

    private float _nextSpawnTime;

    private void DetermineNextSpawnTime()
    {
        _nextSpawnTime = Time.time + UnityEngine.Random.Range(SpawnRateMinimum, SpawnRateMaximum);
    }

    private void SpawnNormalWhale()
    {
        var prefabIndexToSpawn = Random.Range(0, NormalWhalePrefabs.Length);
        var prefabToSpawn = NormalWhalePrefabs[prefabIndexToSpawn];

        var normalWhale = Instantiate(prefabToSpawn, transform);

        float yPosition;
        float xPosition;

        var halfWidth = Camera.orthographicSize + Camera.aspect; // halbe Breite von Spielfeld
        xPosition = Random.Range(-halfWidth + 2, 2 * halfWidth -2); // Wal spawnt auf ganzer Spielfeldbreite

        yPosition = (Camera.orthographicSize + 1); // Wal spawnt über Kamera

        var position = new Vector3(xPosition, yPosition, 0);
        normalWhale.transform.position = position;

        // unterschiedliche Geschwindigkeit
        var direction = new Vector3(0, 1, 0);
        var speed = Random.Range(normalWhaleSpeedMin, normalWhaleSpeedMax);

        var rigidbody = normalWhale.GetComponent<Rigidbody2D>();

        rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);
        

    }
    private void Start()
    {
        DetermineNextSpawnTime();
    }
    
    private void Update ()
    {
        if(Time.time >= _nextSpawnTime)
        {
            SpawnNormalWhale();
            DetermineNextSpawnTime();
        }
    }
}
