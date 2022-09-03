using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LSW.Events
{
    interface IGameEventListenerItemIntInfoType : IGameEventListener
    {
        void OnEventRaised(Item item, int id, InfoType infoType);
    }

    [System.Serializable]
    public class ItemIntInfoTypeEvent : UnityEvent<Item, int, InfoType> { }

    public class GameEventListenerItemIntInfoType : MonoBehaviour, IGameEventListenerItemIntInfoType
    {
        public GameEvent gameEvent;
        public ItemIntInfoTypeEvent response;

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

        public void OnEventRaised(Item item, int id, InfoType inventoryType)
        {
            response.Invoke(item, id, inventoryType);
        }
    }
}