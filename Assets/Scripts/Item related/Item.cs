using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    [Header("Item Main Info")]
    public int ID;
    public new string name;
    [TextArea]
    public string description;

    public Sprite artwork;

    public bool stackable = false;
    public int maxStack = 1;

    public bool tradable = true;
}

public class Equipment : Item
{
    [Header("Equipment Bonuses")]
    public int maxHealthBonus = 0;
    public int maxManaBonus = 0;
    public int attackBonus = 0;
    public int defenseBonus = 0;
    public int speedBonus = 0;
    public int dexterityBonus = 0;
    public int wisdomBonus = 0;
    public int vitalityBonus = 0;
}