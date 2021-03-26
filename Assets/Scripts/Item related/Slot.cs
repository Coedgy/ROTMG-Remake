﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Slot : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public bool isEquipmentSlot;
    public int amount;

    public bool isEmpty;

    public GameObject slotPanel;
    public GameObject slotPanelCopy;
    public Image slotImage;
    public TextMeshProUGUI slotText;

    Color slotOriginalColor;
    Color slotFullColor;
    float oldPanelAlpha;

    float lastClick = 0f;
    float clickInterval = 0.4f;

    bool shiftIsDown;

    bool dragging;
    bool slotFound;
    GameObject foundSlot;

    RectTransform iconRectTransform;
    Vector2 originalPosition;

    Canvas canvas;

    public List<RaycastResult> RaycastMouse()
    {
        //form a list of UI elements under cursor
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            pointerId = -1,
        };

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        return results;
    }

    private void Awake()
    {
        slotPanel = transform.GetChild(0).gameObject;
        slotText = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        slotPanelCopy = Instantiate(slotPanel);
        slotPanelCopy.transform.SetParent(gameObject.transform);
        slotPanelCopy.transform.position = slotPanel.transform.position;

        iconRectTransform = slotPanelCopy.GetComponent<RectTransform>();
        iconRectTransform.offsetMin = new Vector2(15, 15);
        iconRectTransform.offsetMax = new Vector2(-15, -15);

        slotImage = slotPanelCopy.GetComponent<Image>();
        slotImage.color = Color.white;

        slotOriginalColor = slotPanel.GetComponent<Image>().color;
        slotFullColor = new Color(0.45f, 0.45f, 0.45f);
        slotPanelCopy.SetActive(false);

        oldPanelAlpha = slotImage.color.a;

        originalPosition = iconRectTransform.anchoredPosition;

        //Find canvas
        Transform testCanvasTransform = transform.parent;
        while (testCanvasTransform != null)
        {
            canvas = testCanvasTransform.GetComponent<Canvas>();
            if (canvas != null)
            {
                break;
            }
            testCanvasTransform = testCanvasTransform.parent;
        }
    }

    private void Start()
    {
        if (Random.Range(0,2) == 1)
        {
            item = ItemDatabaseManager.GetRandomItem();
        }
        UpdateSlot();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftIsDown = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftIsDown = false;
        }
    }

    public void UpdateSlot()
    {
        if (item == null)
        {
            isEmpty = true;
        }
        else
        {
            isEmpty = false;
        }

        if (isEmpty)
        {
            slotPanel.GetComponent<Image>().color = slotOriginalColor;
            slotText.gameObject.SetActive(true);
            slotImage.sprite = null;
            slotPanelCopy.SetActive(false);
        }
        else
        {
            slotPanel.GetComponent<Image>().color = slotFullColor;
            slotText.gameObject.SetActive(false);
            slotPanelCopy.SetActive(true);
            slotImage.sprite = item.artwork;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //check if there is an item in slot
        if (!isEmpty)
        {
            if (eventData.button == PointerEventData.InputButton.Left && shiftIsDown)
            {
             //Shift-click   
            }
            else
            //Check if it was left click
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                //Check for double click
                if ((lastClick + clickInterval) > Time.time)
                {
                    
                }
                lastClick = Time.time;
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                //if it was right click
                
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isEmpty)
        {
            Debug.Log("OnBeginDrag");
            dragging = true;

            Color c = slotImage.color;
            c.a = 0.6f;
            slotImage.color = c;

            //Start dragging the iconPanel, and set its parent to inv background
            iconRectTransform.SetParent(canvas.transform);
            iconRectTransform.SetAsLastSibling();
            iconRectTransform.gameObject.AddComponent<ItemDropHandler>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragging)
        {
            Debug.Log("Dragging");
            iconRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (dragging == true)
        {
            SlotCheck();
            Debug.Log("OnEndDrag");

            //Change iconRectTransform's parent and alpha to original positions
            iconRectTransform.SetParent(transform);
            iconRectTransform.SetAsLastSibling();

            Color c = slotImage.color;
            c.a = oldPanelAlpha;
            slotImage.color = c;
            ItemDropHandler slotItemDropHandler = iconRectTransform.gameObject.GetComponent<ItemDropHandler>();
            if (slotItemDropHandler.dropped == true)
            {
                //if item was dropped outside inventory panel, begin DropEvent
                DropEvent();
            }
            else if (slotFound)
            {
                //if slot was found on mouse release, begin SwapEvent
                SwapEvent();
                iconRectTransform.anchoredPosition = originalPosition;
            }
            else
            {
                iconRectTransform.anchoredPosition = originalPosition;
            }
            Destroy(slotItemDropHandler);

            slotFound = false;
            foundSlot = null;

            dragging = false;
        }

    }

    void SlotCheck()
    {
        for (int i = 0; i < RaycastMouse().Count; i++)
        {
            //Check if there is a slot under mouse, and if there is, make sure its not the current one
            if (RaycastMouse()[i].gameObject.GetComponent<Slot>() && RaycastMouse()[i].gameObject != gameObject)
            {
                slotFound = true;
                foundSlot = RaycastMouse()[i].gameObject;
            }
        }
    }

    void SwapEvent()
    {
        if (foundSlot.GetComponent<Slot>())
        {
            Debug.Log("SwapEvent");
        }
    }

    void DropEvent()
    {
        ClearSlot();
    }

    void ClearSlot()
    {
        item = null;
        UpdateSlot();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
