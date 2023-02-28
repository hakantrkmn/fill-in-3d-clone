using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollectableBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<ColorCube>())
        {
            EventManager.CubePlacedToArt();
            other.transform.GetComponent<Collider>().enabled = false;
            transform.GetComponent<Collider>().enabled = false;
            transform.parent = null;
            transform.DOJump(other.transform.position, 1, 1, .5f).OnComplete(() =>
            {
                other.transform.GetComponent<ColorCube>().CubePlacedToArt();
                Destroy(gameObject);
            });
        }
    }

    private void OnCollisionEnter(Collision other)
    {
    }
}