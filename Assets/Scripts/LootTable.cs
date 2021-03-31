using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LootTable", menuName = "Loot Table")]
public class LootTable : ScriptableObject
{
    public float damageTreshold;
    public bool tresholdAsPercentage = false;
    public List<LootTableEntry> lootList;
}

[Serializable]
public struct LootTableEntry
{
    public int itemID;
    public int amount;
    public float probability;
    public ContainerType containerType;
    public LootEntryType entryType;
}

public enum LootEntryType
{
    Loot1,
    Loot2,
    Loot3
}
