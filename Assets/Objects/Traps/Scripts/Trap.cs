using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : IDestroyOnContact
{
    [SerializeField] protected int damage;
    public int Damage { get => damage; }

    #region Observer
    private List<ITrapEnteredObserver> observers = new List<ITrapEnteredObserver>();
    
    public void SubscribeTrapEntered(ITrapEnteredObserver observer)
    {
        observers.Add(observer);
    }
    protected override void HandleContact()
    {
        foreach (ITrapEnteredObserver observer in observers)
            observer.OnTrapEnterd(this);
    }
    #endregion
}
