using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        int idSum = 0;

        foreach (Item item in script.database.allItems)
        {
            idSum += item.ID;
        }

        if (idSum != (script.database.allItems.Count * (script.database.allItems.Count + 1) / 2))
        {
            FindWrongID();
            throw new System.Exception("ItemDatabase ID verifying failed, idSUM was '" + idSum + "', and it should be '" + (script.database.allItems.Count * (script.database.allItems.Count + 1) / 2) + "'");
        }
        else
        {
            Debug.Log("ItemDatabase ID's verified successfully");
        }
    }

    private static void FindWrongID()
    {
        int idSum = 0;
        int n = 0;

        List<Item> tempList = new List<Item>(script.database.allItems);
        tempList = tempList.OrderBy(x=>x.ID).ToList();

        foreach (Item item in tempList)
        {
            idSum += item.ID;
            n++;

            if ((n * (n + 1) / 2) != idSum)
            {
                Debug.LogError("Incorrect ID value found at ID '" + item.ID + "'");
                return;
            }
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
