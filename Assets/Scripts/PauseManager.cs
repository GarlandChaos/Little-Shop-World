using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance = null;

    bool paused = false;
    public bool _Paused { get => paused; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Pause()
    {
        paused = true;
    }

    public void Unpause()
    {
        paused = false;
    }
}
