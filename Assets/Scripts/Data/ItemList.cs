using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Containers/Item List", fileName = "Item List")]
public class ItemList : ScriptableObject
{
    [SerializeField]
    List<Item> itemList = new List<Item>();

    public List<Item> _ItemList { get => itemList; }
}
