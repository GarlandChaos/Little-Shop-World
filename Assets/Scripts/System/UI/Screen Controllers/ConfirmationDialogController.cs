using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LSW.Events;

namespace LSW.UI
{
    public class ConfirmationDialogController : ADialogController
    {
        [SerializeField]
        TMP_Text textConfirmationMessage = null;
        [SerializeField]
        Button buttonConfirm = null;
        [SerializeField]
        Button buttonCancel = null;
        [SerializeField]
        GameEvent eventCloseConfirmationDialog = null;
        [SerializeField]
        GameEvent eventItemBought = null;
        [SerializeField]
        GameEvent eventReduceFromFunds = null;
        [SerializeField]
        GameEvent eventAddToFunds = null;
        Item currentItem = null;
        int currentInventoryId = -1;
        InventoryType currentInfoType = InventoryType.Simple;

        private void OnEnable()
        {
            buttonConfirm.enabled = false;
            buttonCancel.enabled = false;
            currentItem = null;
        }

        public void ShowMessage(Item item, int inventoryId, InventoryType infoType)
        {
            if(infoType != InventoryType.Simple)
            {
                buttonConfirm.enabled = true;
                buttonCancel.enabled = true;
                currentItem = item;
                currentInventoryId = inventoryId;
                currentInfoType = InventoryType.Buy;

                if (infoType == InventoryType.Buy)
                    textConfirmationMessage.text = "Do you want to buy " + item._Name + " for " + item._BuyPrice.ToString() + "?";
                else
                    textConfirmationMessage.text = "Do you want to sell " + item._Name + " for " + item._SellPrice.ToString() + "?";
            }
        }

        public void Confirm()
        {
            if(currentInfoType == InventoryType.Buy)
            {
                Debug.Log("Comprar item");
                eventReduceFromFunds.Raise(currentItem._BuyPrice);
                eventItemBought.Raise(currentItem, currentInventoryId);
            }
            else if(currentInfoType == InventoryType.Sell)
            {
                Debug.Log("Vender item");
                //sell event
            }
            
            eventCloseConfirmationDialog.Raise();
        }

        public void Cancel()
        {
            eventCloseConfirmationDialog.Raise();
        }
    }
}