using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public ShipStats stats;
    Transform player;

    public enum MovementType
    {
        Raider,
        Interceptor,
        Kamikaze
    }

    public MovementType movementType;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (movementType == MovementType.Interceptor)
        {
            StartCoroutine(MoveDown());
        }
    }

    void Update()
    {
        switch (movementType)
        {
            case MovementType.Raider:
                MoveStraight();
                break;

            case MovementType.Interceptor:
                transform.up = player.position - transform.position;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
                break;

            case MovementType.Kamikaze:
                Kamikaze();
                break;

            default:
                break;
        }
    }

    void MoveStraight()
    {
        transform.Translate(0f, stats.MovementSpeed * Time.deltaTime, 0f);
    }

    void Kamikaze()
    {
        transform.up = player.position - transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        transform.position = Vector3.MoveTowards(transform.position, player.position, stats.MovementSpeed * Time.deltaTime);
    }

    IEnumerator MoveDown()
    {
        while (transform.position.y > 40f)
        {
            transform.Translate(0f, Time.deltaTime * stats.MovementSpeed, 0f);
            yield return null;
        }

        StopCoroutine(MoveDown());
    }
}
