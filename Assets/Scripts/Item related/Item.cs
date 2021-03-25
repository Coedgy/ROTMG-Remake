using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    public int ID;
    public new string name;
    [TextArea]
    public string description;

    public Sprite artwork;

    public bool stackable = false;
    public int maxStack = 1;
}
