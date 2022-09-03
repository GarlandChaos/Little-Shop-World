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
    public Inventory inventoryShop = null;

    public Inventory _InventoryPlayer { get => inventoryPlayer; }

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
        if (inventory._IsPlayerInventory)
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

    public void ModifyInventory(Item item, int id, InfoType infoType)
    {
        foreach(Inventory inventory in inventories)
        {
            if(inventory._Id == id)
            {
                if(infoType == InfoType.Buy)
                {
                    inventory.RemoveItem(item);
                    inventoryPlayer.AddItem(item);
                }
                else if (infoType == InfoType.Sell)
                {
                    inventoryPlayer.RemoveItem(item);
                    inventoryShop.AddItem(item);
                }
                break;
            }
        }
        eventInventoriesModified.Raise();
    }
}