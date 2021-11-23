using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInputField;
    public TMP_InputField passwordInputField;
    public TextMeshProUGUI errorText;

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
        List<KeyValuePair<string, string>> formContent = new List<KeyValuePair<string, string>>();
        formContent.Add(new KeyValuePair<string,string>("uername", usernameInputField.text));
        formContent.Add(new KeyValuePair<string,string>("password", passwordInputField.text));
        
        var content = new FormUrlEncodedContent(formContent);
        
        var message = new HttpClient().PostAsync("http://localhost:7000/api/users/login", content).Result;

        message.Dispose();

        if (message.StatusCode == HttpStatusCode.Accepted)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ExitAction()
    {
        Application.Quit();
    }
}
