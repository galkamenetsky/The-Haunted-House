using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevelArea : MonoBehaviour
{
    public event Action OnEnterDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnEnterDoor?.Invoke();
    }
}
