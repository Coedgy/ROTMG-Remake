using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;

    public int mana;

    public int level;
    public int exp;

    public Class playerClass;

    public int characterID;

    public int life;
    public int manaP;
    public int attack;
    public int defense;
    public int speed;
    public int dexterity;
    public int wisdom;
    public int vitality;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Class
{
    Knight,
    Archer,
    Wizard
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
