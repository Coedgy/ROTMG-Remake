using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterStatsPanel : MonoBehaviour
{
    private Character character;
    private ClassValues classValues;
    
    public TextMeshProUGUI life;
    public TextMeshProUGUI mana;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI defense;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI dexterity;
    public TextMeshProUGUI wisdom;
    public TextMeshProUGUI vitality;

    private void Awake()
    {
        character = Player.script.character;
        classValues = new ClassValues(character.characterClass);
    }

    void Update()
    {
        life.text = "Life: " + character.life + " (" + ((classValues.maxLife - character.life) / 5)  + ")";
        mana.text = "Mana: " + character.manaP + " (" + ((classValues.maxMana - character.manaP) / 5)  + ")";
        attack.text = "Attack: " + character.attack + " (" + (classValues.maxAttack - character.attack)  + ")";
        defense.text = "Defense: " + character.defense + " (" + (classValues.maxDefense - character.defense)  + ")";
        speed.text = "Speed: " + character.speed + " (" + (classValues.maxSpeed - character.speed)  + ")";
        dexterity.text = "Dexterity: " + character.dexterity + " (" + (classValues.maxDexterity - character.dexterity)  + ")";
        wisdom.text = "Wisdom: " + character.wisdom + " (" + (classValues.maxWisdom - character.wisdom)  + ")";
        vitality.text = "Vitality: " + character.vitality + " (" + (classValues.maxVitality - character.vitality)  + ")";
    }
}
