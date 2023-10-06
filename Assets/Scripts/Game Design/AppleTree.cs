using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Apple_Tree_Header")]

    public GameObject Apple_Prefab;

    public float Apple_Tree_Speed = 10f;

    [Header("")]
    public float Left_and_Right_Edges = 10f;

    public float AppleTreeRandomSpeed = 0.1f;

    [Header("Random Header")]
    public float Apple_Drop_Rate = 1f;

    void Start()
    {
        Invoke("Drop_Apple_Func", 0);
    }

    void Drop_Apple_Func()
    {
        GameObject Apple = Instantiate(Apple_Prefab);

        Vector3 Apple_Current_Position = transform.position;

        Apple.transform.position = Apple_Current_Position;

        Invoke("Drop_Apple_Func", Apple_Drop_Rate);
    }

    void Update()
    {
        Vector3 AT_Current_Position = transform.position;

        if (AT_Current_Position.x >= Left_and_Right_Edges)
        {

            Apple_Tree_Speed = -(Apple_Tree_Speed);

        }

        else if (AT_Current_Position.x <= -Left_and_Right_Edges)
        {

            Apple_Tree_Speed = Mathf.Abs(Apple_Tree_Speed);

        }

        else if (Random.value <= AppleTreeRandomSpeed)
        {

            AT_Current_Position.x /= 2;

        }
        
        AT_Current_Position.x += (Time.deltaTime * Apple_Tree_Speed);

        transform.position = AT_Current_Position;
    }
}
