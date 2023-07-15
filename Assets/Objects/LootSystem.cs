using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour ,ICoinLootedObeserver
{
    [Header("References")]
    [SerializeField] private UIManager uiManager;

    private int amount = 0;
    public void OnCoinLooted(Coin c)
    {
        amount++;
        uiManager.SetCoinsCount(amount);
    }
}
