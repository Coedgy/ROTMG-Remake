using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LootTable", menuName = "Loot Table")]
public class LootTable : ScriptableObject
{
    public List<LootTableEntry> lootList;
    public float damageTreshold;
}

[Serializable]
public struct LootTableEntry
{
    public int itemID;
    public int amount;
    public float probability;
    public LootEntryType entryType;
}

public enum LootEntryType
{
    Phase1,
    Phase2,
    Guaranteed
}
