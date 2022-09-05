using System.Collections.Generic;
using UnityEngine;

namespace LSW.Gameplay 
{
    public class Inventory : MonoBehaviour
    {
        int id = -1;
        [HideInInspector]
        public List<Item> itemsList = new List<Item>();
        [SerializeField]
        string ownerName = string.Empty; //InventorySettings
        [SerializeField]
        ItemList initialItemsList = null; //InventorySettings
        [SerializeField]
        bool isPlayerInventory = false; //InventorySettings

        public int _Id { get => id; }
        public string _OwnerName { get => ownerName; }
        public bool _IsPlayerInventory { get => isPlayerInventory; }

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
}