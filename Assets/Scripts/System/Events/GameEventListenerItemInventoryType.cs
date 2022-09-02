using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using LSW.UI;

namespace LSW.Events
{
    interface IGameEventListenerItemInventoryType : IGameEventListener
    {
        void OnEventRaised(Item item, InventoryType infoType);
    }

    [System.Serializable]
    public class ItemInfoTypeEvent : UnityEvent<Item, InventoryType> { }

    public class GameEventListenerItemInventoryType : MonoBehaviour, IGameEventListenerItemInventoryType
    {
        public GameEvent gameEvent;
        public ItemInfoTypeEvent response;

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

        public void OnEventRaised(Item item, InventoryType infoType)
        {
            response.Invoke(item, infoType);
        }
    }
}