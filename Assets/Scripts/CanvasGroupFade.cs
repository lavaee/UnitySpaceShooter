using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupFade : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float speed, waitTime;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        InvokeRepeating(nameof(FadeIn), waitTime, Time.deltaTime);
    }

    void FadeIn()
    {
        canvasGroup.alpha += Time.deltaTime * speed;
    }

    //void Update()
    //{
    //    while (true)
    //    {

    //    }
    //}
}
