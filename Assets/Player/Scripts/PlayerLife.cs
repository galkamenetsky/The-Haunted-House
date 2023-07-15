using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, ITrapEnteredObserver
{
    [Header("References")]
    [SerializeField] private UIManager UIManager;
    [SerializeField] private int initialLife;

    private List<IGameOverObserver> observers;
    private int currentLife;
    private void Awake()
    {
        observers = new List<IGameOverObserver>();
    }
    void Start()
    {
        currentLife = initialLife;
        UIManager.SetLifeRemains(currentLife);
    }
    public void SubscribeGameOver(IGameOverObserver observer) => observers.Add(observer);
   
    private void OnHittedHandler(int damageAmount)
    {
        currentLife -= damageAmount;
        UIManager.SetLifeRemains(currentLife);
        if (currentLife <= 0)
            NotifyGameOver();
    }
    private void NotifyGameOver()
    {
        foreach (IGameOverObserver observer in observers)
            observer.OnLevelLost();
    }
    public void OnTrapEnterd(Trap trap)
    {
        OnHittedHandler(trap.Damage);
    }
}
