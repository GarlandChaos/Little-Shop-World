using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UIManager.instance.RequestScreen("Inventory Screen"); //provisório, precisa mandar um evento primeiro para o UI Event Listener abrir a tela.
        }
    }
}
