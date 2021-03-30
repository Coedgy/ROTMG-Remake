using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LootTable", menuName = "Loot Table")]
public class LootTable : ScriptableObject
{
    public List<LootTableEntry> lootList;
}

[Serializable]
public struct LootTableEntry
{
    public int itemID;
    public int amount;
    public float dropPoints;
}
