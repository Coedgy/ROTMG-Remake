using UnityEngine;

public class Character
{
    public Class characterClass;

    public Skin skin;

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

        skin = def.defaultSkin;

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

    public int CountMaxedStats()
    {
        int maxedStats = 0;
        ClassValues def = new ClassValues(characterClass);
        
        if (life == def.maxLife)
        {
            maxedStats++;
        }
        if (manaP == def.maxMana)
        {
            maxedStats++;
        }
        if (attack == def.maxAttack)
        {
            maxedStats++;
        }
        if (defense == def.maxDefense)
        {
            maxedStats++;
        }
        if (speed == def.maxSpeed)
        {
            maxedStats++;
        }
        if (dexterity == def.maxDexterity)
        {
            maxedStats++;
        }
        if (wisdom == def.maxWisdom)
        {
            maxedStats++;
        }
        if (vitality == def.maxVitality)
        {
            maxedStats++;
        }
        
        return maxedStats;
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
    public InventoryDataSlot[] inventorySlots;

    public InventoryData()
    {
        inventorySlots = new InventoryDataSlot[12];
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = new InventoryDataSlot();
            InventoryDataSlot dataSlot = inventorySlots[i];
            
            dataSlot.slotNumber = i+1;
            dataSlot.amount = 0;
            dataSlot.itemID = 0;
        }
    }
}

public class InventoryDataSlot
{
    public int slotNumber;
    public int itemID;
    public int amount;

    public InventoryDataSlot()
    {
        slotNumber = 0;
        itemID = 0;
        amount = 0;
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
    public Skin defaultSkin;
    
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
            defaultSkin = Resources.Load<Skin>("Skins/Knight/EliteKnight");
            
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
            this.attackPL = 1;
            this.defensePL = 0;
            this.speedPL = 1;
            this.dexterityPL = 1;
            this.vitalityPL = 2;
            this.wisdomPL = 1;
        }
        else if (cClass == Class.Archer)
        {
            defaultSkin = Resources.Load<Skin>("Skins/Knight/EliteKnight");
            
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
            defaultSkin = Resources.Load<Skin>("Skins/Knight/EliteKnight");
            
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
            defaultSkin = Resources.Load<Skin>("Skins/Knight/EliteKnight");
            
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

