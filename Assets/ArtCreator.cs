using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtCreator : MonoBehaviour
{
    public int cubeCount;
    public Sprite image;

    public Transform cubeParent;

    public GameObject artCube;


    public float size = .3f;

    Texture2D texture2D;

    Vector3 cubePosition = Vector3.zero;

    private void OnEnable()
    {
        EventManager.CubePlacedToArt += CubePlacedToArt;

    }

    private void OnDisable()
    {
        EventManager.CubePlacedToArt -= CubePlacedToArt;

    }

    private void CubePlacedToArt()
    {
        cubeCount--;
        if (cubeCount==0)
        {
            Debug.Log("game over");
        }
    }

    private void Start()
    {
        CreateImage();
    }

    void CreateImage()
    {
        texture2D = image.texture;


        for (int x = 0; x < texture2D.width; x++)
        {
            for (int y = 0; y < texture2D.height; y++)
            {
                Color color = texture2D.GetPixel(x, y);

                if (color.a != 0)
                {
                    cubePosition = new Vector3(size * (x - (texture2D.width * .5f)), 0.2f,
                        size * (y - (texture2D.height) * .5f));
                    GameObject colorCube = Instantiate(artCube, cubeParent);
                    colorCube.transform.localPosition = cubePosition;
                    colorCube.GetComponent<ColorCube>().targetColor = color;
                    colorCube.transform.localScale = Vector3.one * size;
                    cubeCount++;
                }
            }

        }
        EventManager.SetCubeCount(cubeCount);

    }
}