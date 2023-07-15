using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoinLootedObeserver
{
    void OnCoinLooted(Coin c);
}
