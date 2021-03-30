using System.Linq;
using UnityEngine;

public class Container : MonoBehaviour
{
    public ContainerData container;

    public ContainerType type;

    public int lifetime;
    private float timestamp;
    
    //TODO When you know how you are going to keep track of different players, implement a variable that marks who can see the container

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

    public void EmptyCheck()
    {
        if (container.containerSlots.All(slot => slot.amount == 0))
        {
            Destroy(gameObject);
        }
    }

    public void CheckBagType()
    {
        if (type == ContainerType.brown_bag)
        {
            foreach (ContainerDataSlot slot in container.containerSlots)
            {
                if (slot.itemID == 0)
                {
                    return;
                }
                if (!ItemDatabaseManager.GetItemByID(slot.itemID).tradable)
                {
                    type = ContainerType.purple_bag;
                    gameObject.GetComponent<SpriteRenderer>().sprite =
                        ContainerPrefabs.manager.purple_bag.GetComponent<SpriteRenderer>().sprite;
                }
            }
        }
    }
    
    public bool AddItem(int itemID, int amount)
    {
        foreach (ContainerDataSlot slot in container.containerSlots)
        {
            if (slot.amount == 0)
            {
                slot.itemID = itemID;
                slot.amount = amount;
                CheckBagType();
                return true;
            }
        }
        return false;
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