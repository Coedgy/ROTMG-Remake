using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererManager : MonoBehaviour
{
    SpriteRenderer[] rend;
    MeshRenderer[] meshrend;

    void Start()
    {
        rend = FindObjectsOfType<SpriteRenderer>();
        meshrend = FindObjectsOfType<MeshRenderer>();
    }

    void Update()
    {
        foreach (SpriteRenderer rend in rend)
        {
            rend.sortingOrder = (int)(rend.transform.position.y * -100);
        }
        foreach (MeshRenderer meshrend in meshrend)
        {
            meshrend.sortingOrder = (int)(meshrend.transform.position.y * -100);
        }
    }
}
