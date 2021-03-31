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

    ContainerType GetContainerType(List<int> itemList, List<int> amountList)
    {
        //TODO make a list of lootbag item containerType enums, then remove all that arent in the list

        ContainerType[] types = new ContainerType[lootTable.lootList.Count];
        int[] items = new int[lootTable.lootList.Count];
        int[] amounts = new int[lootTable.lootList.Count];

        for (int i = 0; i < lootTable.lootList.Count; i++)
        {
            LootTableEntry entry = lootTable.lootList[i];
            types[i] = entry.containerType;
            items[i] = entry.itemID;
            amounts[i] = entry.amount;
        }

        ContainerType biggest = 0;
        for (int i = 0; i < itemList.Count; i++)
        {
            for (int j = 0; j < items.Length; j++)
            {
                if (itemList[i] == items[j])
                {
                    if (amountList[i] == amounts[j])
                    {
                        if (types[j] > biggest)
                        {
                            biggest = types[j];
                        }
                    }
                }
            }
        }
        
        return biggest;
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

                ContainerPrefabs.manager.CreateContainer(GetContainerType(itemIDlist, itemAmountList), gameObject.transform.position, itemIDlist, itemAmountList); //TODO Change the bag depending on loot
            }
        }
        Debug.Log(gameObject + " was killed");
        Destroy(gameObject);
    }
}
