using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneralSettingsManager : MonoBehaviour
{
    public TMP_Dropdown windowModeDropdown;
    public TMP_Dropdown qualityDropdown;
    public Slider fpsLimitSlider;
    public TextMeshProUGUI fpsLimitText;
    public Toggle customCursorToggle;

    public Toggle enemyHealthbarsToggle;
    public TMP_Dropdown playerHealthbarsDropdown;
    public Toggle playerNametagsToggle;

    public Slider masterVolumeSlider;
    public TextMeshProUGUI mastervsText;
    public Slider effectsVolumeSlider;
    public TextMeshProUGUI effectsvsText;
    public Slider musicVolumeSlider;
    public TextMeshProUGUI musicvsText;
    
    int fpsLimitValue;
    
    void Awake()
    {
        // Get the correct values from the settings file
        windowModeDropdown.value = Settings.SM.windowMode;
        qualityDropdown.value = Settings.SM.quality;
        fpsLimitSlider.value = GetFPSLimitSliderValue();
        customCursorToggle.isOn = Settings.SM.customCursorEnabled;

        enemyHealthbarsToggle.isOn = Settings.SM.enemyHealthbars;
        playerHealthbarsDropdown.value = Settings.SM.playerHealthbars;
        playerNametagsToggle.isOn = Settings.SM.playerNametags;

        masterVolumeSlider.value = Settings.SM.masterVolume;
        effectsVolumeSlider.value = Settings.SM.effectsVolume;
        musicVolumeSlider.value = Settings.SM.musicVolume;

        mastervsText.text = Mathf.RoundToInt(Settings.SM.masterVolume * 100).ToString();
        effectsvsText.text = Mathf.RoundToInt(Settings.SM.effectsVolume * 100).ToString();
        musicvsText.text = Mathf.RoundToInt(Settings.SM.musicVolume * 100).ToString();
        
        fpsLimitText.text = Settings.SM.fpsLimit.ToString();
    }
    
    void Update()
    {
        // Update the texts beside the sliders to their values
        mastervsText.text = Mathf.RoundToInt(Settings.SM.masterVolume * 100).ToString();
        effectsvsText.text = Mathf.RoundToInt(Settings.SM.effectsVolume * 100).ToString();
        musicvsText.text = Mathf.RoundToInt(Settings.SM.musicVolume * 100).ToString();
        
        fpsLimitText.text = Settings.SM.fpsLimit.ToString();
    }
    
    public int GetFPSLimitSliderValue()
    {
        if (Settings.SM.fpsLimit == 30)
        {
            return 0;
        }
        else if(Settings.SM.fpsLimit == 60)
        {
            return 1;
        }
        else if (Settings.SM.fpsLimit == 144)
        {
            return 2;
        }
        else if(Settings.SM.fpsLimit == 240)
        {
            return 3;
        }
        else
        {
            Debug.LogError("FPSLimit not found");
            return 0;
        }
    }
    
    void CheckFPSLimitSlider()
    {
        if (fpsLimitSlider.value == 0) //30
        {
            fpsLimitValue = 30;
        }
        else if (fpsLimitSlider.value == 1) //60
        {
            fpsLimitValue = 60;
        }
        else if (fpsLimitSlider.value == 2) //144
        {
            fpsLimitValue = 144;
        }
        else if (fpsLimitSlider.value == 3) //240
        {
            fpsLimitValue = 240;
        }
    }
    
    public void FPSLimitSlider()
    {
        CheckFPSLimitSlider();
        Settings.SM.fpsLimit = fpsLimitValue;
        PlayerPrefs.SetInt("fpsLimit", fpsLimitValue);
        PlayerPrefs.Save();
        Application.targetFrameRate = PlayerPrefs.GetInt("fpsLimit");
    }
    
    public void MasterVolumeSlider()
    {
        Settings.SM.masterVolume = masterVolumeSlider.value;
        PlayerPrefs.SetFloat("masterVolume", masterVolumeSlider.value);
        PlayerPrefs.Save();
    }
    
    public void EffectsVolumeSlider()
    {
        Settings.SM.effectsVolume = effectsVolumeSlider.value;
        PlayerPrefs.SetFloat("effectsVolume", effectsVolumeSlider.value);
        PlayerPrefs.Save();
    }
    
    public void MusicVolumeSlider()
    {
        Settings.SM.musicVolume = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
        PlayerPrefs.Save();
    }
    
    public void CustomCursorToggle()
    {
        Settings.SM.customCursorEnabled = customCursorToggle.isOn;
        PlayerPrefs.SetInt("customCursorEnabled", customCursorToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    
    public void EnemyHealthbarsToggle()
    {
        Settings.SM.enemyHealthbars = enemyHealthbarsToggle.isOn;
        PlayerPrefs.SetInt("enemyHealthbars", enemyHealthbarsToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    
    public void PlayerNametagsToggle()
    {
        Settings.SM.playerNametags = playerNametagsToggle.isOn;
        PlayerPrefs.SetInt("playerNametags", playerNametagsToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    
    public void PlayerHealthbarsDropdown()
    {
        Settings.SM.playerHealthbars = playerHealthbarsDropdown.value;
        PlayerPrefs.SetInt("playerHealthbars", playerHealthbarsDropdown.value);
        PlayerPrefs.Save();
    }
    
    public void WindowModeDropdown()
    {
        Settings.SM.windowMode = windowModeDropdown.value;
        PlayerPrefs.SetInt("windowMode", windowModeDropdown.value);
        PlayerPrefs.Save();
    }
    
    public void GraphicsQualityDropdown()
    {
        Settings.SM.quality = qualityDropdown.value;
        PlayerPrefs.SetInt("quality", qualityDropdown.value);
        PlayerPrefs.Save();
    }
}
