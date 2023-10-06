using UnityEngine;
using MilkShake;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] ShakePreset shakePreset;
    AudioSource shotSound;
    public ShipStats Stats;
    public Transform Muzzle;
    public GameObject Bullet;

    private float rateOfFire, bulletSpeed, damageAmount;
    private float loadingTime = 0f;

    private void Start()
    {
        shotSound = GetComponent<AudioSource>();
        Muzzle = transform;
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

        shotSound?.Play();
        GameObject bullet = Instantiate(Bullet, Muzzle.position, Muzzle.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(Muzzle.up * bulletSpeed);
        bullet.GetComponent<Bullet>().damageAmount = (int)damageAmount;
        loadingTime = 0;
        Shaker.ShakeAllSeparate(shakePreset);
    }

    public void UpdateFirePower(int _amount)
    {
        damageAmount = Stats.DamageAmount += (int)(Stats.DamageAmount * 0.1f);
    }
}
