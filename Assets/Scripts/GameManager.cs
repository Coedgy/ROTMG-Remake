using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager script;
    
    public string username;
    public int playerLevel;
    
    private void Awake()
    {
        if (script == null)
        {
            script = this;
        }else if (script != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
