using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemDatabase", menuName = "Assets/Databases/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{

    public List<Item> allItems;

}
