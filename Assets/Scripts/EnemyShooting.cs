using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public ShipStats Stats;
    public Transform Muzzle;
    public GameObject Bullet;

    private float rateOfFire, bulletSpeed, damageAmount;
    private float loadingTime = 0f;

    private void Start()
    {
        bulletSpeed = Stats.BulletSpeed;
        rateOfFire = Stats.RateOfFire;
        damageAmount = Stats.DamageAmount;
    }

    void Update()
    {
        loadingTime += Time.deltaTime;
        Fire();
    }

    void Fire()
    {
        if (loadingTime < 1 / rateOfFire * 60)
        {
            return;
        }

        GameObject bullet = Instantiate(Bullet, Muzzle.position, Bullet.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(Muzzle.up * bulletSpeed);
        bullet.GetComponent<Bullet>().damageAmount = (int)damageAmount;

        loadingTime = 0;
    }
}
