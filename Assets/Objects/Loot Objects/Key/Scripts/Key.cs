using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : IDestroyOnContact
{
    #region Observer
    private List<IKeyCollectObserver> observers = new List<IKeyCollectObserver>();
    
    public void Subscribe(IKeyCollectObserver observer)
    {
        observers.Add(observer);
    }
    protected override void HandleContact()
    {
        foreach(IKeyCollectObserver observer in observers)
        {
            observer.OnKeyCollected(this);
        }
    }
    #endregion
}
