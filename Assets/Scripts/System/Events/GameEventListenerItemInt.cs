using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LSW.Events 
{
    interface IGameEventListenerItemInt : IGameEventListener
    {
        void OnEventRaised(Item item, int id);
    }

    [System.Serializable]
    public class ItemIntEvent : UnityEvent<Item, int> { }

    public class GameEventListenerItemInt : MonoBehaviour, IGameEventListenerItemInt
    {
        public GameEvent gameEvent;
        public ItemIntEvent response;

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

        public void OnEventRaised(Item item, int id)
        {
            response.Invoke(item, id);
        }
    }
}