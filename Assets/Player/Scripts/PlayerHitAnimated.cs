using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitAnimated : MonoBehaviour, ITrapEnteredObserver
{
    [Header("References")]
    [SerializeField] private Animator animator;

    public void OnTrapEnterd(Trap trap)
    {
        animator.SetTrigger("Hitted");
    }
}
