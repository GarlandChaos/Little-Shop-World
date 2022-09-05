using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

namespace LSW.UI 
{
    public class PauseScreenController : APanelController
    {
        [SerializeField]
        protected GameEvent eventPause = null;
        [SerializeField]
        protected GameEvent eventUnpause = null;

        private void OnEnable()
        {
            eventPause.Raise();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                eventUnpause.Raise();
                Hide();
            }
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}