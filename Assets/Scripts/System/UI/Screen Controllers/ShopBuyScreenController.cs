using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LSW.UI 
{
    public class ShopBuyScreenController : InventoryScreenController
    {
        [SerializeField]
        TMP_Text textShopName = null;

        public override void RefreshScreen()
        {
            if (InventoryManager.instance != null)
            {
                inventory = InventoryManager.instance.inventoryShop;
                if(InventoryManager.instance.inventoryShop != null)
                    textShopName.text = InventoryManager.instance.inventoryShop._OwnerName + "'s Shop";
            }
                
            UpdateItemTemplates();
            UpdateTextFunds();
        }
    }
}