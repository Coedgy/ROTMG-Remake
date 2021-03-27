using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Assets/Armor")]
public class Armor : Equipment
{
    [Header("Armor Values")]
    public ArmorType type;
}