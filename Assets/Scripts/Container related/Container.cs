using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public ContainerData container;
    public int lifetime;
    private float timestamp;

    private void Awake()
    {
        container = new ContainerData();

        timestamp = Time.time + lifetime;
    }

    private void Update()
    {
        if (Time.time > timestamp)
        {
            Destroy(gameObject);
        }
    }

    public void AddItem()
    {
        foreach (ContainerDataSlot slot in container.containerSlots)
        {
            
        }
    }
}

public class ContainerData
{
    public ContainerDataSlot[] containerSlots;

    public ContainerData()
    {
        containerSlots = new ContainerDataSlot[8];
        for (int i = 0; i < containerSlots.Length; i++)
        {
            containerSlots[i] = new ContainerDataSlot();
            ContainerDataSlot dataSlot = containerSlots[i];
            
            dataSlot.slotNumber = i+13;
            dataSlot.amount = 0;
            dataSlot.itemID = 0;
        }
    }
}

public class ContainerDataSlot
{
    public int slotNumber;
    public int itemID;
    public int amount;

    public ContainerDataSlot()
    {
        slotNumber = 0;
        itemID = 0;
        amount = 0;
    }
}