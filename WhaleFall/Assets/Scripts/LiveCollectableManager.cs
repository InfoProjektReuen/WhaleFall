using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveCollectableManager : MonoBehaviour
{
    public Camera Camera;
    public GameObject Player;
    public GameObject[] LifeUpPrefabs;

    public float SpawnRateMinimum = 8.0f;
    public float SpawnRateMaximum = 20.0f;

    public float lifeUpSpeedMin = -0.3f;
    public float lifeUpSpeedMax = 3;

    private float _nextSpawnTime;

    public AudioSource volcanoLifeSFX;

    private void DetermineNextSpawnTime()
    {
        _nextSpawnTime = Time.time + UnityEngine.Random.Range(SpawnRateMinimum, SpawnRateMaximum);
    }

    private void LifeUpOnVolcano()
    {
        var prefabToSpawnVolcano = LifeUpPrefabs[1];

        var lifeUpVolcano = Instantiate(prefabToSpawnVolcano, transform);
        lifeUpVolcano.transform.position = new Vector3(0, 0, 0);

        volcanoLifeSFX.Play();

        var directionVolcano = new Vector3(0, 1, 0);
        var speedVolcano = 10;

        var rigidbodyVolcano = lifeUpVolcano.GetComponent<Rigidbody2D>();
        rigidbodyVolcano.gravityScale = 0;
        rigidbodyVolcano.AddForce(directionVolcano * speedVolcano, ForceMode2D.Impulse);

        Destroy(lifeUpVolcano, 1);
    }

    IEnumerator SpawnLiveUp()
    {
        LifeUpOnVolcano();
        yield return new WaitForSeconds(1);


        var prefabToSpawn = LifeUpPrefabs[0];

        var lifeUp = Instantiate(prefabToSpawn, transform);

        float yPosition;
        float xPosition;

        var halfWidth = Camera.orthographicSize + Camera.aspect; // halbe Breite von Spielfeld
        xPosition = Random.Range(-halfWidth - 3, 2 * halfWidth - 6.2f); // Wal spawnt auf ganzer Spielfeldbreite

        yPosition = (Camera.orthographicSize + 1); // Wal spawnt über Kamera

        var position = new Vector3(xPosition, yPosition, 0);
        lifeUp.transform.position = position;

        // unterschiedliche Geschwindigkeit
        var direction = new Vector3(0, 1, 0);
        var speed = Random.Range(lifeUpSpeedMin, lifeUpSpeedMax);

        var rigidbody = lifeUp.GetComponent<Rigidbody2D>();

        rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);


    }
    private void Start()
    {
        DetermineNextSpawnTime();
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            StartCoroutine(SpawnLiveUp());
            DetermineNextSpawnTime();
        }
    }
}
