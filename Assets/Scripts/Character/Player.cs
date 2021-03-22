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
