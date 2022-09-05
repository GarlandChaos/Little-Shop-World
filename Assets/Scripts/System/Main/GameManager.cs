using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LSW.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UIManager.instance.RequestScreen("Inventory Screen"); //provisório, precisa mandar um evento primeiro para o UI Event Listener abrir a tela.
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.RequestScreen("Pause Screen"); //provisório, precisa mandar um evento primeiro para o UI Event Listener abrir a tela.
        }
    }
}
