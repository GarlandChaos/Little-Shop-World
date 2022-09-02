using UnityEngine;
using LSW.Events;

namespace LSW.UI
{
    public class UIEventListenerController : MonoBehaviour
    {
        [SerializeField]
        GameEvent eventSendItemDetails = null;
        [SerializeField]
        GameEvent eventSendConfirmationMessageDetails = null;

        private void Start()
        {
            //UIManager.instance.RequestScreen("Inventory Screen", true);
        }

        public void ShowItemDetails(Item item, InventoryType infoType)
        {
            UIManager.instance.RequestScreen("Contextual Information Dialog", true);
            eventSendItemDetails.Raise(item, infoType);
        }

        public void HideItemDetails()
        {
            UIManager.instance.RequestScreen("Contextual Information Dialog", false);
        }

        public void OpenShopBuyScreen()
        {
            UIManager.instance.RequestScreen("Shop Buy Screen", true);
        }

        public void ShowConfirmationMessage(Item item, int inventoryId, InventoryType infoType)
        {
            if(infoType != InventoryType.Simple)
            {
                UIManager.instance.RequestScreen("Contextual Information Dialog", false);
                UIManager.instance.RequestScreen("Confirmation Dialog", true);
                eventSendConfirmationMessageDetails.Raise(item, inventoryId, infoType);
            }
        }

        public void CloseConfirmationMessage()
        {
            UIManager.instance.RequestScreen("Confirmation Dialog", false);
        }
    }
}
