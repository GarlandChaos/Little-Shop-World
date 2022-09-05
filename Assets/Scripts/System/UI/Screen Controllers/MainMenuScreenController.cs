using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

namespace LSW.UI
{
    public class MainMenuScreenController : APanelController
    {
        [SerializeField]
        GameEvent eventPause = null;
        [SerializeField]
        GameEvent eventUnpause = null;
        [SerializeField]
        GameEvent eventShowCredits = null;

        private void Start()
        {
            eventPause.Raise();
        }

        public void StartGame()
        {
            eventUnpause.Raise();
            Hide();
        }

        public void ShowCredits()
        {
            eventShowCredits.Raise();
            Hide();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}