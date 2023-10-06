using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Apple Picker
public class Basket_Instatiator : MonoBehaviour
{
    public GameObject Basket_Prefab;

    public float Basket_No = 3f;

    public float Basket_Space = 2f;

    public float Basket_Bottom_Y = -14f;


    void Start()
    {
        for (int i = 0; i < Basket_No; i++)
        {
            GameObject Basket = Instantiate(Basket_Prefab);

            Vector3 Basket_Position = Vector3.zero; // (0, 0, 0)

            Basket_Position.y = Basket_Bottom_Y + (i * Basket_Space);

            Basket.transform.position = Basket_Position;
        }
    }
}
