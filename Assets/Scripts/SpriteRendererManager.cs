﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererManager : MonoBehaviour
{
    public static SpriteRendererManager script;

    SpriteRenderer[] rend;
    MeshRenderer[] meshrend;

    private void Awake()
    {
        if (script == null)
        {
            script = this;
        }
    }

    void Start()
    {
        ResetLists();
    }

    public void ResetLists()
    {
        rend = FindObjectsOfType<SpriteRenderer>();
        meshrend = FindObjectsOfType<MeshRenderer>();
    }

    void Update()
    {
        foreach (SpriteRenderer rend in rend)
        {
            if (rend != null)
            {
                rend.sortingOrder = (int)(rend.transform.position.y * -100);
            }
        }
        foreach (MeshRenderer meshrend in meshrend)
        {
            if (meshrend != null)
            {
                meshrend.sortingOrder = (int)(meshrend.transform.position.y * -100);
            }
        }
    }
}
