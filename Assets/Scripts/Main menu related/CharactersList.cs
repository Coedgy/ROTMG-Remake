using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharactersList : MonoBehaviour
{
    public GameObject slotTemplate;
    public GameObject newSlotButton;

    public void CharacterButtonAction(GameObject slot)
    {
        Debug.Log("CharacterAction: " + slot);
        
        //TODO go to gameplay scene with the chosen character
    }
    
    public void RemoveButtonAction(GameObject slot)
    {
        Destroy(slot);
        //TODO Remove character from database and refresh the character screen
    }

    public void NewCharacterAction()
    {
        GameObject newSlot = Instantiate(slotTemplate, transform);
        newSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Knight " + Random.Range(0,21);
        newSlot.GetComponent<Button>().onClick.AddListener(() => CharacterButtonAction(newSlot));
        newSlot.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => RemoveButtonAction(newSlot));
        newSlotButton.transform.SetAsLastSibling();
        
        //TODO go to character creation screen
    }
}
