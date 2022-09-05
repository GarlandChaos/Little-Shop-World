using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using LSW.Events;

public class ShopkeeperInteractable : MonoBehaviour, IInteractable, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
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

    public void EnterInteractionArea()
    {
        interactable = true;
    }

    public void ExitInteractionArea()
    {
        interactable = false;
    }

    public void Interact()
    {
        if (interactable)
        {
            interactable = false;
            InventoryManager.instance.inventoryShop = inventoryGameObject.GetComponent<Inventory>();
            eventOpenShopkeeperDialogueScreen.Raise(dialogueSettings);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interact();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(interactable)
            eventCursorOnInteractable.Raise();
        else
            eventCursorNotInteractable.Raise();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventCursorOutOfInteractable.Raise();
    }
}
