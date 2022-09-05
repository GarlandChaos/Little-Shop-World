using UnityEngine;
using LSW.Events;
using LSW.Gameplay;

namespace LSW.UI
{
    public class UIEventListenerController : MonoBehaviour
    {
        [SerializeField]
        GameEvent eventSendItemDetails = null;
        [SerializeField]
        GameEvent eventSendConfirmationMessageDetails = null;
        [SerializeField]
        GameEvent eventShowDialogue = null;

        private void Start()
        {
            UIManager.instance.RequestScreen("Main Menu Screen", true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                UIManager.instance.RequestScreen("Inventory Screen");
            else if (Input.GetKeyDown(KeyCode.Escape))
                UIManager.instance.RequestScreen("Pause Screen");
        }

        public void ShowItemDetails(Item item, InfoType infoType)
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
            UIManager.instance.RequestScreen("Shopkeeper Dialogue Screen", false);
        }

        public void OpenShopSellScreen()
        {
            UIManager.instance.RequestScreen("Shop Sell Screen", true);
            UIManager.instance.RequestScreen("Shopkeeper Dialogue Screen", false);
        }

        public void OpenShopkeeperDialogueScreen(DialogueSettings dialogueSettings)
        {
            UIManager.instance.RequestScreen("Shopkeeper Dialogue Screen", true);
            eventShowDialogue.Raise(dialogueSettings);
        }

        public void ShowConfirmationMessage(Item item, int inventoryId, InfoType infoType)
        {
            if(infoType != InfoType.Simple)
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

        public void OpenCreditsScreen()
        {
            UIManager.instance.RequestScreen("Main Menu Screen", false);
            UIManager.instance.RequestScreen("Credits Screen", true);
        }

        public void OpenMainMenuScreen()
        {
            UIManager.instance.RequestScreen("Credits Screen", false);
            UIManager.instance.RequestScreen("Main Menu Screen", true);
        }
    }
}
