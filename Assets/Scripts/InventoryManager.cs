using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance = null;
    List<Inventory> inventories = new List<Inventory>();
    Inventory inventoryPlayer = null;
    [SerializeField]
    GameEvent eventInventoriesModified = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int RegisterInventory(Inventory inventory)
    {
        if (inventory._InventoryType == InventoryType.Simple)
        {
            if (inventoryPlayer == null)
                inventoryPlayer = inventory;
            else
                Destroy(inventory.gameObject);
        }

        int id = inventories.Count;
        inventories.Add(inventory);
        inventory.transform.SetParent(transform, false);

        return id;
    }

    public void ModifyInventory(Item item, int id)
    {
        foreach(Inventory inventory in inventories)
        {
            if(inventory._Id == id)
            {
                if(inventory._InventoryType == InventoryType.Buy)
                {
                    inventory.RemoveItem(item);
                    inventoryPlayer.AddItem(item);
                }
                else if (inventory._InventoryType == InventoryType.Sell)
                {
                    inventoryPlayer.RemoveItem(item);
                    inventory.AddItem(item);
                }
            }
        }
        eventInventoriesModified.Raise();
    }
}