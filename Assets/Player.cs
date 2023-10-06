using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject[] cannonArrangement;
    [SerializeField] GameObject Guardians;
    int currentCannon = 0;

    void Start()
    {
        cannonArrangement[currentCannon].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockNextWeaponTier()
    {
        if (currentCannon + 1 < cannonArrangement.Length)
        {
            cannonArrangement[currentCannon].SetActive(false);
            currentCannon++;
            cannonArrangement[currentCannon].SetActive(true);
        }

        if (currentCannon + 1 < cannonArrangement.Length + 1)
        {
            Guardians.SetActive(true);
        }
    }
}
