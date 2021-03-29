﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public static Player script;

    public int health;
    public TextMeshProUGUI healthBarText;
    public Slider healthBar;

    public int mana;
    public TextMeshProUGUI manaBarText;
    public Slider manaBar;

    int level;
    int exp;
    int expNeeded;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public Slider levelBar;

    public GameObject playerListPanel;
    public GameObject containerPanel;

    public Character character;

    public Weapon weapon;
    public Armor armor;
    public Ability ability;
    public Accessory accessory;

    public int maxHealth;
    public int maxMana;

    public float damageMultiplier;
    public float damageReduction;
    public float movementSpeed;
    public float attackSpeed;
    public float healthRegen;
    public float manaRegen;

    [Header("Equipment Bonuses")]
    public int maxHealthBonus;
    public int maxManaBonus;
    public int attackBonus;
    public int defenseBonus;
    public int speedBonus;
    public int dexterityBonus;
    public int wisdomBonus;
    public int vitalityBonus;

    public List<Slot> allSlots = new List<Slot>();
    public List<Slot> equipmentSlots = new List<Slot>();
    public List<Slot> inventorySlots = new List<Slot>();
    public List<Slot> containerSlots = new List<Slot>();
    
    List<Collider2D> triggerList = new List<Collider2D>();

    private void Awake()
    {
        script = this;

        foreach (Slot slot in FindObjectsOfType<Slot>())
        {
            allSlots.Add(slot);
        }
        
        foreach (Slot slot in allSlots)
        {
            if (slot.isEquipmentSlot)
            {
                equipmentSlots.Add(slot);
            }
            else if (slot.isContainerSlot)
            {
                containerSlots.Add(slot);
            }
            else
            {
                inventorySlots.Add(slot);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        character = new Character(Class.Knight);
        UpdateValues();
        health = maxHealth;
        mana = maxMana;

        InvokeRepeating("PerSecondFunctions", 1f, 1f);

        foreach (Slot slot in inventorySlots)
        {
            if (Random.Range(0,2) == 1)
            {
                slot.SetItem(ItemDatabaseManager.GetRandomItem());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInfoBars();

        if (Input.GetKeyDown(KeyCode.P))
        {
            character.LevelUp();
            UpdateValues();
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveInventory();
            Debug.Log("Inventory saved");
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadInventory();
            Debug.Log("Inventory loaded");
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (containerPanel.activeInHierarchy)
            {
                CloseContainerPanel();
            }
            else
            {
                OpenContainerPanel();
            }
        }
    }

    void PerSecondFunctions()
    {
        health = Mathf.RoundToInt(Mathf.Clamp(health + healthRegen, 0f, maxHealth));
        mana = Mathf.RoundToInt(Mathf.Clamp(mana + manaRegen, 0f, maxMana));
    }

    void UpdateInfoBars()
    {
        exp = character.exp;
        string lvlText = "Level " + level;
        string newExpText = exp + "/" + expNeeded;
        string hpText = health + "/" + maxHealth;
        string manaText = mana + "/" + maxMana;

        healthBarText.text = hpText;
        manaBarText.text = manaText;
        levelText.text = lvlText;
        expText.text = newExpText;

        healthBar.value = (float)health / (float)maxHealth;
        manaBar.value = (float)mana / (float)maxMana;
        levelBar.value = (float)exp / (float)expNeeded;
    }

    void UpdateValues()
    {
        CheckEquipment();

        level = character.level;
        exp = character.exp;
        expNeeded = character.expNeeded;
        maxMana = character.manaP + maxManaBonus;
        maxHealth = character.life + maxHealthBonus;

        damageMultiplier = 0.5f + (character.attack + attackBonus) / 50f;
        damageReduction = character.defense + defenseBonus;
        movementSpeed = 2.8f + 5.6f * ((character.speed + speedBonus) / 75f);
        attackSpeed = 1f + 1.5f * ((character.dexterity + dexterityBonus) / 75f);
        healthRegen = 1f + 0.24f * (character.vitality + vitalityBonus);
        manaRegen = 0.5f + 0.12f * (character.wisdom + wisdomBonus);
    }

    public void SlotSwapped(bool equipmentRelated)
    {
        if (equipmentRelated)
        {
            UpdateValues();
        }
    }

    void UpdateInventory()
    {
        foreach (Slot slot in allSlots)
        {
            if (!slot.isContainerSlot)
            {
                slot.UpdateSlot();
            }
        }
    }

    void UpdateContainer()
    {
        foreach (Slot slot in containerSlots)
        {
            slot.UpdateSlot();
        }
    }
    
    public void TakeDamage(float damage)
    {
        float value = damage - damageReduction;
        if (value < (damage * 0.1f))
        {
            value = damage * 0.1f;
        }
        health -= Mathf.CeilToInt(value);
    }

    public void CheckEquipment()
    {
        //Calculate equipment bonuses
        maxHealthBonus = 0;
        maxManaBonus = 0;
        attackBonus = 0;
        defenseBonus = 0;
        speedBonus = 0;
        dexterityBonus = 0;
        wisdomBonus = 0;
        vitalityBonus = 0;
        foreach (Slot slot in equipmentSlots)
        {
            if (!slot.isEmpty)
            {
                Equipment item = slot.item as Equipment;
                maxHealthBonus += item.maxHealthBonus;
                maxManaBonus += item.maxManaBonus;
                attackBonus += item.attackBonus;
                defenseBonus += item.defenseBonus;
                speedBonus += item.speedBonus;
                dexterityBonus += item.dexterityBonus;
                wisdomBonus += item.wisdomBonus;
                vitalityBonus += item.vitalityBonus;
            }
            if (slot.equipmentSlotType == EquipmentSlotType.Weapon)
            {
                if (slot.item != null)
                {
                    weapon = slot.item as Weapon;
                }
                else
                {
                    weapon = null;
                }
            }
            else if (slot.equipmentSlotType == EquipmentSlotType.Armor)
            {
                if (slot.item != null)
                {
                    armor = slot.item as Armor;
                }
                else
                {
                    armor = null;
                }
            }
            else if (slot.equipmentSlotType == EquipmentSlotType.Ability)
            {
                if (slot.item != null)
                {
                    ability = slot.item as Ability;
                }
                else
                {
                    ability = null;
                }
            }
            else if (slot.equipmentSlotType == EquipmentSlotType.Accessory)
            {
                if (slot.item != null)
                {
                    accessory = slot.item as Accessory;
                }
                else
                {
                    accessory = null;
                }
            }
        }
    }

    public void SaveInventory()
    {
        foreach (Slot slot in allSlots)
        {
            if (!slot.isContainerSlot)
            {
                InventoryDataSlot dataSlot = character.inventory.inventorySlots[slot.slotNumber - 1];
                dataSlot.amount = slot.amount;
                if (slot.isEmpty)
                {
                    dataSlot.itemID = 0;
                    dataSlot.amount = 0;
                }
                else
                {
                    dataSlot.itemID = slot.item.ID;
                }
                if (dataSlot.slotNumber != slot.slotNumber)
                {
                    throw new Exception("Tried to save data to wrong slotNumber! Expected slotNum:" + dataSlot.slotNumber + ". oldSlot number was: " + slot.slotNumber);
                }
            }
        }
    }

    public void LoadInventory()
    {
        foreach (Slot slot in allSlots)
        {
            if (!slot.isContainerSlot)
            {
                InventoryDataSlot dataSlot = character.inventory.inventorySlots[slot.slotNumber - 1];

                if (dataSlot.itemID == 0)
                {
                    slot.item = null;
                    slot.amount = 0;
                }
                else
                {
                    slot.item = ItemDatabaseManager.GetItemByID(dataSlot.itemID);
                    slot.amount = dataSlot.amount;
                }
                if (dataSlot.slotNumber != slot.slotNumber)
                {
                    throw new Exception("Tried to save data to wrong slotNumber! Expected slotNum:" + slot.slotNumber + ". oldSlot number was: " + dataSlot.slotNumber);
                }
            }
        }
        UpdateInventory();
    }

    public void SaveContainer()
    {
        
    }

    public void LoadContainer()
    {
        
    }

    public void OpenContainerPanel()
    {
        //TODO Make a function, which loads the data from container's containerData to container slots, the call UpdateContainer()
        //TODO Maybe a "colliderInfo hit.GetComponent<Container>().container"? Then do a foreach loop to put data into it. Same for saving container data.
        containerPanel.SetActive(true);
        playerListPanel.SetActive(false);
        
        //TODO OpenContainer(container);
        //TODO UpdateContainer();
    }

    public void CloseContainerPanel()
    {
        containerPanel.SetActive(false);
        playerListPanel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        if (!triggerList.Contains(other) && other.gameObject.GetComponent<Container>())
        {
            triggerList.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (triggerList.Contains(other))
        {
            triggerList.Remove(other);
        }
    }
}