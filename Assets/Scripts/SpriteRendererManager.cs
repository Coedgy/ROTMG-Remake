using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererManager : MonoBehaviour
{
    public static SpriteRendererManager script;

    SpriteRenderer[] rend;
    MeshRenderer[] meshrend;

    private void Awake()
    {
        if (script == null)
        {
            script = this;
        }else if (script != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetLists();
    }

    public void ResetLists()
    {
        rend = FindObjectsOfType<SpriteRenderer>();
        meshrend = FindObjectsOfType<MeshRenderer>();
    }

    void Update()
    {
        foreach (SpriteRenderer rend in rend)
        {
            if (rend != null)
            {
                rend.sortingOrder = (int)(rend.transform.position.y * -100);
            }
        }
        foreach (MeshRenderer meshrend in meshrend)
        {
            if (meshrend != null)
            {
                meshrend.sortingOrder = (int)(meshrend.transform.position.y * -100);
            }
        }
    }
}

public static class UIManager
{
    static RectTransform sidePanel;

    public static void InitializeElements()
    {
        sidePanel = GameObject.Find("SidePanel").GetComponent<RectTransform>();
    }

    public static bool MouseOverUI()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(sidePanel, Input.mousePosition))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
