using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

public class PlayerRegister : MonoBehaviour
{
    [SerializeField]
    GameEvent eventRegisterPlayer = null;

    void Start()
    {
        eventRegisterPlayer.Raise(transform);
    }
}
