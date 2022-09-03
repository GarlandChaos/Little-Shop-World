using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LSW.Events;

public enum InfoType
{
    Simple,
    Buy,
    Sell
}

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
        GameEvent eventItemSold = null;
        [SerializeField]
        GameEvent eventReduceFromFunds = null;
        [SerializeField]
        GameEvent eventAddToFunds = null;
        Item currentItem = null;
        int currentInventoryId = -1;
        InfoType currentInfoType = InfoType.Simple;

        private void OnEnable()
        {
            buttonConfirm.enabled = false;
            buttonCancel.enabled = false;
            currentItem = null;
        }

        public void ShowMessage(Item item, int inventoryId, InfoType infoType)
        {
            if(infoType != InfoType.Simple)
            {
                buttonConfirm.enabled = true;
                buttonCancel.enabled = true;
                currentItem = item;
                currentInventoryId = inventoryId;
                currentInfoType = infoType;

                if (infoType == InfoType.Buy)
                    textConfirmationMessage.text = "Do you want to buy " + item._Name + " for " + item._BuyPrice.ToString() + "?";
                else
                    textConfirmationMessage.text = "Do you want to sell " + item._Name + " for " + item._SellPrice.ToString() + "?";
            }
        }

        public void Confirm()
        {
            if(currentInfoType == InfoType.Buy) //Buys item
            {
                eventReduceFromFunds.Raise(currentItem._BuyPrice);
                eventItemBought.Raise(currentItem, currentInventoryId, currentInfoType);
            }
            else if(currentInfoType == InfoType.Sell) //Sells item
            {
                eventAddToFunds.Raise(currentItem._SellPrice);
                eventItemSold.Raise(currentItem, currentInventoryId, currentInfoType);
            }
            
            eventCloseConfirmationDialog.Raise();
        }

        public void Cancel()
        {
            eventCloseConfirmationDialog.Raise();
        }
    }
}