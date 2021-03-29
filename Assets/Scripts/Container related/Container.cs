using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public ContainerData container;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class ContainerData
{
    public ContainerDataSlot[] inventorySlots;

    public ContainerData()
    {
        inventorySlots = new ContainerDataSlot[12];
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = new ContainerDataSlot();
            ContainerDataSlot dataSlot = inventorySlots[i];
            
            dataSlot.slotNumber = i+1;
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