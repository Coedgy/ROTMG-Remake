using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyBindingsManager : MonoBehaviour
{
    private GameObject grid;
    
    Event keyEvent;
    TextMeshProUGUI buttonText;
    KeyCode newKey;

    bool waitingForKey;
    bool keyIsShift;
    
    void Start()
    {
        grid = transform.GetChild(1).gameObject;
        waitingForKey = false;
        
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            GameObject button = grid.transform.GetChild(i).GetChild(1).gameObject;

            if (button.name == "healthPotion")
                button.GetComponentInChildren<TextMeshProUGUI>().text = Settings.SM.healthPotionKey.ToString();

            else if (button.name == "manaPotion")
                button.GetComponentInChildren<TextMeshProUGUI>().text = Settings.SM.manaPotionKey.ToString();
            
            else if (button.name == "recall")
                button.GetComponentInChildren<TextMeshProUGUI>().text = Settings.SM.recallKey.ToString();
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && waitingForKey)
        {
            newKey = KeyCode.LeftShift;
            keyIsShift = true;
            waitingForKey = false;
        }
    }
    
    void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }
    
    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(TextMeshProUGUI text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey && !keyIsShift)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;



        yield return WaitForKey(); //executes until user presses a key

        keyIsShift = false;

        switch (keyName)

        {

            case "healthPotion":
                Settings.SM.healthPotionKey = newKey; //Set forward to new keycode
                buttonText.text = Settings.SM.healthPotionKey.ToString(); //Set button text to new key
                PlayerPrefs.SetString("healthPotionKey", Settings.SM.healthPotionKey.ToString()); //save new key to PlayerPrefs
                PlayerPrefs.Save();

                break;
            
            case "manaPotion":
                Settings.SM.manaPotionKey = newKey; //Set forward to new keycode
                buttonText.text = Settings.SM.manaPotionKey.ToString(); //Set button text to new key
                PlayerPrefs.SetString("manaPotionKey", Settings.SM.manaPotionKey.ToString()); //save new key to PlayerPrefs
                PlayerPrefs.Save();

                break;
            
            case "recall":
                Settings.SM.recallKey = newKey; //Set forward to new keycode
                buttonText.text = Settings.SM.recallKey.ToString(); //Set button text to new key
                PlayerPrefs.SetString("recallKey", Settings.SM.recallKey.ToString()); //save new key to PlayerPrefs
                PlayerPrefs.Save();

                break;
        }

        yield return null;
    }
}
