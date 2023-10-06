using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour
{
    private Renderer meshRenderer;
    [SerializeField] float animationSpeedX = 0f;
    [SerializeField] float animationSpeedY = 0f;
    private float xOffset = 0f, yOffset = 0f;

    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        xOffset += Time.deltaTime * animationSpeedX;
        yOffset += Time.deltaTime * animationSpeedY;

        meshRenderer.material.mainTextureOffset = new Vector2(xOffset, yOffset);
    }
}
