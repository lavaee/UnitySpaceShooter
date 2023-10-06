using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    public int Timer;

    void Start()
    {
        Destroy(gameObject, Timer);
    }
}
