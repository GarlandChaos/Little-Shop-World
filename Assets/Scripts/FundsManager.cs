using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundsManager : MonoBehaviour
{
    public static FundsManager instance = null;
    [SerializeField]
    int fundsInitialValue = 0;
    [SerializeField]
    int funds = 0;

    public int _Funds { get => funds; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        funds = fundsInitialValue;
    }

    public void AddToFunds(int valueToAdd)
    {
        funds += valueToAdd;
    }

    public void ReduceFromFunds(int valueToRemove)
    {
        funds -= valueToRemove;
        if(funds < 0)
            funds = 0;
    }
}