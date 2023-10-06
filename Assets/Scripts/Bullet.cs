using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BulletImpact;
    public int damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable health = collision.gameObject.GetComponent<IDamagable>();

        if (health != null)
        {
            collision.gameObject.GetComponent<IDamagable>().TakeDamage(damageAmount);
            Instantiate(BulletImpact, collision.GetContact(0).point, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
