using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPrefabs : MonoBehaviour
{
    public static ContainerPrefabs manager;
    
    public GameObject brown_bag;
    public GameObject purple_bag;
    public GameObject white_bag;

    private void Awake()
    {
        if (manager == null || manager != this)
        {
            manager = this;
        }
    }

    public void CreateContainer(ContainerType type, Vector3 position, List<int> items, List<int> amounts = null)
    {
        bool noAmounts = amounts == null;
        GameObject bagPrefab;

        if (type == ContainerType.brown_bag)
        {
            bagPrefab = brown_bag;
        }
        else if (type == ContainerType.purple_bag)
        {
            bagPrefab = purple_bag;
        }
        else if (type == ContainerType.white_bag)
        {
            bagPrefab = white_bag;
        }
        else
        {
            bagPrefab = brown_bag;
        }

        GameObject bag = Instantiate(bagPrefab, position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        SpriteRendererManager.script.ResetLists();
        int n = 0;
        foreach (int item in items)
        {
            ContainerDataSlot dataSlot = bag.GetComponent<Container>().container.containerSlots[n];
            dataSlot.itemID = item;
            if (noAmounts)
            {
                dataSlot.amount = 1;
            }
            else
            {
                dataSlot.amount = amounts[n];
            }
            n++;
        }
    }
}

public enum ContainerType
{
    brown_bag,
    purple_bag,
    white_bag
}
