using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    public GameObject collectableCubePrefab;
    public Vector3 centerPos;
    public int layerAmount;
    public float radius;

    private void Start()
    {
        centerPos = transform.position;
    }

    private void OnEnable()
    {
        EventManager.SetCubeCount += SetCubeCount;
    }

 

    private void OnDisable()
    {
        EventManager.SetCubeCount -= SetCubeCount;
    }

    private void SetCubeCount(int amount)
    {
        float angle = 360f / ((float)amount / layerAmount);
        int tempAmount = amount / layerAmount;
        for (int layers = 0; layers < layerAmount; layers++)
        {
            for (int i = 0; i < tempAmount; i++)
            {
                Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.up);

                Vector3 direction = rotation * Vector3.forward;

                Vector3 position = centerPos + (direction * radius);
                Instantiate(collectableCubePrefab, position, rotation,transform);
            }

            centerPos.y += .3f;
        }

        if (amount%tempAmount!=0)
        {
            for (int i = 0; i < (amount%tempAmount); i++)
            {
                Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.up);

                Vector3 direction = rotation * Vector3.forward;

                Vector3 position = centerPos + (direction * radius);
                Instantiate(collectableCubePrefab, position, rotation,transform);
            }
        }
    }
}