using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Apple_Collider = collision.gameObject;

        if (Apple_Collider.CompareTag("Apple"))
        {
            Destroy(Apple_Collider);
        }
    }

    void Update()
    {
        Vector3 Mouse_Position_2D = Input.mousePosition;

        Vector3 Mouse_Position_3D = Camera.main.ScreenToWorldPoint(Mouse_Position_2D);

        Vector3 Basket_Current_Position = transform.position;

        Basket_Current_Position.x = Mouse_Position_3D.x;

        transform.position = Basket_Current_Position;
    }
}
