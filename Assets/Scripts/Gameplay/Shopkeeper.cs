using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [SerializeField]
    GameObject inventoryGameObject = null;
    [SerializeField]
    GameEvent eventOpenShopScreen = null;

    public void Interact()
    {
        InventoryManager.instance.inventoryShop = inventoryGameObject.GetComponent<Inventory>();
        Debug.Log(InventoryManager.instance.inventoryShop + " set");
        eventOpenShopScreen.Raise();
    }
}
