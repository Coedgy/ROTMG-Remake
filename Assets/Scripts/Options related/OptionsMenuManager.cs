using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    public Button generalButton;
    public Button keybindingsButton;

    public GameObject generalPanel;
    public GameObject keybindingsPanel;

    Color defaultButtonColor;
    Color buttonSelectedColor;

    private void Awake()
    {
        defaultButtonColor = generalButton.GetComponent<Image>().color;
        ColorUtility.TryParseHtmlString("#FF6F00", out buttonSelectedColor);
        
        OpenGeneral();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Settings.SM.pauseKey))
        {
            BackAction();
        }
    }

    public void OpenGeneral()
    {
        HideAllMenus();
        generalButton.GetComponent<Image>().color = buttonSelectedColor;
        generalPanel.SetActive(true);
    }
    

    public void OpenKeyBindings()
    {
        HideAllMenus();
        keybindingsButton.GetComponent<Image>().color = buttonSelectedColor;
        keybindingsPanel.SetActive(true);
    }
    
    public void BackAction()
    {
        Destroy(gameObject);
    }

    public void HideAllMenus()
    {
        generalButton.GetComponent<Image>().color = defaultButtonColor;
        keybindingsButton.GetComponent<Image>().color = defaultButtonColor;

        generalPanel.SetActive(false);
        keybindingsPanel.SetActive(false);
    }
}
