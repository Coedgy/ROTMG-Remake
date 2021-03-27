using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Assets/Weapon")]
public class Weapon : Equipment
{
    [Header("Weapon Values")]
    public int minDamage;
    public int maxDamage;
    public float range;
    public float fireRate = 1.0f;
    public float speed;

    public GameObject bulletPrefab;

    public WeaponType type;
}
