using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

namespace LSW.UI 
{
    public class CreditsScreenController : APanelController
    {
        [SerializeField]
        GameEvent eventShowMainMenu = null;


        public void ShowMainMenu()
        {
            eventShowMainMenu.Raise();
        }
    }
}