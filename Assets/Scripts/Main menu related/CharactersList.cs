using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CharactersList : MonoBehaviour
{
    public GameObject slotTemplate;
    public GameObject newSlotButton;

    private List<Character> charactersList = new List<Character>();

    private void Awake()
    {
        charactersList.Add(new Character(Class.Knight));
        RefreshCharactersList();
    }

    void ReloadCharactersList()
    {
        //TODO Get characters from database and populate charactersList with it
    }
    
    void RefreshCharactersList()
    {
        ReloadCharactersList();
        List<GameObject> objectsToDestroy = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject != newSlotButton)
            {
                objectsToDestroy.Add(transform.GetChild(i).gameObject);
            }
        }

        objectsToDestroy.ForEach(Destroy);
        
        foreach (Character character in charactersList)
        {
            GameObject newSlot = Instantiate(slotTemplate, transform);

            //Assign variables to the newly created slot
            newSlot.transform.GetChild(0).GetComponent<Image>().sprite = character.skin.idle1_right;
            newSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = character.characterClass + " " + character.level;
            
            newSlot.transform.GetChild(2).gameObject.SetActive(false); //TODO Remove when pets are implemented
            //newSlot.transform.GetChild(2).GetComponent<Image>().sprite = null;
            
            newSlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = character.CountMaxedStats() + "/8";
            
            //Add listeners for the whole character button and the removeCharacter button
            newSlot.GetComponent<Button>().onClick.AddListener(() => CharacterButtonAction(newSlot));
            newSlot.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => RemoveButtonAction(newSlot));
            
            newSlotButton.transform.SetAsLastSibling();
        }
    }
    
    public void CharacterButtonAction(GameObject slot)
    {
        Debug.Log("CharacterAction: " + charactersList[slot.transform.GetSiblingIndex()].level);
        
        //TODO go to gameplay scene with the chosen character
    }
    
    public void RemoveButtonAction(GameObject slot)
    {
        //TODO Remove character from database and refresh the character screen
        
        charactersList.RemoveAt(slot.transform.GetSiblingIndex());
        RefreshCharactersList();
    }

    public void NewCharacterAction()
    { 
        //TODO go to character creation screen
        
        charactersList.Add(new Character(Class.Knight){level = Random.Range(0,21)});
        RefreshCharactersList();
    }
}
