using UnityEngine;
using LSW.Events;

namespace LSW.Gameplay
{
    public class ShopkeeperInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        GameObject inventoryGameObject = null;
        [SerializeField]
        DialogueSettings dialogueSettings = null;
        [SerializeField]
        GameEvent eventOpenShopkeeperDialogueScreen = null;
        [SerializeField]
        GameEvent eventCursorOnInteractable = null;
        [SerializeField]
        GameEvent eventCursorOutOfInteractable = null;
        [SerializeField]
        GameEvent eventCursorNotInteractable = null;
        bool interactable = false;
        bool detectMouseOver = true;

        public void EnterInteractionArea()
        {
            interactable = true;
        }

        public void ExitInteractionArea()
        {
            interactable = false;
            detectMouseOver = true;
        }

        public void Interact()
        {
            if (interactable)
            {
                detectMouseOver = false;
                interactable = false;
                InventoryManager.instance.inventoryShop = inventoryGameObject.GetComponent<Inventory>();
                eventOpenShopkeeperDialogueScreen.Raise(dialogueSettings);
            }
        }

        void CheckCursor()
        {
            if (detectMouseOver)
            {
                if (interactable)
                    eventCursorOnInteractable.Raise();
                else
                    eventCursorNotInteractable.Raise();
            }
        }

        private void OnMouseEnter()
        {
            CheckCursor();
        }

        private void OnMouseOver()
        {
            CheckCursor();
        }

        private void OnMouseDown()
        {
            Interact();

        }

        private void OnMouseExit()
        {
            eventCursorOutOfInteractable.Raise();
        }
    }
}