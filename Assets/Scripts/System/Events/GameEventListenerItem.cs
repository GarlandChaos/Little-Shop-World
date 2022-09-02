using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LSW.Events
{
    interface IGameEventListenerItem : IGameEventListener
    {
        void OnEventRaised(Item item);
    }

    [System.Serializable]
    public class ItemEvent : UnityEvent<Item> { }

    public class GameEventListenerItem : MonoBehaviour, IGameEventListenerItem
    {
        public GameEvent gameEvent;
        public ItemEvent response;

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

        public void OnEventRaised(Item item)
        {
            response.Invoke(item);
        }
    }
}