using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Assets/Weapon")]
public class Weapon : Equipment
{
    [Header("Weapon Values")]
    public int damage;
    public float range;
    public float cooldown;
    public float speed;

    public WeaponType type;
}
