using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInputField;
    public TMP_InputField passwordInputField;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && usernameInputField.isFocused)
        {
            passwordInputField.Select();
        }

        if (Input.GetKeyDown(KeyCode.Return) && !usernameInputField.isFocused)
        {
            LoginAction();
        }
    }

    public void LoginAction()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
