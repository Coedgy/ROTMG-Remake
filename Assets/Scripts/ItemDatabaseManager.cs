using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseManager : MonoBehaviour
{
    public ItemDatabase database;

    static ItemDatabaseManager script;

    private void Awake()
    {
        if (script == null)
        {
            script = this;
        }
    }

    private void Start()
    {
        VerifyItemsID();
    }

    public static void VerifyItemsID()
    {
        int idSumTarget = 0;
        int idSum = 0;

        foreach (Item item in script.database.allItems)
        {
            idSum += item.ID;
        }

        idSumTarget = (script.database.allItems.Count * (script.database.allItems.Count + 1) / 2);

        if (idSum != idSumTarget)
        {
            throw new System.Exception("ItemDatabase ID verifying failed, idSUM was '" + idSum + "', and it should be '" + idSumTarget + "'");
        }
    }

    public static Item GetItemByID(int ID)
    {
        foreach (Item item in script.database.allItems)
        {
            if (item.ID == ID)
            {
                return item;
            }
        }

        Debug.LogError("Item by ID '" + ID + "' was not found");
        return null;
    }
}
