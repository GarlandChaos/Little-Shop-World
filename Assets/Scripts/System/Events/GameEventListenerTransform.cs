using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LSW.Events
{
    interface IGameEventListenerTransform : IGameEventListener
    {
        void OnEventRaised(Transform value);
    }

    [System.Serializable]
    public class TransformEvent : UnityEvent<Transform> { }

    public class GameEventListenerTransform : MonoBehaviour, IGameEventListenerTransform
    {
        public GameEvent gameEvent;
        public TransformEvent response;

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

        public void OnEventRaised(Transform value)
        {
            response.Invoke(value);
        }
    }
}