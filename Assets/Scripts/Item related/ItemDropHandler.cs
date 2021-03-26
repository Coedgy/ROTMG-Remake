using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{

    public bool dropped;

    RectTransform sidePanel;

    void Start()
    {
        sidePanel = GameObject.Find("SidePanel").GetComponent<RectTransform>();

        dropped = false;
    }

    public void OnDrop(PointerEventData eventData)
    {

        //Check if item is dropped outside the inventory panel
        if (RectTransformUtility.RectangleContainsScreenPoint(sidePanel, Input.mousePosition))
        {
            dropped = false;
        }
        else
        {
            dropped = true;
        }
    }
}
