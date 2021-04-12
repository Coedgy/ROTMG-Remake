using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject settingsPrefab;
    public TextMeshProUGUI versionText;

    private void Awake()
    {
        versionText.text = Application.productName + " " + Application.version + "" + Application.platform;
    }

    public void ResumeButton()
    {
        Destroy(gameObject);
    }
    
    public void OpenOptions()
    {
        Instantiate(settingsPrefab, transform.parent);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
