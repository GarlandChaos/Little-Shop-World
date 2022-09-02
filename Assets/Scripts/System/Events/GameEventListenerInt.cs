using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LSW.Events
{
    interface IGameEventListenerInt : IGameEventListener
    {
        void OnEventRaised(int value);
    }

    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }

    public class GameEventListenerInt : MonoBehaviour, IGameEventListenerInt
    {
        public GameEvent gameEvent;
        public IntEvent response;

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

        public void OnEventRaised(int value)
        {
            response.Invoke(value);
        }
    }
}