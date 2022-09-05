using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LSW.UI
{
    public class ShopSellScreenController : InventoryScreenController
    {
        [SerializeField]
        TMP_Text textShopName = null;

        public override void RefreshScreen()
        {
            if (InventoryManager.instance != null)
            {
                if (InventoryManager.instance.inventoryShop != null)
                    textShopName.text = InventoryManager.instance.inventoryShop._OwnerName + "'s Shop";
                if (InventoryManager.instance._InventoryPlayer != null)
                    inventory = InventoryManager.instance._InventoryPlayer;
            }

            UpdateItemTemplates();
            UpdateTextFunds();
        }
    }
}
