using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private ObjectFeel _objectFeel;

    private int _coins;

    private void OnEnable()
    {
        _objectFeel.ObjectTouched += CollectCoin;
    }

    private void OnDisable()
    {
        _objectFeel.ObjectTouched -= CollectCoin;
    }

    private void CollectCoin(Collider2D collider)
    {
        if (collider.TryGetComponent(out Coin _))
        {
            _coins++;
        }
    }
}
