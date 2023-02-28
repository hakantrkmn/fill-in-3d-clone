using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ColorCube : MonoBehaviour
{
    public Color targetColor;

    public Renderer renderer;

 
    public void CubePlacedToArt()
    {
        renderer.material.color = targetColor;

    }
    
}
