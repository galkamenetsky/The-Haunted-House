using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : IDestroyOnContact
{
    #region Observer
    private List<ICoinLootedObeserver> observers = new List<ICoinLootedObeserver>();
   
    public void SubscribeCoinLooted(ICoinLootedObeserver observer)
    {
        observers.Add(observer);
    }
    #endregion

    protected override void HandleContact()
    {
        foreach (ICoinLootedObeserver observer in observers)
            observer.OnCoinLooted(this);
    }
}
