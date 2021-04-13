using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings SM;

    // VIDEO
    public int fpsLimit { get; set; }
    public int windowMode { get; set; }
    public int quality { get; set; }
    public bool customCursorEnabled { get; set; }
    public bool showFPS { get; set; }

    // GAMEPLAY
    public bool enemyHealthbars { get; set; }
    public int playerHealthbars { get; set; }
    public bool playerNametags { get; set; }
    
    // AUDIO
    public float masterVolume { get; set; }
    public float effectsVolume { get; set; }
    public float musicVolume { get; set; }
    
    // KEY BINDINGS AND CONTROLS
    public KeyCode pauseKey; //Same as unity's Input API's "Cancel"

    public KeyCode healthPotionKey { get; set; }
    public KeyCode manaPotionKey { get; set; }
    public KeyCode recallKey { get; set; }

    private void Awake()
    {
        if (SM == null)
        {
            SM = this;
        }else if (SM != this)
        {
            Destroy(gameObject);
        }

        QualitySettings.vSyncCount = 0;
        
        healthPotionKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("healthPotionKey", "F"));
        manaPotionKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("manaPotionKey", "V"));
        recallKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("recallKey", "R"));

        customCursorEnabled = PlayerPrefs.GetInt("customCursorEnabled", 1) == 1 ? true : false;
        showFPS = PlayerPrefs.GetInt("showFPS", 1) == 1 ? true : false;
        windowMode = PlayerPrefs.GetInt("windowMode", 0);
        quality = PlayerPrefs.GetInt("quality", 0);
        fpsLimit = PlayerPrefs.GetInt("fpsLimit", 60);
        
        enemyHealthbars = PlayerPrefs.GetInt("enemyHealthbars", 1) == 1 ? true : false;
        playerHealthbars = PlayerPrefs.GetInt("playerHealthbars", 0);
        playerNametags = PlayerPrefs.GetInt("playerNametags", 1) == 1 ? true : false;
        
        masterVolume = PlayerPrefs.GetFloat("masterVolume", 1f);
        effectsVolume = PlayerPrefs.GetFloat("effectsVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
    }

    private void Start()
    {
        Application.targetFrameRate = fpsLimit;
    }

    private void Update()
    {
        if (Application.targetFrameRate != fpsLimit)
        {
            Application.targetFrameRate = fpsLimit;
        }
    }
}
