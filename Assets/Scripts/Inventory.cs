using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

public class Inventory : MonoBehaviour
{
    int id = -1;
    public List<Item> itemsList = new List<Item>();
    [SerializeField]
    ItemList initialItemsList = null;
    [SerializeField]
    bool isPlayerInventory = false;

    public int _Id { get => id; }
    public bool _IsPlayerInventory { get => isPlayerInventory; }

    // Start is called before the first frame update
    void Start()
    {
        id = InventoryManager.instance.RegisterInventory(this);
        foreach (Item item in initialItemsList._ItemList)
            AddItem(item);
    }

    public void AddItem(Item item)
    {
        itemsList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (itemsList.Contains(item))
            itemsList.Remove(item);
    }
}
