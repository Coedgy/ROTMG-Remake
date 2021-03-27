using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public List<Slot> equipmentSlots = new List<Slot>();
    public List<Slot> inventorySlots = new List<Slot>();

    private void Awake()
    {
        script = this;

        foreach (Slot slot in FindObjectsOfType<Slot>())
        {
            if (slot.isEquipmentSlot)
            {
                equipmentSlots.Add(slot);
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
}

public class Character
{
    public Class characterClass;

    public InventoryData inventory;

    public int level;
    public int exp;
    public int expNeeded;

    public int life;
    public int manaP;
    public int attack;
    public int defense;
    public int speed;
    public int dexterity;
    public int wisdom;
    public int vitality;

    public Character(Class cClass)
    {
        ClassValues def = new ClassValues(cClass);

        characterClass = cClass;

        inventory = new InventoryData();

        level = 1;
        exp = 0;
        expNeeded = 50;

        life = def.lifeBase;
        manaP = def.manaPBase;
        attack = def.attackBase;
        defense = def.defenseBase;
        speed = def.speedBase;
        dexterity = def.dexterityBase;
        wisdom = def.wisdomBase;
        vitality = def.vitalityBase;
    }

    public void LevelUp()
    {
        if (level < 20)
        {
            level++;
            expNeeded = expNeeded + 100;
            exp = 0;

            ClassValues def = new ClassValues(characterClass);

            life += def.lifePL;
            manaP += def.manaPPL;
            attack += def.attackPL;
            defense += def.defensePL;
            speed += def.speedPL;
            dexterity += def.dexterityPL;
            wisdom += def.wisdomPL;
            vitality += def.vitalityPL;
        }
        else
        {
            Debug.Log("Maximum level of 20 reached");
        }
    }
}

public class InventoryData
{
    public List<int> slotNumber;
    public List<int> itemID;
    public List<int> amount;

    public InventoryData()
    {
        slotNumber = new List<int>();
        itemID = new List<int>();
        amount = new List<int>();
    }
}

public enum Class
{
    Knight,
    Archer,
    Wizard
}

public enum WeaponType
{
    Wand,
    Staff,
    Bow,
    Dagger,
    Sword
}

public enum ArmorType
{
    Robe,
    Hide,
    Armor
}

public struct ClassValues
{
    //Base stats
    public int lifeBase;
    public int manaPBase;
    public int attackBase;
    public int defenseBase;
    public int speedBase;
    public int dexterityBase;
    public int wisdomBase;
    public int vitalityBase;

    //Stat cap
    public int maxLife;
    public int maxMana;
    public int maxAttack;
    public int maxDefense;
    public int maxSpeed;
    public int maxDexterity;
    public int maxWisdom;
    public int maxVitality;

    //Stat gain per level
    public int lifePL;
    public int manaPPL;
    public int attackPL;
    public int defensePL;
    public int speedPL;
    public int dexterityPL;
    public int wisdomPL;
    public int vitalityPL;

    public ClassValues(Class cClass)
    {
        if (cClass == Class.Knight)
        {
            this.lifeBase = 200;
            this.manaPBase = 100;
            this.attackBase = 15;
            this.defenseBase = 0;
            this.speedBase = 7;
            this.dexterityBase = 10;
            this.vitalityBase = 10;
            this.wisdomBase = 10;

            this.maxLife = 770;
            this.maxMana = 252;
            this.maxAttack = 50;
            this.maxDefense = 40;
            this.maxSpeed = 50;
            this.maxDexterity = 50;
            this.maxVitality = 75;
            this.maxWisdom = 50;

            this.lifePL = 25;
            this.manaPPL = 5;
            this.attackPL = 2;
            this.defensePL = 0;
            this.speedPL = 1;
            this.dexterityPL = 1;
            this.vitalityPL = 2;
            this.wisdomPL = 1;
        }
        else if (cClass == Class.Archer)
        {
            this.lifeBase = 200;
            this.manaPBase = 100;
            this.attackBase = 15;
            this.defenseBase = 0;
            this.speedBase = 7;
            this.dexterityBase = 10;
            this.vitalityBase = 10;
            this.wisdomBase = 10;

            this.maxLife = 770;
            this.maxMana = 252;
            this.maxAttack = 50;
            this.maxDefense = 40;
            this.maxSpeed = 50;
            this.maxDexterity = 50;
            this.maxVitality = 75;
            this.maxWisdom = 50;

            this.lifePL = 25;
            this.manaPPL = 5;
            this.attackPL = 2;
            this.defensePL = 0;
            this.speedPL = 1;
            this.dexterityPL = 1;
            this.vitalityPL = 2;
            this.wisdomPL = 1;
        }
        else if (cClass == Class.Wizard)
        {
            this.lifeBase = 200;
            this.manaPBase = 100;
            this.attackBase = 15;
            this.defenseBase = 0;
            this.speedBase = 7;
            this.dexterityBase = 10;
            this.vitalityBase = 10;
            this.wisdomBase = 10;

            this.maxLife = 770;
            this.maxMana = 252;
            this.maxAttack = 50;
            this.maxDefense = 40;
            this.maxSpeed = 50;
            this.maxDexterity = 50;
            this.maxVitality = 75;
            this.maxWisdom = 50;

            this.lifePL = 25;
            this.manaPPL = 5;
            this.attackPL = 2;
            this.defensePL = 0;
            this.speedPL = 1;
            this.dexterityPL = 1;
            this.vitalityPL = 2;
            this.wisdomPL = 1;
        }
        else
        {
            this.lifeBase = 0;
            this.manaPBase = 0;
            this.attackBase = 0;
            this.defenseBase = 0;
            this.speedBase = 0;
            this.dexterityBase = 0;
            this.vitalityBase = 0;
            this.wisdomBase = 0;

            this.maxLife = 0;
            this.maxMana = 0;
            this.maxAttack = 0;
            this.maxDefense = 0;
            this.maxSpeed = 0;
            this.maxDexterity = 0;
            this.maxVitality = 0;
            this.maxWisdom = 0;

            this.lifePL = 0;
            this.manaPPL = 0;
            this.attackPL = 0;
            this.defensePL = 0;
            this.speedPL = 0;
            this.dexterityPL = 0;
            this.vitalityPL = 0;
            this.wisdomPL = 0;
        }
    }
}
