using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button charactersButton;
    public Button graveyardButton;
    public Button shopButton;
    public Button optionsButton;
    public Button logoutButton;
    public Button quitButton;

    public GameObject charactersPanel;
    
    public GameObject errorBox;
    public TextMeshProUGUI errorText;
    
    Color defaultButtonColor;
    Color buttonSelectedColor;

    private void Awake()
    {
        defaultButtonColor = charactersButton.GetComponent<Image>().color;
        ColorUtility.TryParseHtmlString("#FF6F00", out buttonSelectedColor);
        
        OpenCharacters();
    }

    public void OpenCharacters()
    {
        HideAllMenus();
        charactersButton.GetComponent<Image>().color = buttonSelectedColor;
        charactersPanel.SetActive(true);
    }
    
    public void OpenGraveyard()
    {
        //HideAllMenus();
        //graveyardButton.GetComponent<Image>().color = buttonSelectedColor;
    }

    public void OpenShop()
    {
        //HideAllMenus();
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
        graveyardButton.GetComponent<Image>().color = defaultButtonColor;
        shopButton.GetComponent<Image>().color = defaultButtonColor;
        optionsButton.GetComponent<Image>().color = defaultButtonColor;
        logoutButton.GetComponent<Image>().color = defaultButtonColor;
        Color color;
        ColorUtility.TryParseHtmlString("#302020", out color);
        quitButton.GetComponent<Image>().color = color;

        charactersPanel.SetActive(false);
    }
}
