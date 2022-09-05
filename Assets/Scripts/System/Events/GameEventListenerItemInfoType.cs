using UnityEngine;
using UnityEngine.Events;
using LSW.Gameplay;

namespace LSW.Events
{
    interface IGameEventListenerItemInfoType : IGameEventListener
    {
        void OnEventRaised(Item item, InfoType infoType);
    }

    [System.Serializable]
    public class ItemInfoTypeEvent : UnityEvent<Item, InfoType> { }

    public class GameEventListenerItemInfoType : MonoBehaviour, IGameEventListenerItemInfoType
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

        public void OnEventRaised(Item item, InfoType infoType)
        {
            response.Invoke(item, infoType);
        }
    }
}