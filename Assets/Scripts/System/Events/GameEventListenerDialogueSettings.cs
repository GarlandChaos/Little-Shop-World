using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace LSW.Events 
{
    interface IGameEventListenerDialogueSettings : IGameEventListener
    {
        void OnEventRaised(DialogueSettings dialogueSettings);
    }

    [System.Serializable]
    public class DialogueSettingsEvent : UnityEvent<DialogueSettings> { }

    public class GameEventListenerDialogueSettings : MonoBehaviour, IGameEventListenerDialogueSettings
    {
        public GameEvent gameEvent;
        public DialogueSettingsEvent response;

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

        public void OnEventRaised(DialogueSettings dialogueSettings)
        {
            response.Invoke(dialogueSettings);
        }
    }
}