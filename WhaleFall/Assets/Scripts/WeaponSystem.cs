using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Transform SpawnPoint;
    public Bullet BulletPrefab;
    public float fireRate = 1f;

    private float _fireRateCounter;
    private void Update()
    {
        _fireRateCounter += Time.deltaTime;
    }

    public void Fire()
    {
        if(_fireRateCounter >= fireRate)
        {
            _fireRateCounter = 0;
            
            Instantiate(BulletPrefab, SpawnPoint);
        }
    }
}
