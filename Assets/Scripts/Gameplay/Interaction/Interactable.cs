using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    //TEMPORARY
    [SerializeField]
    GameEvent eventOpenShopBuyScreen = null;
    
    public void Interact()
    {
        //Debug.Log("Interacted with " + name);
        eventOpenShopBuyScreen.Raise();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
