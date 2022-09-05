using UnityEngine;
using LSW.Events;

namespace LSW.Gameplay
{
    public class PlayerRegister : MonoBehaviour
    {
        [SerializeField]
        GameEvent eventRegisterPlayer = null;

        void Start()
        {
            eventRegisterPlayer.Raise(transform);
        }
    }
}