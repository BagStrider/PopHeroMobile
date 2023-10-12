using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _speed;

    public void ShootBullet()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        newBullet.Shoot(transform.up, _speed);
    }
}
