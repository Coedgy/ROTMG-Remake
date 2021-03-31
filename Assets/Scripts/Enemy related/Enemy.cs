using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    private int startHealth;

    public LootTable lootTable;

    public Dictionary<Player, float> playerDamages = new Dictionary<Player, float>();

    private void Awake()
    {
        startHealth = health;
    }

    public void TakeDamage(float damage, Player player)
    {
        damage = Mathf.CeilToInt(damage);
        if (damage > health)
        {
            damage = health;
        }
        if (playerDamages.ContainsKey(player))
        {
            playerDamages[player] += damage;
        }
        else
        {
            playerDamages.Add(player, damage);
        }
        health -= (int)damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Dictionary<int, int> itemList = ItemDatabaseManager.ConvertLootTable(lootTable);

        float value;
        if (lootTable.tresholdAsPercentage)
        {
            value = (lootTable.damageTreshold / 100) * startHealth;
        }
        else
        {
            value = lootTable.damageTreshold;
        }
        if (playerDamages[Player.script] >= value)
        {
            if (itemList.Count > 0)
            {
                List<int> itemIDlist = itemList.Keys.ToList();
                List<int> itemAmountList = itemList.Values.ToList();
                ContainerPrefabs.manager.CreateContainer(ContainerType.purple_bag, gameObject.transform.position, itemIDlist, itemAmountList); //TODO Change the bag depending on loot
            }
        }
        Debug.Log(gameObject + " was killed");
        Destroy(gameObject);
    }
}
