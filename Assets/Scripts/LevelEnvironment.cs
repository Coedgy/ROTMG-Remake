using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnvironment : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        UIManager.InitializeElements();
        SpriteRendererManager.script.ResetLists();
    }
}
