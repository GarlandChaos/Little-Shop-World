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
    int buyPrice = 0;
    [SerializeField]
    int sellPrice = 0;
    [SerializeField]
    Sprite sprite = null;
    [SerializeField]
    List<BodyPart> bodyPartsList = new List<BodyPart>();

    public string _Name { get => itemName; }
    public string _Description { get => description; }
    public int _BuyPrice { get => buyPrice; }
    public int _SellPrice { get => sellPrice; }
    public Sprite _Sprite { get => sprite; }
    public List<BodyPart> _BodyPartsList { get => bodyPartsList; }
}
