using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Transform SpawnPoint;
    public Bullet BulletPrefab;
    public float fireRate = 1f;

    public float _fireRateCounter = 0f;

    public AudioSource shootSFX;

    private void Update()
    {
        _fireRateCounter += Time.deltaTime;
    }

    public void Fire()
    {
        if(_fireRateCounter >= fireRate)
        {
            _fireRateCounter = 0;
            
            var test = Instantiate(BulletPrefab, SpawnPoint);
            test.transform.SetParent(null);

            shootSFX.Play();
        }
    }
}
