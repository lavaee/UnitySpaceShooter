using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMovement : MonoBehaviour
{
    [SerializeField] Vector3 turningOrientation;
    [SerializeField] Transform Player;
    [SerializeField] ShipStats stats;

    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(Player.position, turningOrientation, stats.MovementSpeed * Time.deltaTime);
        transform.rotation = Player.rotation;
    }
}
