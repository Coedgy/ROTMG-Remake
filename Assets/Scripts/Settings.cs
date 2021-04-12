using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings SM;
    
    private void Awake()
    {
        if (SM == null)
        {
            SM = this;
        }else if (SM != this)
        {
            Destroy(gameObject);
        }
    }
}
