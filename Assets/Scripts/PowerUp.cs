using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int Amount = 10; // 10 percent
    public enum PowerUpType
    {
        Health,
        FirePower
    }

    public PowerUpType type;

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        if (go.CompareTag("Player"))
        {
            if (type == PowerUpType.Health)
            {
                go.GetComponent<PlayerHealth>().UpdateMaxHealth(Amount);
            }
            else
            {
                FindObjectOfType<PlayerShooting>().UpdateFirePower(Amount);
                FindObjectOfType<Player>().UnlockNextWeaponTier();
                //go.GetComponent<PlayerShooting>().UpdateFirePower(Amount);
            }

            Destroy(gameObject);
        }
    }
}
