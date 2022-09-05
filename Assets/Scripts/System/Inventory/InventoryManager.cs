using System.Collections.Generic;
using UnityEngine;
using LSW.Events;
using LSW.Gameplay;

namespace LSW
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager instance = null;
        List<Inventory> inventories = new List<Inventory>();
        Inventory inventoryPlayer = null;
        [SerializeField]
        GameEvent eventInventoriesModified = null;
        [HideInInspector]
        public Inventory inventoryShop = null;

        public Inventory _InventoryPlayer { get => inventoryPlayer; }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
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

            return id;
        }

        public void ModifyInventory(Item item, int id, InfoType infoType)
        {
            foreach (Inventory inventory in inventories)
            {
                if (inventory._Id == id)
                {
                    if (infoType == InfoType.Buy)
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
}