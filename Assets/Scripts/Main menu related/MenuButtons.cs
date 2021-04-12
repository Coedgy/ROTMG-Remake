using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool wipButton;

    string defaultText;

    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        defaultText = text.text;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (wipButton)
        {
            text.text = "Work In Progress";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.text = defaultText;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        text.text = defaultText;
    }
}
