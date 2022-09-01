using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Item", fileName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    string itemName = string.Empty;
    [SerializeField]
    [TextArea]
    string description = string.Empty;
    [SerializeField]
    int price = 0;
    [SerializeField]
    Sprite sprite = null;

    public string _Name { get => itemName; }
    public string _Description { get => description; }
    public int _Price { get => price; }
    public Sprite _Sprite { get => sprite; }
}
