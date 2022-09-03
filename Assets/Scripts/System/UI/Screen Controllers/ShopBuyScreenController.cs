using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LSW.UI 
{
    public class ShopBuyScreenController : InventoryScreenController
    {
        public override void RefreshScreen()
        {
            inventory = InventoryManager.instance.inventoryShop;
            UpdateItemTemplates();
            UpdateTextFunds();
        }
    }
}