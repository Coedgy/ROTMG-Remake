using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button charactersButton;
    public Button shopButton;
    public Button optionsButton;
    public Button logoutButton;
    public Button quitButton;
    
    Color defaultButtonColor;
    Color buttonSelectedColor;

    private void Awake()
    {
        defaultButtonColor = charactersButton.GetComponent<Image>().color;
        ColorUtility.TryParseHtmlString("#FF6F00", out buttonSelectedColor);
    }

    public void OpenCharacters()
    {
        HideAllMenus();
        charactersButton.GetComponent<Image>().color = buttonSelectedColor;
    }

    public void OpenShop()
    {
        HideAllMenus();
        // keyBindingsObject.SetActive(true);
        // keyBindingsButton.GetComponent<Image>().color = buttonSelectedColor;
    }

    public void OpenOptions()
    {
        HideAllMenus();
        optionsButton.GetComponent<Image>().color = buttonSelectedColor;
    }
    
    public void LogoutAction()
    {
        SceneManager.LoadScene("LoginScreen");
        Debug.LogWarning("Logout action");
    }

    public void QuitAction()
    {
        Application.Quit();
        Debug.LogWarning("Exiting game");
    }

    public void HideAllMenus()
    {
        charactersButton.GetComponent<Image>().color = defaultButtonColor;
        shopButton.GetComponent<Image>().color = defaultButtonColor;
        optionsButton.GetComponent<Image>().color = defaultButtonColor;
        logoutButton.GetComponent<Image>().color = defaultButtonColor;
        quitButton.GetComponent<Image>().color = defaultButtonColor;

        //charactersMenu.SetActive(false);
    }
}
