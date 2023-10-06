using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public float Apple_Bottom_Y = -30f;

    void Update()
    {
        Vector3 Apple = transform.position;

        if (Apple.y <= Apple_Bottom_Y)
        {
            Destroy(gameObject);
        }
    }
}
