using System;
using UnityEngine;

public class Tover : MonoBehaviour, ITover
{
    public ToverObject ToverObject;
    public GameObject[] PointsSpawnBullet;
    public float AttackRate;
    public float TimeForDestroyBullet;

    private float _currentTime;
    private void Start()
    {
        if (ToverObject == null)
            throw new InvalidOperationException("ToverObject not be null!");
    }

    private void Update()
    {
        if (_currentTime >= AttackRate)
        {
            Shoot();
            _currentTime = 0;
        }
        _currentTime += Time.deltaTime;
    }

    public void Shoot()
    {
        for (int i = 0; i < PointsSpawnBullet.Length; i++)
        {
            GameObject bulletObject = Instantiate(ToverObject.Bullet, PointsSpawnBullet[i].transform.position, Quaternion.identity);
            IBullet bullet = bulletObject.GetComponent<IBullet>();
            DirectionBullet direction = PointsSpawnBullet[i].GetComponent<DirectionBullet>();
            bullet.SetDirectionForSpawn(direction.DirectionOnSetUp);
            bullet.SetDamageForSpawn(ToverObject.Damage);
            Destroy(bulletObject, TimeForDestroyBullet);
        }
    }
}
