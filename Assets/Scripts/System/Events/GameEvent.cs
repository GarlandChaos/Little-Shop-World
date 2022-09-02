using System.Collections.Generic;
using UnityEngine;
using LSW.UI;

namespace LSW.Events
{
    [CreateAssetMenu(menuName = "Game Data/Game Event", fileName = "Game Event")]
    public class GameEvent : ScriptableObject
    {
        List<IGameEventListener> listeners = new List<IGameEventListener>();

        public void Raise(params object[] args)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                IGameEventListenerItem listenerItem = listeners[i] as IGameEventListenerItem;
                if (listenerItem != null)
                {
                    listenerItem.OnEventRaised((Item)args[0]);
                    continue;
                }

                IGameEventListenerInt listenerInt = listeners[i] as IGameEventListenerInt;
                if (listenerInt != null)
                {
                    listenerInt.OnEventRaised((int)args[0]);
                    continue;
                }

                IGameEventListenerItemInventoryType listenerItemInfoType = listeners[i] as IGameEventListenerItemInventoryType;
                if (listenerItemInfoType != null)
                {
                    listenerItemInfoType.OnEventRaised((Item)args[0], (InventoryType)args[1]);
                    continue;
                }

                IGameEventListenerItemInt listenerItemInt = listeners[i] as IGameEventListenerItemInt;
                if (listenerItemInt != null)
                {
                    listenerItemInt.OnEventRaised((Item)args[0], (int)args[1]);
                    continue;
                }

                IGameEventListenerItemIntInventoryType listenerItemIntInventoryType = listeners[i] as IGameEventListenerItemIntInventoryType;
                if (listenerItemIntInventoryType != null)
                {
                    listenerItemIntInventoryType.OnEventRaised((Item)args[0], (int)args[1], (InventoryType)args[2]);
                    continue;
                }

                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
