using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IDestroyOnContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HandleContact();
            Destroy(gameObject);
        }
    }
    protected abstract void HandleContact();
}
