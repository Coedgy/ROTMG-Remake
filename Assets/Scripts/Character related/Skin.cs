using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class Skin : ScriptableObject
{
    public RuntimeAnimatorController skinController;
    public Sprite idle1_right;
}
