﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FrostyImageEffect : MonoBehaviour
{
    public Material material;
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination,material);
    }
}
