using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public LootTable lootTable;

    public void TakeDamage(float damage)
    {
        health -= Mathf.CeilToInt(damage);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ContainerPrefabs.manager.CreateContainer(ContainerType.purple_bag, gameObject.transform.position, new List<int>() {11}); //TODO Change the bag depending on loot
        Debug.Log(gameObject + " was killed");
        Destroy(gameObject);
    }
}
