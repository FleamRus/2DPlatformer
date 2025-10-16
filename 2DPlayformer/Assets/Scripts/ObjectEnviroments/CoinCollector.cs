using UnityEngine;
using System.Collections.Generic;

public class CoinCollector : MonoBehaviour
{
    private List<Coin> _coins = new();

    private void OnEnable()
    {
        Coin[] coins = FindObjectsOfType<Coin>();

        foreach (Coin coin in coins)
        {
            coin.IsTouchedCoin += CollectCoin;
        }
    }

    private void OnDisable()
    {
        Coin[] coins = FindObjectsOfType<Coin>();

        foreach (Coin coin in coins)
        {
            coin.IsTouchedCoin -= CollectCoin;
        }
    }

    public void CollectCoin(Coin coin)
    {
        _coins.Add(coin);
        Destroy(coin.gameObject);
    }
}
