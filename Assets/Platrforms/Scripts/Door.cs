using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IKeyCollectObserver
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private WinLevelArea winLevelArea;

    #region Observer
    private List<IEnterDoorObserver> observers = new List<IEnterDoorObserver>();
    private void Start()
    {
        winLevelArea.OnEnterDoor += OnEnterDoor;
    }
  
    public void SubscribeDoorEntered(IEnterDoorObserver observer)
    {
        observers.Add(observer);
    }
    private void OnEnterDoor()
    {
        foreach (IEnterDoorObserver observer in observers)
            observer.OnEnterDoor(this);
    }
    #endregion

    public void OnKeyCollected(Key key)
    {
        StartCoroutine(OpenDoor());
    }

    public IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("DoorOpen", true);
    }

   
}
