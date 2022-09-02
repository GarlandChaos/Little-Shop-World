using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LSW.Events
{
    interface IGameEventListenerItemIntInventoryType : IGameEventListener
    {
        void OnEventRaised(Item item, int id, InventoryType inventoryType);
    }

    [System.Serializable]
    public class ItemIntInventoryTypeEvent : UnityEvent<Item, int, InventoryType> { }

    public class GameEventListenerItemIntInventoryType : MonoBehaviour, IGameEventListenerItemIntInventoryType
    {
        public GameEvent gameEvent;
        public ItemIntInventoryTypeEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        private void OnDestroy()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Debug.Log("Cannot use this version");
        }

        public void OnEventRaised(Item item, int id, InventoryType inventoryType)
        {
            response.Invoke(item, id, inventoryType);
        }
    }
}