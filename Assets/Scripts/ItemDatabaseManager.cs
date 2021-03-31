using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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
        //script.database.allItems.FirstOrDefault(x => x.ID == ID);
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

    public static Dictionary<int, int> ConvertLootTable(LootTable lootTable)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();

        foreach (LootEntryType type in new List<LootEntryType>() {LootEntryType.Loot1, LootEntryType.Loot2, LootEntryType.Loot3})
        {
            if (lootTable.lootList.All(x => x.entryType != type))
            {
                
            }
            else
            {
                Dictionary<LootTableEntry, float> minValues = new Dictionary<LootTableEntry, float>();
                Dictionary<LootTableEntry, float> maxValues = new Dictionary<LootTableEntry, float>();

                float maxValue = 0.0f;
                float prevMax = 0.0f;
                foreach (var slot in lootTable.lootList)
                {
                    if (slot.entryType == type)
                    {
                        maxValue += slot.probability;
            
                        minValues.Add(slot, prevMax + 0.01f);
                        maxValues.Add(slot,maxValue);
                        prevMax = maxValue;
                    }
                }

                if (maxValues.Last().Value < 100.00f)
                {
                    LootTableEntry temp = new LootTableEntry()
                        {amount = 0, itemID = 0, entryType = type, probability = 0.0f};
                    minValues.Add(temp, maxValues.Last().Value + 0.01f);
                    maxValues.Add(temp, 100.0f);
                }

                if (maxValues.Last().Value > 100.0f)
                {
                    throw new Exception("Loot table '" + lootTable.name + "' probabilities sum over 100% at loot type '" + type + "'");
                }

                float value = Random.Range(0.0f, 100.0f);
                List<float> minList = minValues.Values.ToList();
                List<float> maxList = maxValues.Values.ToList();
                for (int i = 0; i < maxValues.Count; i++)
                {
                    if (minList[i] < value && value < maxList[i])
                    {
                        LootTableEntry winner = minValues.First(x => x.Value.Equals(minList[i])).Key;
                        if (winner.amount != 0)
                        {
                            result.Add(winner.itemID, winner.amount);
                        }
                    }
                }
            }
        }
        return result;
    }

    public static Item GetRandomItemByList(List<Item> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static Item GetRandomItem()
    {
        return script.database.allItems[Random.Range(0, script.database.allItems.Count)];
    }
}
