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
    }
    
    public void RemoveButtonAction(GameObject slot)
    {
        Destroy(slot);
    }

    public void NewCharacterAction()
    {
        GameObject newSlot = Instantiate(slotTemplate, transform);
        newSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Knight " + Random.Range(0,21);
        newSlotButton.transform.SetAsLastSibling();
    }
}
